// DisplayDemo
// 
// This is a simple example of how to drive the ShieldStudio.com 4-digit
// Shield.  More information is available from shieldstudio.com -
// click downloads
//
// This Netduino app is also available for download
//
// Changes:
// 2010 September 24 - Created Netduino app
//
// Author: ShieldStudio (info@shieldstudio.com)

using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace DisplayDemo
{
    public class Program
    {
        // this is the default address for an out-of-box 4-digit Shield
        const byte deviceAddress = 0x50;

        const Cpu.Pin ledPin = Pins.GPIO_PIN_D13;

        const int i2ctimeout = 100;

        public static void Main()
        {
            // write your code here
            byte dig3 = 0x23;
            byte dig2 = 0x22;
            byte dig1 = 0x21;
            byte dig0 = 0x20;

            OutputPort outputPin = new OutputPort(ledPin, true);

            I2CDevice device = new I2CDevice(new I2CDevice.Configuration(0x50, 400));

            // select configuration register 
            // MAX6953 Table 6
            // disable shutdown
            device.Execute(new I2CDevice.I2CTransaction[] {
                I2CDevice.CreateWriteTransaction(new byte[] { 0x04, 0x01 })
            }, i2ctimeout);

            // MAX9653 Table 23
            // set Intensity for Digit 0 and 2
            // all segments 10 ma
            device.Execute(new I2CDevice.I2CTransaction[] {
                I2CDevice.CreateWriteTransaction(new byte[] { 0x01, 0x33 })
            }, i2ctimeout);

            // MAX9653 Table 24
            // set Intensity for Digit 1 and 3
            // all segments 10 ma
            device.Execute(new I2CDevice.I2CTransaction[] {
                I2CDevice.CreateWriteTransaction(new byte[] { 0x02, 0x33 })
            }, i2ctimeout);

            // turn on all LEDs in test mode.
            // MAX6953 Table 22
            device.Execute(new I2CDevice.I2CTransaction[] {
                I2CDevice.CreateWriteTransaction(new byte[] { 0x07, 0x01 })
            }, i2ctimeout);

            // disable test mode.
            // MAX6953 Table 22
            device.Execute(new I2CDevice.I2CTransaction[] {
                I2CDevice.CreateWriteTransaction(new byte[] { 0x07, 0x00 })
            }, i2ctimeout);

            // end of setup; now loop...

            while (true)
            {
                WriteChar(device, 'S', dig3);
                WriteChar(device, 'h', dig2);
                WriteChar(device, 'i', dig1);
                WriteChar(device, 'e', dig0);

                Thread.Sleep(400);

                WriteChar(device, 'l', dig3);
                WriteChar(device, 'd', dig2);
                WriteChar(device, 'S', dig1);
                WriteChar(device, 't', dig0);

                Thread.Sleep(400);

                WriteChar(device, 'u', dig3);
                WriteChar(device, 'd', dig2);
                WriteChar(device, 'i', dig1);
                WriteChar(device, 'o', dig0);

                Thread.Sleep(400);

                WriteChar(device, '.', dig3);
                WriteChar(device, 'c', dig2);
                WriteChar(device, 'o', dig1);
                WriteChar(device, 'm', dig0);

                Thread.Sleep(500);
            }
        }

        // write one character to a digit
        static void WriteChar(I2CDevice device, char value, byte disp)
        {
            if (value == '\0')
            {
                device.Execute(new I2CDevice.I2CTransaction[] {
                    I2CDevice.CreateWriteTransaction(new byte[] { disp, (byte)' ' })
                }, i2ctimeout);
            }
            else
            {
                device.Execute(new I2CDevice.I2CTransaction[] {
                    I2CDevice.CreateWriteTransaction(new byte[] { disp, (byte)value })
                }, i2ctimeout);
            }
        }

    }
}
