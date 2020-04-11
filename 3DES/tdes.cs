using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DES
{
    class tdes
    {
        private des _des;
        public tdes()
        {
            _des = new des();
        }

        public UInt64 EncryptBlock(UInt64 block, UInt64 key1, UInt64 key2, UInt64 key3)
        {
            // input, key1
            UInt64 result = _des.Encrypt(block, key1);
            // key 2
            result = _des.Decrypt(result, key2);
            // key 3
            result = _des.Encrypt(result, key3);
            return result;
        }

        public UInt64 DecryptBlock(UInt64 block, UInt64 key1, UInt64 key2, UInt64 key3)
        {
            // input, key3
            UInt64 result = _des.Decrypt(block, key3);
            // key 2
            result = _des.Encrypt(result, key2);
            // key 1
            result = _des.Decrypt(result, key1);
            return result;
        }

        /**
         * Szyfrowanie pliku
         */
        public void EncryptFile(string inputFileName, string outputFileName, UInt64 key1, UInt64 key2, UInt64 key3, 
            ToolStripStatusLabel statusLabel, StatusStrip statusStrip)
        {
            // sprawdzenie czy plik istnieje
            if (!File.Exists(inputFileName))
            {
                statusLabel.Text = "Plik nie istnieje";
                return;
            }
            FileStream fileStreamRead = new FileStream(inputFileName, FileMode.Open);

            // sprawdzenie rozmiaru pliku, wymagana wieloktorność 8 bajtów (64 bity)
            if (fileStreamRead.Length % 8 != 0)
            {
                statusLabel.Text = "Rozmiar pliku musi być wielokrotnością 8 bajtów";
                return;
            }

            FileStream fileStreamWrite = new FileStream(outputFileName, FileMode.Create, FileAccess.Write);

            int block_count = (int)(fileStreamRead.Length / 8);
            UInt64 block = 0;
            for (int i = 0; i < fileStreamRead.Length; i+=8)
            {
                // tworzenie bloku
                block = (UInt64)fileStreamRead.ReadByte();  // pierwszy bajt
                for (int j = 1; j < 8; j++)
                {
                    UInt64 blockByte = (UInt64)fileStreamRead.ReadByte();
                    blockByte <<= (j * 8);
                    block |= blockByte;
                }

                // szyfrowanie bloku
                UInt64 result = EncryptBlock(block, key1, key2, key3);

                // zapisywanie bloku w pliku
                byte resultByte = (byte)(result & (UInt64)0xff);  // pierwszy bajt
                fileStreamWrite.WriteByte(resultByte);
                for (int j = 1; j < 8; j++)
                {
                    resultByte = (byte)((result >> (8 * j)) & 0x00000000000000ff);
                    fileStreamWrite.WriteByte(resultByte);
                }
                if ((i % 16000) == 0)
                {
                    statusLabel.Text = "Zaszyfrowano " + ((i + 8) / 8).ToString() + " / " + block_count.ToString() + " bloków";
                    statusStrip.Refresh();
                    Application.DoEvents();
                }

            }
            statusLabel.Text = "Zaszyfrowano " + block_count.ToString() + " / " + block_count.ToString() + " bloków";
            fileStreamWrite.Close();
            fileStreamRead.Close();
        }


        /**
         * Deszyfrowanie pliku
         */
        public void DecryptFile(string inputFileName, string outputFileName, UInt64 key1, UInt64 key2, UInt64 key3,
            System.Windows.Forms.ToolStripStatusLabel statusLabel, StatusStrip statusStrip)
        {
            // sprawdzenie czy plik istnieje
            if (!File.Exists(inputFileName))
            {
                statusLabel.Text = "Plik nie istnieje";
                return;
            }
            FileStream fileStreamRead = new FileStream(inputFileName, FileMode.Open);

            // sprawdzenie rozmiaru pliku, wymagana wieloktorność 8 bajtów (64 bity)
            if (fileStreamRead.Length % 8 != 0)
            {
                statusLabel.Text = "Rozmiar pliku musi być wielokrotnością 8 bajtów";
                return;
            }

            FileStream fileStreamWrite = new FileStream(outputFileName, FileMode.Create, FileAccess.Write);

            int block_count = (int)(fileStreamRead.Length / 8);
            UInt64 block = 0;
            for (int i = 0; i < fileStreamRead.Length; i += 8)
            {
                // tworzenie bloku
                block = (UInt64)fileStreamRead.ReadByte();  // pierwszy bajt
                for (int j = 1; j < 8; j++)
                {
                    UInt64 blockByte = (UInt64)fileStreamRead.ReadByte();
                    blockByte <<= (j * 8);
                    block |= blockByte;
                }

                // deszyfrowanie bloku
                UInt64 result = DecryptBlock(block, key1, key2, key3);

                // zapisywanie bloku w pliku
                byte resultByte = (byte)(result & (UInt64)0xff);
                fileStreamWrite.WriteByte(resultByte);
                for (int j = 1; j < 8; j++)
                {
                    resultByte = (byte)((result >> (8 * j)) & 0x00000000000000ff);
                    fileStreamWrite.WriteByte(resultByte);
                }
                if ((i % 16000) == 0)
                {
                    statusLabel.Text = "Deszyfrowano " + ((i + 8) / 8).ToString() + " / " + block_count.ToString() + " bloków";
                    statusStrip.Refresh();
                    Application.DoEvents();
                }
            }
            statusLabel.Text = "Deszyfrowano " + block_count.ToString() + " / " + block_count.ToString() + " bloków";
            fileStreamWrite.Close();
            fileStreamRead.Close();
        }
    }
}
