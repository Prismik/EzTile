using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace eztile
{
    internal class Map
    {
        string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
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
        public Map(int x, int y, int tileX, int tileY, string name)
        {
            _name = name;
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
            _width = mapToCopy.Width;
            _height = mapToCopy.Height;
            _map = mapToCopy.GetMap();
            _name = mapToCopy.Name;
        }

        public Tile[][] GetMap()
        {
            return _map;
        }

        internal Tile GetTile(int x, int y)
        {
            return _map[y][x];
        }

        public override string ToString()
        {
            string array = _name + "\n" + _width + '\n' + _height;
            for (int i = 0; i != _height; i++) // En Y, haut - bas
            {
                array += '\n';
                for (int j = 0; j != _width; j++)
                    array += _map[i][j].TileID.ToString() + ',';
            }
            return array.Substring(0, array.Length-1) + '\n';
        }
    }
}
