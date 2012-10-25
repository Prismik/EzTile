using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace eztile
{
    internal class Map
    {
        int _width;
        int _height;
        Tile[][] _map;
        public Map(int x, int y, int tileX, int tileY)
        {
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

        ~Map()
        {

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

        internal Tile GetTile(int x, int y)
        {
            return _map[y][x];
        }
    }
}
