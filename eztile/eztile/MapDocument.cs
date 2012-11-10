using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtilStJ;

namespace eztile
{
    class MapDocument
    {
        int _mapWidth;
        int _mapHeight;
        int _tileWidth;
        int _tileHeight;

        string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        List<Map> _layers;
        public List<Map> GetLayers()
        {
            return _layers;
        }

        public int AddLayer()
        {
            _layers.Add(new Map(_mapWidth, _mapHeight, _tileWidth, _tileHeight, _layers.Count));
            return _layers.Count;
        }

        public int RemoveLayer(int noLayer)
        {
            try
            {
                if (noLayer > _layers.Count)
                    throw new IndexOutOfRangeException("RemoveLayer failed to execute. Param noLayer out of range");

                _layers.RemoveAt(noLayer);
            }
            catch (Exception e)
            {
                MB.Avertir(e.ToString());
            }

            int index= 1;
            foreach (Map map in _layers)
            {
                map.ZIndex = index;
                index++;
            }

            return _layers.Count;
        }

        public void MoveLayer(int from, int to)
        {
            Map copy = new Map(_layers[from]);
            _layers[from] = _layers[to];
            _layers[to] = copy;
            
        }

        TileSheet _tileSheet;
        public TileSheet TileSheet
        {
            get { return _tileSheet; }
            set { _tileSheet = value; }
        }
        // END OF GETTERS - SETTERS
        
        public MapDocument(int mapWidth, int mapHeight, int tileWidth, int tileHeight)
        {
            _tileSheet = null;
            _layers= new List<Map>();
            _layers.Add(new Map(mapWidth, mapHeight, tileWidth, tileHeight, 1));
            _fileName = null;
            _mapWidth = mapWidth;
            _mapHeight = mapHeight;
            _tileWidth = tileWidth;
            _tileHeight = tileHeight;
        }

        private MapDocument()
        {
            _tileSheet = null;
            _fileName = null;
            _layers = new List<Map>();
        }
    }
}
