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
        Bitmap _imageCopy;

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
                button1.Enabled = true;
                button2.Enabled = true;
                pictureBox2.Size = new Size(mapDialog.MapWidth * mapDialog.TileWidth, // WIDTH
                                            mapDialog.MapHeight * mapDialog.TileHeight); // HEIGHT
                newTileSet.Enabled = true;
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
        {
            // TODO, SAME THING AS ONCLICK BUT REFRESHES ONMOVE
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

                _g2.DrawImage(_selectedTile, x1, y1);
                //_imageCopy = new Bitmap(pictureBox2.Image);
                //_mapImage.Add(new CoordAndImage(_selectedTile, x1, y1)); HERE FOR REDRAW ISSUE
                //MB.Avertir(x1.ToString() + "-" + y1.ToString());
                _mapDocument.GetLayers()[listBox1.SelectedIndex].GetTile(x1 / _mapDocument.TileSheet.TileWidth, y1
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

            Rectangle rectangle = new Rectangle(0, 0, 32, 32);
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(100, 255, 0, 0));
            e.Graphics.FillRectangle(solidBrush, rectangle);
            e.Graphics.DrawImageUnscaled(_selectedTile, 0, 0);
        }

        private void AddLayer_Click(object sender, EventArgs e)
        {
            Prompt promptLayerName = new Prompt("New layer name: ", "New layer");
            promptLayerName.ShowDialog();
            if (promptLayerName.DialogResult == DialogResult.OK)
            {
                if (!pictureBox2.Enabled)
                    pictureBox2.Enabled = true;

                button2.Enabled = true;
                _mapDocument.AddLayer(promptLayerName.PromptValue);
                listBox1.DataSource = null;
                listBox1.DataSource = _mapDocument.GetLayers();
                //listBox1.Items.Add(_mapDocument.GetLayers()[_mapDocument.GetLayers().Count-1]);
            }
        }

        private void RemoveLayer_Click(object sender, EventArgs e)
        {
            _mapDocument.RemoveLayer(listBox1.SelectedIndex);
            listBox1.DataSource = null;
            listBox1.DataSource = _mapDocument.GetLayers();
            //listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            if (_mapDocument.GetLayers().Count == 0)
            {
                pictureBox2.Enabled = false;
                button2.Enabled = false;
            }
        }
    }
}
