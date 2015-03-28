namespace AlbumSorter.View
{
    using AlbumSorter.FileSystemHandler;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    public class MainForm : Form, IMainForm
    {
        private readonly IFileSystemHandler _fileSystemHandler;
        private string _folderNameToCreate;
        private string _photoDirectoryPath;
        private PicEnum _picEnumerator;
        private IEnumerable<string> _pictures;
        private int _totalLeft = 0;
        private int _totalMoved = 0;
        private Button btnBrowse;
        private Button btnLoad;
        private IContainer components = null;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label13;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label lblCamera;
        private Label lblDate;
        private Label lblFileName;
        private Label lblFilePath;
        private Label lblStatus;
        private PictureBox picBox;
        private TextBox txtFolderName;
        private TextBox txtLeft;
        private TextBox txtMoved;
        private TextBox txtPhotosFolder;
        private TextBox txtShowing;
        private TextBox txtTotal;

        public MainForm(IFileSystemHandler fileSystemHandler)
        {
            this._fileSystemHandler = fileSystemHandler;
            this.InitializeComponent();
            this.picBox.KeyDown += new KeyEventHandler(this.OnPicBoxKeyDown);
            this.picBox.KeyPress += new KeyPressEventHandler(this.OnKeyPress);
            base.WindowState = FormWindowState.Maximized;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Image GetCopyImage(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }
            using (Image image = Image.FromFile(path))
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                string date = encoding.GetString(image.PropertyItems[15].Value);
                string camera = encoding.GetString(image.PropertyItems[1].Value);
                this.UpdateFileInfo(path, date, camera);
                return new Bitmap(image);
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(MainForm));
            this.label1 = new Label();
            this.txtPhotosFolder = new TextBox();
            this.btnBrowse = new Button();
            this.label2 = new Label();
            this.txtFolderName = new TextBox();
            this.btnLoad = new Button();
            this.groupBox1 = new GroupBox();
            this.groupBox2 = new GroupBox();
            this.picBox = new PictureBox();
            this.groupBox3 = new GroupBox();
            this.txtShowing = new TextBox();
            this.txtLeft = new TextBox();
            this.txtTotal = new TextBox();
            this.txtMoved = new TextBox();
            this.label6 = new Label();
            this.label5 = new Label();
            this.label4 = new Label();
            this.label3 = new Label();
            this.label7 = new Label();
            this.lblStatus = new Label();
            this.groupBox4 = new GroupBox();
            this.lblCamera = new Label();
            this.label10 = new Label();
            this.lblDate = new Label();
            this.label13 = new Label();
            this.lblFilePath = new Label();
            this.label11 = new Label();
            this.lblFileName = new Label();
            this.label8 = new Label();
            this.groupBox2.SuspendLayout();
            ((ISupportInitialize) this.picBox).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(20, 0x25);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x4a, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Photos Path : ";
            this.txtPhotosFolder.Location = new Point(0x77, 0x21);
            this.txtPhotosFolder.Name = "txtPhotosFolder";
            this.txtPhotosFolder.Size = new Size(0xc6, 20);
            this.txtPhotosFolder.TabIndex = 1;
            this.btnBrowse.Location = new Point(0x14c, 0x1f);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new Size(30, 0x17);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new EventHandler(this.OnBrowseClick);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(20, 70);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x5c, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Folder To Create :";
            this.txtFolderName.Location = new Point(0x77, 0x44);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new Size(0xc6, 20);
            this.txtFolderName.TabIndex = 4;
            this.btnLoad.Location = new Point(0xb5, 0x62);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new Size(0x4b, 0x17);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new EventHandler(this.OnLoadClick);
            this.groupBox1.Location = new Point(13, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x167, 0x79);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            this.groupBox2.Controls.Add(this.picBox);
            this.groupBox2.Location = new Point(13, 0xa5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x44f, 0x217);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image";
            this.picBox.Location = new Point(10, 0x13);
            this.picBox.Name = "picBox";
            this.picBox.Size = new Size(0x436, 510);
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            this.groupBox3.Controls.Add(this.txtShowing);
            this.groupBox3.Controls.Add(this.txtLeft);
            this.groupBox3.Controls.Add(this.txtTotal);
            this.groupBox3.Controls.Add(this.txtMoved);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new Point(0x17b, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(240, 0x79);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Summary";
            this.txtShowing.Location = new Point(0x49, 0x60);
            this.txtShowing.Name = "txtShowing";
            this.txtShowing.Size = new Size(0x2d, 20);
            this.txtShowing.TabIndex = 4;
            this.txtLeft.Location = new Point(0x49, 0x48);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.Size = new Size(0x2d, 20);
            this.txtLeft.TabIndex = 3;
            this.txtTotal.Location = new Point(0x49, 0x17);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new Size(0x2d, 20);
            this.txtTotal.TabIndex = 2;
            this.txtMoved.Location = new Point(0x49, 0x2f);
            this.txtMoved.Name = "txtMoved";
            this.txtMoved.Size = new Size(0x2d, 20);
            this.txtMoved.TabIndex = 1;
            this.label6.AutoSize = true;
            this.label6.Location = new Point(7, 0x63);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x39, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Showing : ";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(7, 0x4b);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x22, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Left : ";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(7, 50);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x2e, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Moved :";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(7, 0x1b);
            this.label3.Name = "label3";
            this.label3.Size = new Size(40, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total : ";
            this.label7.AutoSize = true;
            this.label7.Location = new Point(13, 0x92);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x2e, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Status : ";
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new Point(0x42, 0x92);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(0x2e, 13);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = ".............";
            this.groupBox4.Controls.Add(this.lblCamera);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.lblDate);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.lblFilePath);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.lblFileName);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new Point(0x277, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(0x1e5, 0x79);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "File Info";
            this.lblCamera.AutoSize = true;
            this.lblCamera.Location = new Point(0x49, 0x63);
            this.lblCamera.Name = "lblCamera";
            this.lblCamera.Size = new Size(0x19, 13);
            this.lblCamera.TabIndex = 7;
            this.lblCamera.Text = "......";
            this.label10.AutoSize = true;
            this.label10.Location = new Point(7, 0x63);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x34, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Camera  :";
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new Point(0x49, 0x4b);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new Size(0x19, 13);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "......";
            this.label13.AutoSize = true;
            this.label13.Location = new Point(7, 0x4b);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x27, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Date  :";
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new Point(0x49, 50);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new Size(0x19, 13);
            this.lblFilePath.TabIndex = 3;
            this.lblFilePath.Text = "......";
            this.label11.AutoSize = true;
            this.label11.Location = new Point(7, 50);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x39, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "File Path : ";
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new Point(0x49, 0x1b);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new Size(0x19, 13);
            this.lblFileName.TabIndex = 1;
            this.lblFileName.Text = "......";
            this.label8.AutoSize = true;
            this.label8.Location = new Point(7, 0x1b);
            this.label8.Name = "label8";
            this.label8.Size = new Size(60, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "File Name :";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x47e, 0x2ca);
            base.Controls.Add(this.groupBox4);
            base.Controls.Add(this.lblStatus);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.btnLoad);
            base.Controls.Add(this.txtFolderName);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.btnBrowse);
            base.Controls.Add(this.txtPhotosFolder);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.groupBox1);
            base.Name = "MainForm";
            this.Text = "Album Sorter";
            this.groupBox2.ResumeLayout(false);
            ((ISupportInitialize) this.picBox).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void LoadNext()
        {
            if (this._picEnumerator.MoveNext())
            {
                try
                {
                    this.picBox.Image = this.GetCopyImage(this._picEnumerator.Current);
                    this.UpdateSummary();
                    this.MoveToDestination(this._picEnumerator.Current);
                }
                catch (Exception)
                {
                    this.lblStatus.Text = "Opearation Not Supported";
                }
            }
            else
            {
                this.lblStatus.Text = "Reached End Of List";
            }
        }

        private void LoadPrevious()
        {
            if (this._picEnumerator.MovePrevious())
            {
                Image copyImage;
                do
                {
                    copyImage = this.GetCopyImage(this._picEnumerator.Current);
                }
                while ((copyImage != null) && this._picEnumerator.MovePrevious());
                this.picBox.Image = copyImage;
                this.UpdateSummary();
            }
            else
            {
                this.lblStatus.Text = "Reached Beginning Of List";
            }
        }

        private void MoveToDestination(string currentFileInfo)
        {
            this._totalLeft--;
            this._totalMoved++;
            this.UpdateSummary();
            this._fileSystemHandler.MoveToDestination(currentFileInfo, this._folderNameToCreate);
        }

        private void OnBrowseClick(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog {
                Description = "Select Photos Folder"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.txtPhotosFolder.Text = dialog.SelectedPath;
            }
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void OnLoadClick(object sender, EventArgs e)
        {
            this._photoDirectoryPath = this.txtPhotosFolder.Text;
            this._folderNameToCreate = this.txtFolderName.Text;
            this._fileSystemHandler.Initialize(this._photoDirectoryPath);
            this._fileSystemHandler.CreateFolder(this._folderNameToCreate);
            this._pictures = this._fileSystemHandler.GetAllImagePaths();
            this._picEnumerator = new PicEnum(this._pictures.ToArray<string>());
            this._picEnumerator.Reset();
            this.picBox.Focus();
            this.picBox.SizeMode = PictureBoxSizeMode.Zoom;
            if (this._pictures.Count<string>() == 0)
            {
                this.lblStatus.Text = "No Pictures";
            }
            else
            {
                this.picBox.Image = this.GetCopyImage(this._picEnumerator.Current);
                this._totalLeft = this._pictures.Count<string>();
                this.txtTotal.Text = this._pictures.Count<string>().ToString();
                this.UpdateSummary();
            }
        }

        private void OnPicBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                this.LoadNext();
            }
            if (e.KeyCode == Keys.Up)
            {
                if (this._picEnumerator.GetPosition() == -1)
                {
                    this.lblStatus.Text = "Cannot move current picture";
                    return;
                }
                string current = this._picEnumerator.Current;
                this.LoadNext();
            }
            if (e.KeyCode == Keys.Left)
            {
                this.LoadPrevious();
            }
        }

        private void UpdateFileInfo(string fileName, string date, string camera)
        {
            FileInfo info = new FileInfo(fileName);
            this.lblFileName.Text = info.Name;
            this.lblFilePath.Text = info.FullName;
            this.lblDate.Text = date;
            this.lblCamera.Text = camera;
        }

        private void UpdateSummary()
        {
            this.txtLeft.Text = this._totalLeft.ToString();
            this.txtMoved.Text = this._totalMoved.ToString();
            this.txtShowing.Text = (this._picEnumerator.GetPosition() + 1).ToString();
            this.lblStatus.Text = string.Format("Showing {0} of {1}", this.txtShowing.Text, this.txtTotal.Text);
        }
    }
}

