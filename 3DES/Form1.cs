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
        }


        // szyfrowanie
        private void buttonEncipher_Click(object sender, EventArgs e)
        {
            tdes TripleDES = new tdes();
            UInt64 result = TripleDES.EncryptBlock(UInt64.Parse(textBoxDecrypted.Text, System.Globalization.NumberStyles.HexNumber),
                UInt64.Parse(textBoxKey1.Text, System.Globalization.NumberStyles.HexNumber),
                UInt64.Parse(textBoxKey2.Text, System.Globalization.NumberStyles.HexNumber),
                UInt64.Parse(textBoxKey3.Text, System.Globalization.NumberStyles.HexNumber));

            textBoxEncrypted.Text = result.ToString("X");
        }


        // deszyfrowanie
        private void buttonDecipher_Click(object sender, EventArgs e)
        {
            tdes TripleDES = new tdes();
            UInt64 result = TripleDES.DecryptBlock(UInt64.Parse(textBoxEncrypted.Text, System.Globalization.NumberStyles.HexNumber),
                UInt64.Parse(textBoxKey1.Text, System.Globalization.NumberStyles.HexNumber),
                UInt64.Parse(textBoxKey2.Text, System.Globalization.NumberStyles.HexNumber),
                UInt64.Parse(textBoxKey3.Text, System.Globalization.NumberStyles.HexNumber));

            textBoxDecrypted.Text = result.ToString("X");
        }
    }
}
