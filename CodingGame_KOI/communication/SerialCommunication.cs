using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace CodingGame_KOI.communication
{
    class SerialCommunication
    {
        public delegate void SerialDataReceivedHandler(string msg);
        private SerialPort serialPort = null;
        private string portName;
        private const int baudRate = 9600;
        private SerialDataReceivedHandler serialDataReceivedHandler;
        private frmGame frmGame;

        // progress bluetooth communication using Serial communication.
        public SerialCommunication(frmGame frm,string portName, SerialDataReceivedHandler handler)
        {
            this.frmGame = frm;
            this.portName = portName;
            this.serialDataReceivedHandler = handler;
        }

        public string PortName
        {
            get
            {
                return portName;
            }
            set
            {
                portName = value;
            }
        }
        
        public void open()
        {
            if (serialPort != null)
                close();
            serialPort = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialDataReceived);
            if (!serialPort.IsOpen)
                serialPort.Open();
        }

        public void close()
        {
            if (serialPort != null)
            {
                try
                {
                    serialPort.Close();
                }
                catch
                {}
                serialPort = null;
            }
        }

        private void serialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[10];
            int bytesRead = serialPort.Read(buffer, 0, buffer.Length);
            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            frmGame.Invoke(serialDataReceivedHandler, message);
        }

    }
}
