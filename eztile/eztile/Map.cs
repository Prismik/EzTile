using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace eztile
{
    internal class Map
    {
        int _zIndex;
        public int ZIndex
        {
            get { return _zIndex; }
            set { _zIndex = value; }
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

        Tile[][] _map;
        public Map(int x, int y, int tileX, int tileY, int zIndex)
        {
            _zIndex = zIndex;
            _width = x;
            _height = y;
            _map = new Tile[_height][];
            for (int i = 0; i != _height; i++) // En Y, haut - bas
            {
                _map[i]= new Tile[_height];
                for (int j = 0; j != _width; j++)
                    _map[i][j] = new Tile(tileX, tileY);
            }
        }

        public Map(Map mapToCopy)
        {
            _zIndex = mapToCopy.ZIndex;
            _width = mapToCopy.Width;
            _height = mapToCopy.Height;
            _map = mapToCopy.GetMap();
        }

        internal string GetMapArray()
        {
            string array = "FileName\n"+this._width+'\n'+this._height;
            for (int i = 0; i != _height; i++) // En Y, haut - bas
            {
                array += '\n';
                for (int j = 0; j != _width; j++)
                    array += _map[i][j].TileID.ToString() + ',';
            }
            return array;
        }

        public Tile[][] GetMap()
        {
            return _map;
        }

        internal Tile GetTile(int x, int y)
        {
            return _map[y][x];
        }
    }
}
