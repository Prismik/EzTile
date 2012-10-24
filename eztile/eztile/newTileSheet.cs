using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UtilStJ;
using System.IO;
namespace eztile
{
    public partial class newTileSheet : DialogueOkAnnuler
    {
        Image _tileSheet = null;
        public Image TileSheet
        {
            get { return _tileSheet; }
            private set { _tileSheet = value; }
        }

        int _tileWidth;
        public int TileWidth
        {
            get { return _tileWidth; }
            private set { _tileWidth = value; }
        }

        int _tileHeight;
        public int TileHeight
        {
            get { return _tileHeight; }
            private set { _tileHeight = value; }
        }

        string _name;
        public string FileName
        {
            get { return _name; }
            private set { _name = value; }
        }

        public newTileSheet()
        {
            InitializeComponent();
            this.BoutonOK.Enabled = false;
            _tileWidth = (int)this.tileWidth.Value;
            _tileHeight = (int)this.tileHeight.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseDialog = new OpenFileDialog();
            browseDialog.InitialDirectory = "c:\\";
            browseDialog.Filter = " Images (*.png)|*.png|All files (*.*)|*.*";
            browseDialog.FilterIndex = 2;
            browseDialog.RestoreDirectory = true;

            if (browseDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((_tileSheet = Image.FromFile(browseDialog.FileName)) != null)
                    {
                        this.imageLocation.Text= browseDialog.FileName;
                        _tileSheet = Utilities.ResizeImage(_tileSheet, _tileSheet.Width - (_tileSheet.Width % _tileWidth),
                                                         _tileSheet.Height - (_tileSheet.Height % _tileHeight));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void m_boutonOK_Click(object sender, EventArgs e)
        {
            // Validate
            MB.Avertir(_tileHeight.ToString());
        }

        private void tilesheetName_TextChanged(object sender, EventArgs e)
        {
            if (this.imageLocation.Text != "" && this.tilesheetName.Text != "")
                this.BoutonOK.Enabled = true;
            else
                this.BoutonOK.Enabled = false;
        }

        private void imageLocation_TextChanged(object sender, EventArgs e)
        {
            if (this.tilesheetName.Text != "" && this.imageLocation.Text != "")
                this.BoutonOK.Enabled = true;
            else
                this.BoutonOK.Enabled = false;
        }

        private void tileWidth_ValueChanged(object sender, EventArgs e)
        {
            _tileWidth = (int)tileWidth.Value;
        }

        private void tileHeight_ValueChanged(object sender, EventArgs e)
        {
            _tileHeight = (int)tileHeight.Value;
        }
    }
}
