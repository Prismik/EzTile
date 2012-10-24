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
            private set { _tileId = value; }
        }
        int _width;
        int _height;
        public Tile(int x, int y)
        {
            _tileId = 0;
            _width = x;
            _height = y;
        }
    }
}
