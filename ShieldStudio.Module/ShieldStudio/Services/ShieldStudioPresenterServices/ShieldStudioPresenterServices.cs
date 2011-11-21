using System;
using System.Threading;
using Microsoft.SPOT.Hardware;

namespace ShieldStudio.Services.ShieldStudioPresenterServices
{
    public class ShieldStudioPresenterServices : IShieldStudioPresenterServices
    {
        private I2CDevice _device;

        byte DIGIT_4 = 0x23;
        byte DIGIT_3 = 0x22;
        byte DIGIT_2 = 0x21;
        byte DIGIT_1 = 0x20;

        const int TIMEOUT = 100;

        public ShieldStudioPresenterServices()
        {
            _device = new I2CDevice(new I2CDevice.Configuration(0x50, 400));

            // select configuration register 
            // MAX6953 Table 6
            // disable shutdown
            _device.Execute(new I2CDevice.I2CTransaction[] { I2CDevice.CreateWriteTransaction(new byte[] { 0x04, 0x01 }) }, TIMEOUT);

            // MAX9653 Table 23
            // set Intensity for Digit 0 and 2
            // all segments 10 ma
            _device.Execute(new I2CDevice.I2CTransaction[] { I2CDevice.CreateWriteTransaction(new byte[] { 0x01, 0x33 }) }, TIMEOUT);

            // MAX9653 Table 24
            // set Intensity for Digit 1 and 3
            // all segments 10 ma
            _device.Execute(new I2CDevice.I2CTransaction[] { I2CDevice.CreateWriteTransaction(new byte[] { 0x02, 0x33 }) }, TIMEOUT);

            // turn on all LEDs in test mode.
            // MAX6953 Table 22
            _device.Execute(new I2CDevice.I2CTransaction[] { I2CDevice.CreateWriteTransaction(new byte[] { 0x07, 0x01 }) }, TIMEOUT);

            // disable test mode.
            // MAX6953 Table 22
            _device.Execute(new I2CDevice.I2CTransaction[] { I2CDevice.CreateWriteTransaction(new byte[] { 0x07, 0x00 }) }, TIMEOUT);
        }
        public void WriteCharacter(char character, ShieldStudioPresenterBase.Digits digit)
        {
            byte actualDigit;
            switch (digit)
            {
                case ShieldStudioPresenterBase.Digits.First:
                    actualDigit = DIGIT_1;
                    break;
                case ShieldStudioPresenterBase.Digits.Second:
                    actualDigit = DIGIT_2;
                    break;
                case ShieldStudioPresenterBase.Digits.Third:
                    actualDigit = DIGIT_3;
                    break;
                case ShieldStudioPresenterBase.Digits.Fourth:
                    actualDigit = DIGIT_4;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("digit");
            }

            WriteChar(_device, character, actualDigit);
        }

        public void WriteWord(char char1, char char2, char char3, char char4, int pause)
        {
            WriteCharacter(char1, ShieldStudioPresenterBase.Digits.First);
            WriteCharacter(char2, ShieldStudioPresenterBase.Digits.Second);
            WriteCharacter(char3, ShieldStudioPresenterBase.Digits.Third);
            WriteCharacter(char4, ShieldStudioPresenterBase.Digits.Fourth);

            Thread.Sleep(pause);
        }

        private void WriteChar(I2CDevice device, char value, byte disp)
        {
            if (value == '\0')
            {
                device.Execute(new I2CDevice.I2CTransaction[] { I2CDevice.CreateWriteTransaction(new byte[] { disp, (byte)' ' }) }, TIMEOUT);
            }
            else
            {
                device.Execute(new I2CDevice.I2CTransaction[] { I2CDevice.CreateWriteTransaction(new byte[] { disp, (byte)value }) }, TIMEOUT);
            }
        }
    }
}