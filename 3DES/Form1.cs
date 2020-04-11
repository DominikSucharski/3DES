using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "gotowy";
        }


        // szyfrowanie
        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            tdes TripleDES = new tdes();
            UInt64 result = TripleDES.EncryptBlock(UInt64.Parse(textBoxDecrypted.Text, System.Globalization.NumberStyles.HexNumber),
                UInt64.Parse(textBoxKey1.Text, System.Globalization.NumberStyles.HexNumber),
                UInt64.Parse(textBoxKey2.Text, System.Globalization.NumberStyles.HexNumber),
                UInt64.Parse(textBoxKey3.Text, System.Globalization.NumberStyles.HexNumber));

            textBoxEncrypted.Text = result.ToString("X");
        }


        // deszyfrowanie
        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            tdes TripleDES = new tdes();
            UInt64 result = TripleDES.DecryptBlock(UInt64.Parse(textBoxEncrypted.Text, System.Globalization.NumberStyles.HexNumber),
                UInt64.Parse(textBoxKey1.Text, System.Globalization.NumberStyles.HexNumber),
                UInt64.Parse(textBoxKey2.Text, System.Globalization.NumberStyles.HexNumber),
                UInt64.Parse(textBoxKey3.Text, System.Globalization.NumberStyles.HexNumber));

            textBoxDecrypted.Text = result.ToString("X");
        }

        private void buttonEncryptFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            openFileDialog1.Title = "Szyfrowany plik";
            saveFileDialog1.Title = "Plik wynikowy";
            openFileDialog1.ShowDialog();
            saveFileDialog1.ShowDialog();
            tdes des = new tdes();

            des.EncryptFile(
                openFileDialog1.FileName,
                saveFileDialog1.FileName,
                UInt64.Parse(textBoxKey1.Text, System.Globalization.NumberStyles.HexNumber),
                UInt64.Parse(textBoxKey2.Text, System.Globalization.NumberStyles.HexNumber),
                UInt64.Parse(textBoxKey3.Text, System.Globalization.NumberStyles.HexNumber),
                toolStripStatusLabel1,
                statusStrip1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            openFileDialog1.Title = "Deszyfrowany plik";
            saveFileDialog1.Title = "Plik wynikowy";
            openFileDialog1.ShowDialog();
            saveFileDialog1.ShowDialog();
            tdes des = new tdes();

            des.DecryptFile(
                openFileDialog1.FileName,
                saveFileDialog1.FileName,
                UInt64.Parse(textBoxKey1.Text, System.Globalization.NumberStyles.HexNumber),
                UInt64.Parse(textBoxKey2.Text, System.Globalization.NumberStyles.HexNumber),
                UInt64.Parse(textBoxKey3.Text, System.Globalization.NumberStyles.HexNumber),
                toolStripStatusLabel1,
                statusStrip1);
        }
    }
}
