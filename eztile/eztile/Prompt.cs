using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UtilStJ;

namespace eztile
{
    public partial class Prompt : DialogueOkAnnuler
    {
        private string _promptValue;
        public string PromptValue
        {
            get { return _promptValue; }
            private set { _promptValue = value; }
        }

        public Prompt()
        {
            InitializeComponent();
            this.BoutonAnnuler.Text = "Cancel";
            BoutonOK.Enabled = false;
        }

        public Prompt(string prompt, string title)
        {
            InitializeComponent();
            this.Text = title;
            this.label1.Text = prompt;
            this.BoutonAnnuler.Text = "Cancel";
            BoutonOK.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                BoutonOK.Enabled = true;
                _promptValue = textBox1.Text;
            }
            else
                BoutonOK.Enabled = false;
        }
    }
}
