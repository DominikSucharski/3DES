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
        private des _des;
        public Form1()
        {
            InitializeComponent();
            _des = new des();
        }


        // szyfrowanie
        private void buttonEncipher_Click(object sender, EventArgs e)
        {
            // input, key1
            UInt64 result = _des.Encrypt(
                UInt64.Parse(textBoxInput.Text, System.Globalization.NumberStyles.HexNumber),
                UInt64.Parse(textBoxKey1.Text, System.Globalization.NumberStyles.HexNumber));
            textBoxDES1.Text = result.ToString("X");
            // key 2
            result = _des.Decrypt(result, UInt64.Parse(textBoxKey2.Text, System.Globalization.NumberStyles.HexNumber));
            textBoxDES2.Text = result.ToString("X");
            // key 3
            result = _des.Encrypt(result, UInt64.Parse(textBoxKey3.Text, System.Globalization.NumberStyles.HexNumber));
            textBoxDES3.Text = result.ToString("X");
            textBox5.Text = result.ToString("X");

        }


        // deszyfrowanie
        private void buttonDecipher_Click(object sender, EventArgs e)
        {
            // input, key3
            UInt64 result = _des.Decrypt(
    UInt64.Parse(textBox5.Text, System.Globalization.NumberStyles.HexNumber),
    UInt64.Parse(textBoxKey3.Text, System.Globalization.NumberStyles.HexNumber));
            textBoxDES3.Text = result.ToString("X");
            // key 2
            result = _des.Encrypt(result, UInt64.Parse(textBoxKey2.Text, System.Globalization.NumberStyles.HexNumber));
            textBoxDES2.Text = result.ToString("X");
            // key 1
            result = _des.Decrypt(result, UInt64.Parse(textBoxKey1.Text, System.Globalization.NumberStyles.HexNumber));
            textBoxDES1.Text = result.ToString("X");
            textBoxInput.Text = result.ToString("X");
        }
    }
}
