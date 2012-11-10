using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eztile
{
    internal class Tile
    {
        int _tileId;
        public int TileID
        {
            get { return _tileId; }
            set { _tileId = value; }
        }
        int _width;
        public int Width
        {
            get { return _width; }
             set { _width = value; }
        }

        int _height;
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public Tile(int x, int y)
        {
            _tileId = 0;
            _width = x;
            _height = y;
        }

        public Tile()
        {

        }
    }
}
