using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clipper;
using Clipper.Entities;

namespace ClipboardMonitor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ClipperGlobal.ClipperTextChanged += ClipperGlobal_ClipperTextChanged;
            ClipperGlobal.Initialize();
        }

        private void ClipperGlobal_ClipperTextChanged(ClipperEventArgs e)
        {
            textBox1.Text = e.ClipboardText;
        }
    }
}
