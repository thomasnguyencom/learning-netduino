using System;
using System.Threading;
using Microsoft.SPOT.Hardware;

namespace ShieldStudio.Views.ShieldStudio
{
    public class ShieldStudioView
    {
        private I2CDevice _device;

        byte DIGIT_1 = 0x23;
        byte DIGIT_2 = 0x22;
        byte DIGIT_3 = 0x21;
        byte DIGIT_4 = 0x20;

        const int TIMEOUT = 100;

        private const int DEFAULT_PAUSE = 400;

        public enum Digits
        {
            First,
            Second,
            Third,
            Fourth
        }

        public ShieldStudioView()
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

        public void WriteCharacter(char character, Digits digit)
        {
            byte actualDigit;
            switch (digit)
            {
                case Digits.First:
                    actualDigit = DIGIT_1;
                    break;
                case Digits.Second:
                    actualDigit = DIGIT_2;
                    break;
                case Digits.Third:
                    actualDigit = DIGIT_3;
                    break;
                case Digits.Fourth:
                    actualDigit = DIGIT_4;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("digit");
            }

            WriteChar(_device, character, actualDigit);
        }

        public void WriteWord(DisplayPanel displayPanel, int pause)
        {
            WriteCharacter(displayPanel.FirstCharacter, Digits.First);
            WriteCharacter(displayPanel.SecondCharacter, Digits.Second);
            WriteCharacter(displayPanel.ThirdCharacter, Digits.Third);
            WriteCharacter(displayPanel.FourthCharacter, Digits.Fourth);

            Thread.Sleep(pause);
        }

        public void WritePhrase(int pause, DisplayPanel[] displayPanels)
        {
            foreach (var displayPanel in displayPanels)
            {
                WriteWord(displayPanel, pause);
            }
        }

        public void WritePhrase(DisplayPanel[] displayPanels)
        {
            WritePhrase(displayPanels, false);
        }

        public void WritePhrase(DisplayPanel[] displayPanels, bool isForever)
        {
            if(isForever)
            {
                while(true)
                {
                    WritePhrase(DEFAULT_PAUSE, displayPanels);
                }
            }
            else
            {
                WritePhrase(DEFAULT_PAUSE, displayPanels);
            }
        }

        public void Clear()
        {
            WritePhrase(new DisplayPanel[] { new DisplayPanel(' ', ' ', ' ', ' ')});
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