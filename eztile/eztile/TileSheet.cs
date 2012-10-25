using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace eztile
{
    internal class TileSheet
    {
        string _imageName;
        public string ImageName
        {
            get { return _imageName; }
            set { _imageName = value; }
        }
        
        string _name;
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        Bitmap _image;
        public Bitmap Image
        {
            get { return _image; }
            private set { _image = value; }
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

        //*** END OF GETTERS , SETTERS

        public TileSheet(string name, Image image, string imageName, int width, int height)
        {
            _name = name;
            _imageName = imageName;
            _image = new Bitmap(image);
            _tileWidth = width;
            _tileHeight = height;
        }
    }
}
