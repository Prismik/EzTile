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
        List<Map> openedMaps = new List<Map>();
        TileSheet _tileSheet = null;
        Graphics g = null;
        Graphics g2 = null;
        Bitmap _selectedTile = null;
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

        private void toolOpen_Click(object sender, EventArgs e)
        {

        }

        private void NewMap()
        {
            newMap mapDialog = new newMap();
            mapDialog.ShowDialog();
            if (mapDialog.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                openedMaps.Add(new Map(mapDialog.MapWidth, mapDialog.MapHeight,
                                        mapDialog.TileWidth, mapDialog.TileHeight));
                pictureBox2.BackColor = Color.LightSkyBlue;
                pictureBox2.Enabled = true;
                pictureBox2.Size = new Size(mapDialog.MapWidth * mapDialog.TileWidth, // WIDTH
                                            mapDialog.MapHeight * mapDialog.TileHeight); // HEIGHT
            }
        }

        private void SaveMap()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveDialog.Title = "Save a map file";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveDialog.FileName != "")
                {
                    // Saves the Image via a FileStream created by the OpenFile method.
                    System.IO.FileStream fs =
                     (System.IO.FileStream)saveDialog.OpenFile();
                    string testString = openedMaps[0].GetMapArray();
                    fs.Write(UnicodeEncoding.Unicode.GetBytes(testString),
                                0, UnicodeEncoding.Unicode.GetByteCount(testString));
                    fs.Close();
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
                pictureBox1.Width = newTilesheetDialog.TileSheet.Width;
                pictureBox1.Height = newTilesheetDialog.TileSheet.Height;
                pictureBox1.Image = newTilesheetDialog.TileSheet;
                _tileSheet = new TileSheet(newTilesheetDialog.FileName, newTilesheetDialog.TileSheet,
                                            newTilesheetDialog.TileWidth, newTilesheetDialog.TileHeight);
                g = pictureBox1.CreateGraphics();
                g2 = pictureBox2.CreateGraphics();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {/*
            if (pictureBox1.Image != null)
            {
                if (e.X < 0 || e.Y < 0)
                    return;

                int x1, x2, y1, y2;
                x1 = (e.X / _tileSheet.TileWidth) * e.X;
                x2 = x1 + _tileSheet.TileWidth;
                y1 = (e.Y / _tileSheet.TileHeight) * e.Y;
                y2 = y1 + _tileSheet.TileHeight;
               // MB.Avertir("{" + x1.ToString() + "," + y1.ToString() + "} - {" + x2.ToString() + "," + y2.ToString() + "}");
                using (Pen myPen = new Pen(Color.Black, 1))
                {
                    g.DrawRectangle(myPen, new Rectangle(x1, y1, x2, y2));
                    
                }
            }*/
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            pictureBox1.Refresh();
            if (pictureBox1.Image != null)
            {
                if (e.X < 0 || e.Y < 0)
                    return;

                int x1, x2, y1, y2;
                x1 = (e.X - e.X % _tileSheet.TileWidth);
                x2 = x1 + _tileSheet.TileWidth;
                y1 = (e.Y - e.Y % _tileSheet.TileHeight);
                y2 = y1 + _tileSheet.TileHeight;
                //MB.Avertir("{" + x1.ToString() + "," + y1.ToString() + "} - {" + x2.ToString() + "," + y2.ToString() + "}");
                using (Pen myPen = new Pen(Color.Black, 1))
                {
                    Rectangle rectangle = new Rectangle(x1, y1, x2 - x1, y2 - y1);
                    SolidBrush solidBrush = new SolidBrush(Color.FromArgb(100, 255, 0, 0 ));
                    g.FillRectangle(solidBrush, rectangle );
                    //g.DrawRectangle(myPen, rectangle);
                    _selectedTile = _tileSheet.Image.Clone(rectangle, _tileSheet.Image.PixelFormat);
                }
            }
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (_selectedTile != null)
            {
                int x1 = (e.X - e.X % _tileSheet.TileWidth);
                int y1 = (e.Y - e.Y % _tileSheet.TileHeight);
                g2.DrawImage(_selectedTile, x1, y1);
            }
        }
    }
}
