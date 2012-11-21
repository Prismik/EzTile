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
        List<MapDocument> _mapDocuments;
        Graphics _g = null;
        Bitmap _selectedTile = null;
        int _selectedTileId = -1;

        public mainWindow()
        {
            InitializeComponent();
            _mapDocuments = new List<MapDocument>();
            saveAsToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            toolSave.Enabled = false;
            //pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
            //krbTabControl1.TabIndexChanged += new EventHandler(tabChange);
            krbTabControl1.TabPageClosing += new EventHandler<KRBTabControl.KRBTabControl.SelectedIndexChangingEventArgs>(tabClose);
        }

        private void tabChange(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.DataSource = _mapDocuments[this.krbTabControl1.SelectedIndex].GetLayers();
            _selectedTile = null;
        }

        private void tabClose(object sender, EventArgs e)
        {
            if (krbTabControl1.TabCount == 1)
            {
                saveAsToolStripMenuItem.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
                toolSave.Enabled = false;
            }
            else
            {
                listBox1.DataSource = null;
                listBox1.DataSource = _mapDocuments[this.krbTabControl1.SelectedIndex].GetLayers();
            }
            // CLOSE WITHOUT SAVING ? YES - NO
            //if (!MB.ConfirmerOuiNon("Close without saving ?"))
                //SaveMap();
            _mapDocuments.RemoveAt(krbTabControl1.SelectedIndex);
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
            if (_mapDocuments[this.krbTabControl1.SelectedIndex].FileName == null)
                SaveAs();
            else
                SaveMap();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_mapDocuments[this.krbTabControl1.SelectedIndex].FileName == null)
                SaveAs();
            else
                SaveMap();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
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
                _mapDocuments.Add(new MapDocument(mapDialog.MapWidth, mapDialog.MapHeight,
                                        mapDialog.TileWidth, mapDialog.TileHeight));

                button1.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                toolSave.Enabled = true;
                newTileSet.Enabled = true;

                // CREATE THE KRB TAB
                KRBTabControl.TabPageEx newTabPage = new KRBTabControl.TabPageEx();
                newTabPage.Text = "Untitled";
                newTabPage.ImageIndex = 2;
                krbTabControl1.TabPages.Add(newTabPage);

                PictureBox newPictureBox = new PictureBox();
                newPictureBox.Size = new Size(mapDialog.MapWidth * mapDialog.TileWidth, // WIDTH
                                            mapDialog.MapHeight * mapDialog.TileHeight); // HEIGHT
                newPictureBox.Location = new Point(0, 0);
                newPictureBox.BackColor = Color.LightSkyBlue;
                newPictureBox.Name = "pictureBox";
                newPictureBox.Paint += new PaintEventHandler(pictureBox2_Paint);
                newPictureBox.MouseClick += new MouseEventHandler(pictureBox2_MouseClick);

                Label newLabel = new Label();
                newLabel.Text = newTabPage.Text;
                newLabel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold);
                newLabel.Location = new Point(10, 10);

                Panel newPanel = new Panel();
                newPanel.Controls.Add(newPictureBox);
                newPanel.Size = new Size(newTabPage.Size.Width - 20, newTabPage.Size.Height - 20);
                newPanel.Anchor = (AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top);
                newPanel.Location = new Point(10, 10);
                newPanel.AutoScroll = true;
                newPanel.Name = "panel";
                //newTabPage.Controls.Add(newLabel);
                newTabPage.Controls.Add(newPanel);
            }
        }

        private void SaveMap()
        {
            using (var stream = File.OpenWrite(_mapDocuments[this.krbTabControl1.SelectedIndex].FileName))
            {
                string nbLayers = _mapDocuments[this.krbTabControl1.SelectedIndex].GetLayers().Count.ToString() + '\n';
                stream.Write(UnicodeEncoding.Unicode.GetBytes(nbLayers),
                            0, UnicodeEncoding.Unicode.GetByteCount(nbLayers));
                foreach (Map map in _mapDocuments[this.krbTabControl1.SelectedIndex].GetLayers())
                {
                    string testString = map.StringFormat();
                    stream.Write(UnicodeEncoding.Unicode.GetBytes(testString),
                                0, UnicodeEncoding.Unicode.GetByteCount(testString));
                }
                if (_mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet != null)
                {
                    string TsName = _mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet.ImageName;
                    stream.Write(UnicodeEncoding.Unicode.GetBytes(TsName),
                                    0, UnicodeEncoding.Unicode.GetByteCount(TsName));
                }
                stream.Close();
            }
        }

        private void SaveAs()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "txt files (*.txt)|*.txt|game map document (*.gmd)|Xml (*.xml)|*.gmd|All files (*.*)|*.*";
            saveDialog.Title = "Save a map file";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveDialog.FileName != "")
                {
                    _mapDocuments[this.krbTabControl1.SelectedIndex].FileName = saveDialog.FileName;
                    // Saves the Image via a FileStream created by the OpenFile method.
                    System.IO.FileStream fs =
                        (System.IO.FileStream)saveDialog.OpenFile();
                    string nbLayers = _mapDocuments[this.krbTabControl1.SelectedIndex].GetLayers().Count.ToString() + '\n';
                    fs.Write(UnicodeEncoding.Unicode.GetBytes(nbLayers),
                                0, UnicodeEncoding.Unicode.GetByteCount(nbLayers));
                    foreach (Map map in _mapDocuments[this.krbTabControl1.SelectedIndex].GetLayers())
                    {
                        string testString = map.StringFormat();
                        fs.Write(UnicodeEncoding.Unicode.GetBytes(testString),
                                    0, UnicodeEncoding.Unicode.GetByteCount(testString));
                    }
                    if (_mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet != null)
                    {
                        string TsName = _mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet.ImageName;
                        fs.Write(UnicodeEncoding.Unicode.GetBytes(TsName),
                                        0, UnicodeEncoding.Unicode.GetByteCount(TsName));
                    }
                    fs.Close();
                    string[] file= saveDialog.FileName.Split('\\');
                    this.krbTabControl1.SelectedTab.Text = file[file.Length-1];
                    this.krbTabControl1.SelectedTab.Name = file[file.Length - 1];
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
                    foreach(MapDocument mdoc in _mapDocuments)
                        mdoc.TileSheet = new TileSheet(newTilesheetDialog.FileName, newTilesheetDialog.TileSheet,
                                                       newTilesheetDialog.ImageName, newTilesheetDialog.TileWidth, newTilesheetDialog.TileHeight);
                    _g = pictureBox1.CreateGraphics();
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
                x1 = (e.X - e.X % _mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet.TileWidth);
                x2 = x1 + _mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet.TileWidth;
                y1 = (e.Y - e.Y % _mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet.TileHeight);
                y2 = y1 + _mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet.TileHeight;
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
                    _selectedTile = _mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet.Image.Clone(rectangle, _mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet.Image.PixelFormat);
                    _selectedTileId = y1 / _mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet.TileHeight * (_mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet.Image.Width / _mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet.TileWidth)
                        + x2 / _mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet.TileWidth;
                }
            }
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (_selectedTile != null && listBox1.SelectedIndex >= 0)
            {
                int pictureBox2eX = (e.X - e.X % _mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet.TileWidth);
                int pictureBox2eY = (e.Y - e.Y % _mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet.TileHeight);
                //MB.Avertir(x1.ToString() + "-" + y1.ToString());
                _mapDocuments[this.krbTabControl1.SelectedIndex].GetLayers()[listBox1.SelectedIndex].GetTile(pictureBox2eX / _mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet.TileWidth, pictureBox2eY
                    / _mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet.TileHeight).TileID = _selectedTileId;
                this.krbTabControl1.SelectedTab.Controls["panel"].Controls["pictureBox"].Refresh();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (_selectedTile != null)
            {
                int x1, y1, x2, y2;
                x1 = (pictureBox1eX - pictureBox1eX % _mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet.TileWidth);
                x2 = x1 + _mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet.TileWidth;
                y1 = (pictureBox1eY - pictureBox1eY % _mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet.TileHeight);
                y2 = y1 + _mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet.TileHeight;
                Rectangle rectangle = new Rectangle(x1, y1, x2 - x1, y2 - y1);
                SolidBrush solidBrush = new SolidBrush(Color.FromArgb(100, 255, 0, 0));
                e.Graphics.FillRectangle(solidBrush, rectangle);
            }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (_selectedTile != null && listBox1.SelectedIndex >= 0)
            {
                int i= 0, j = 0;
                foreach (Map map in _mapDocuments[this.krbTabControl1.SelectedIndex].GetLayers())
                {
                    foreach (Tile[] array1 in map.GetMap())
                    {
                        foreach (Tile tile in array1)
                        {
                            if (tile.TileID != 0)
                                e.Graphics.DrawImage(_mapDocuments[this.krbTabControl1.SelectedIndex].TileSheet.GetTileFromId(tile.TileID), i * tile.Height, j * tile.Width);

                            i++;
                        }
                        j++;
                        i = 0;
                    }
                    j = 0;
                }
            }
        }

        private void AddLayer_Click(object sender, EventArgs e)
        {
            Prompt promptLayerName = new Prompt("New layer name: ", "New layer");
            promptLayerName.ShowDialog();
            if (promptLayerName.DialogResult == DialogResult.OK)
            {
                if (!this.krbTabControl1.SelectedTab.Controls["panel"].Controls["pictureBox"].Enabled)
                    this.krbTabControl1.SelectedTab.Controls["panel"].Controls["pictureBox"].Enabled = true;

                button2.Enabled = true;
                _mapDocuments[this.krbTabControl1.SelectedIndex].AddLayer(promptLayerName.PromptValue);
                listBox1.DataSource = null;
                listBox1.DataSource = _mapDocuments[this.krbTabControl1.SelectedIndex].GetLayers();
                //listBox1.Items.Add(_mapDocuments[this.krbTabControl1.SelectedIndex].GetLayers()[_mapDocuments[this.krbTabControl1.SelectedIndex].GetLayers().Count-1]);
            }
        }

        private void RemoveLayer_Click(object sender, EventArgs e)
        {
            if (_mapDocuments[this.krbTabControl1.SelectedIndex].GetLayers().Count != 0)
            {
                _mapDocuments[this.krbTabControl1.SelectedIndex].RemoveLayer(listBox1.SelectedIndex);
                this.krbTabControl1.SelectedTab.Controls["panel"].Controls["pictureBox"].Refresh();
                listBox1.DataSource = null;
                listBox1.DataSource = _mapDocuments[this.krbTabControl1.SelectedIndex].GetLayers();
                //listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }

            if (_mapDocuments[this.krbTabControl1.SelectedIndex].GetLayers().Count == 0)
            {
                this.krbTabControl1.SelectedTab.Controls["panel"].Controls["pictureBox"].Enabled = false;
                button2.Enabled = false;
            }
        }
    }
}
