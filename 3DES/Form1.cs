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

        private void buttonEncipher_Click(object sender, EventArgs e)
        {
            //                               data                    key
            UInt64 result = _des.Encrypt(0x0123456789ABCDEF, 0x133457799BBCDFF1);
            textBox5.Text = result.ToString();

        }
    }
}
