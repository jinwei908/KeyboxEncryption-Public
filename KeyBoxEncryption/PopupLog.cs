using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeyBoxEncryption
{
    public partial class PopupLog : Form
    {
        public PopupLog()
        {
            InitializeComponent();
        }

        public string LogText
        {
            set
            {
                richTextBox1.Text = value;
                
            }
        }
    }
}
