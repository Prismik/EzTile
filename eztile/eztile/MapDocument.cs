using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eztile
{
    class MapDocument
    {
        string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        Map _map;
        public Map Map
        {
            get { return _map; }
            set { _map = value; }
        }

        TileSheet _tileSheet;
        public TileSheet TileSheet
        {
            get { return _tileSheet; }
            set { _tileSheet = value; }
        }
        // END OF GETTERS - SETTERS

        public MapDocument(string name)
        {
            _tileSheet = null;
            _map = null;
            _fileName = name;
        }

        public MapDocument()
        {
            _tileSheet = null;
            _map = null;
            _fileName = null;
        }

        public MapDocument(string name, Map map, TileSheet sheet)
        {
            _tileSheet = sheet;
            _map = map;
            _fileName = name;
        }
    }
}
