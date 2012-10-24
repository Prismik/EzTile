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
    public partial class newMap : DialogueOkAnnuler
    {
        int _mapWidth;
        public int MapWidth
        {
            get { return _mapWidth; }
            private set { _mapWidth = value; }
        }

        int _mapHeight;
        public int MapHeight
        {
            get { return _mapHeight; }
            private set { _mapHeight = value; }
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
        public newMap()
        {
            InitializeComponent();
            _mapWidth= (int)this.mapWidth.Value;
            _mapHeight= (int)this.mapHeight.Value;
            _tileWidth= (int)this.tileWidth.Value;
            _tileHeight= (int)this.tileHeight.Value;
        }

        private void mapWidth_ValueChanged(object sender, EventArgs e)
        {
            RefreshValue();
        }

        private void tileWidth_ValueChanged(object sender, EventArgs e)
        {
            RefreshValue();
        }

        private void mapHeight_ValueChanged(object sender, EventArgs e)
        {
            RefreshValue();
        }

        private void tileHeight_ValueChanged(object sender, EventArgs e)
        {
            RefreshValue();
        }

        private void RefreshValue()
        {
            this.mapSize.Text = (this.mapWidth.Value * this.tileWidth.Value).ToString() + " x " +
                                (this.mapHeight.Value * this.tileHeight.Value).ToString() + " pixels";
            _mapWidth = (int)this.mapWidth.Value;
            _mapHeight = (int)this.mapHeight.Value;
            _tileWidth = (int)this.tileWidth.Value;
            _tileHeight = (int)this.tileHeight.Value;
        }
    }
}
