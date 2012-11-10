using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using UtilStJ;

namespace eztile
{
    public partial class mainWindow : Form
    {
        MapDocument _mapDocument;
        Graphics _g = null;
        Graphics _g2 = null;
        Bitmap _selectedTile = null;
        int _selectedTileId = -1;
        int _activeLayer = 0;
        List<CoordAndImage> _mapImage = new List<CoordAndImage>();

        public mainWindow()
        {
            InitializeComponent();
            pictureBox2.Enabled = false;
            pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewMap();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            NewMap();
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            SaveMap();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMap();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolOpen_Click(object sender, EventArgs e)
        {

        }

        private void OpenMap()
        {

        }

        private void NewMap()
        {
            newMap mapDialog = new newMap();
            mapDialog.ShowDialog();
            if (mapDialog.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                _mapDocument = new MapDocument(mapDialog.MapWidth, mapDialog.MapHeight,
                                        mapDialog.TileWidth, mapDialog.TileHeight);

                pictureBox2.BackColor = Color.LightSkyBlue;
                pictureBox2.Enabled = true;
                pictureBox2.Size = new Size(mapDialog.MapWidth * mapDialog.TileWidth, // WIDTH
                                            mapDialog.MapHeight * mapDialog.TileHeight); // HEIGHT
                this.newTileSet.Enabled = true;
            }
        }

        private void SaveMap()
        {
            if (_mapDocument.FileName == null)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveDialog.Title = "Save a map file";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    if (saveDialog.FileName != "")
                    {
                        _mapDocument.FileName = saveDialog.FileName;
                        // Saves the Image via a FileStream created by the OpenFile method.
                        System.IO.FileStream fs =
                            (System.IO.FileStream)saveDialog.OpenFile();
                        foreach (Map map in _mapDocument.GetLayers())
                        {
                            string testString = map.GetMapArray();
                            fs.Write(UnicodeEncoding.Unicode.GetBytes(testString),
                                        0, UnicodeEncoding.Unicode.GetByteCount(testString));
                        }
                        fs.Close();
                    }
                }
            }
            else
            {
                using (var stream = File.OpenWrite(_mapDocument.FileName))
                {
                    foreach (Map map in _mapDocument.GetLayers())
                    {
                        string testString = map.GetMapArray();
                        stream.Write(UnicodeEncoding.Unicode.GetBytes(testString),
                                    0, UnicodeEncoding.Unicode.GetByteCount(testString));
                    }
                    stream.Close();
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutDialog = new About();
            aboutDialog.ShowDialog();
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            newTileSheet newTilesheetDialog = new newTileSheet();
            newTilesheetDialog.ShowDialog();
            if (newTilesheetDialog.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (newTilesheetDialog.TileSheet == null)
                    MB.AvertirCritique("Could not find the specified image.");
                else
                {
                    pictureBox1.Width = newTilesheetDialog.TileSheet.Width;
                    pictureBox1.Height = newTilesheetDialog.TileSheet.Height;
                    pictureBox1.Image = newTilesheetDialog.TileSheet;
                    _mapDocument.TileSheet = new TileSheet(newTilesheetDialog.FileName, newTilesheetDialog.TileSheet,
                                                newTilesheetDialog.ImageName, newTilesheetDialog.TileWidth, newTilesheetDialog.TileHeight);
                    _g = pictureBox1.CreateGraphics();
                    _g2 = pictureBox2.CreateGraphics();
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {/*
            if (pictureBox1.Image != null)
            {
                if (e.X < 0 || e.Y < 0)
                    return;

                int x1, x2, y1, y2;
                x1 = (e.X / _mapDocument.TileSheet.TileWidth) * e.X;
                x2 = x1 + _mapDocument.TileSheet.TileWidth;
                y1 = (e.Y / _mapDocument.TileSheet.TileHeight) * e.Y;
                y2 = y1 + _mapDocument.TileSheet.TileHeight;
               // MB.Avertir("{" + x1.ToString() + "," + y1.ToString() + "} - {" + x2.ToString() + "," + y2.ToString() + "}");
                using (Pen myPen = new Pen(Color.Black, 1))
                {
                    _g.DrawRectangle(myPen, new Rectangle(x1, y1, x2, y2));
                    
                }
            }*/
        }

        int pictureBox1eX, pictureBox1eY; // For the redraw of the selected tile in pictureBox1
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox1eX = e.X;
            pictureBox1eY = e.Y;
            pictureBox1.Refresh();
            if (pictureBox1.Image != null)
            {
                if (e.X < 0 || e.Y < 0)
                    return;

                int x1, x2, y1, y2;
                x1 = (e.X - e.X % _mapDocument.TileSheet.TileWidth);
                x2 = x1 + _mapDocument.TileSheet.TileWidth;
                y1 = (e.Y - e.Y % _mapDocument.TileSheet.TileHeight);
                y2 = y1 + _mapDocument.TileSheet.TileHeight;
                //MB.Avertir("{" + x1.ToString() + "," + y1.ToString() + "} - {" + x2.ToString() + "," + y2.ToString() + "}");
                using (Pen myPen = new Pen(Color.Black, 1))
                {
                    Rectangle rectangle = new Rectangle(x1, y1, x2 - x1, y2 - y1);
                    if (_selectedTile == null)
                    {
                        SolidBrush solidBrush = new SolidBrush(Color.FromArgb(100, 255, 0, 0));
                        _g.FillRectangle(solidBrush, rectangle);
                    }
                    //_g.DrawRectangle(myPen, rectangle);
                    _selectedTile = _mapDocument.TileSheet.Image.Clone(rectangle, _mapDocument.TileSheet.Image.PixelFormat);
                    _selectedTileId = y1 / _mapDocument.TileSheet.TileHeight * (_mapDocument.TileSheet.Image.Width / _mapDocument.TileSheet.TileWidth)
                        + x2 / _mapDocument.TileSheet.TileWidth;
                }
            }
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (_selectedTile != null)
            {
                int x1 = (e.X - e.X % _mapDocument.TileSheet.TileWidth);
                int y1 = (e.Y - e.Y % _mapDocument.TileSheet.TileHeight);
                using (var br = new SolidBrush(Color.FromArgb(0, 255, 255, 255)))
                    _g2.FillRectangle(br, x1, y1, _selectedTile.Width, _selectedTile.Height);

                _g2.DrawImage(_selectedTile, x1, y1);
                //_mapImage.Add(new CoordAndImage(_selectedTile, x1, y1)); HERE FOR REDRAW ISSUE
                //MB.Avertir(x1.ToString() + "-" + y1.ToString());
                _mapDocument.GetLayers()[_activeLayer].GetTile(x1 / _mapDocument.TileSheet.TileWidth, y1
                    / _mapDocument.TileSheet.TileHeight).TileID = _selectedTileId;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (_selectedTile != null)
            {
                int x1, y1, x2, y2;
                x1 = (pictureBox1eX - pictureBox1eX % _mapDocument.TileSheet.TileWidth);
                x2 = x1 + _mapDocument.TileSheet.TileWidth;
                y1 = (pictureBox1eY - pictureBox1eY % _mapDocument.TileSheet.TileHeight);
                y2 = y1 + _mapDocument.TileSheet.TileHeight;
                Rectangle rectangle = new Rectangle(x1, y1, x2 - x1, y2 - y1);
                SolidBrush solidBrush = new SolidBrush(Color.FromArgb(100, 255, 0, 0));
                e.Graphics.FillRectangle(solidBrush, rectangle);
            }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            //foreach (CoordAndImage img in _mapImage)
             //   _g2.DrawImage(img.Image, img.X, img.Y);
        }

    }

    public class CoordAndImage
    {
        private Bitmap _img;
        public Bitmap Image
        {
            get { return _img; }
        }
        private int _x;
        public int X
        {
            get { return _x; }
        }
        private int _y;
        public int Y
        {
            get { return _y; }
        }

        public CoordAndImage(Bitmap img, int x, int y)
        {
            _img = img;
            _x = x;
            _y = y;
        }
    }
}
