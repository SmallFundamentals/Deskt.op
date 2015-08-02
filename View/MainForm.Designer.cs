namespace Deskt.op.View
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.userWallpaperPictureBox = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.materialCheckBox1 = new MaterialSkin.Controls.MaterialCheckBox();
            this.saveSettingsButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.refreshIntervalTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.repoLabelButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.myLabel = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.saveFileIcon = new System.Windows.Forms.PictureBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.refreshWallpaperIcon = new System.Windows.Forms.PictureBox();
            this.materialTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userWallpaperPictureBox)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveFileIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshWallpaperIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Deskt.op";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(-1, 61);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(802, 34);
            this.materialTabSelector1.TabIndex = 2;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialTabControl
            // 
            this.materialTabControl.Controls.Add(this.tabPage1);
            this.materialTabControl.Controls.Add(this.tabPage2);
            this.materialTabControl.Controls.Add(this.tabPage3);
            this.materialTabControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.materialTabControl.Depth = 0;
            this.materialTabControl.Location = new System.Drawing.Point(0, 95);
            this.materialTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl.Name = "materialTabControl";
            this.materialTabControl.SelectedIndex = 0;
            this.materialTabControl.Size = new System.Drawing.Size(606, 310);
            this.materialTabControl.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.userWallpaperPictureBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(598, 284);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "My Wallpaper";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // userWallpaperPictureBox
            // 
            this.userWallpaperPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("userWallpaperPictureBox.Image")));
            this.userWallpaperPictureBox.Location = new System.Drawing.Point(-5, -28);
            this.userWallpaperPictureBox.Name = "userWallpaperPictureBox";
            this.userWallpaperPictureBox.Size = new System.Drawing.Size(607, 343);
            this.userWallpaperPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userWallpaperPictureBox.TabIndex = 0;
            this.userWallpaperPictureBox.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.materialCheckBox1);
            this.tabPage2.Controls.Add(this.saveSettingsButton);
            this.tabPage2.Controls.Add(this.materialLabel3);
            this.tabPage2.Controls.Add(this.materialLabel2);
            this.tabPage2.Controls.Add(this.refreshIntervalTextField);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(598, 284);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            // 
            // materialCheckBox1
            // 
            this.materialCheckBox1.AutoSize = true;
            this.materialCheckBox1.Depth = 0;
            this.materialCheckBox1.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckBox1.Location = new System.Drawing.Point(242, 151);
            this.materialCheckBox1.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBox1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckBox1.Name = "materialCheckBox1";
            this.materialCheckBox1.Ripple = true;
            this.materialCheckBox1.Size = new System.Drawing.Size(121, 30);
            this.materialCheckBox1.TabIndex = 6;
            this.materialCheckBox1.Text = "Run on Startup";
            this.materialCheckBox1.UseVisualStyleBackColor = true;
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveSettingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveSettingsButton.Depth = 0;
            this.saveSettingsButton.Location = new System.Drawing.Point(265, 227);
            this.saveSettingsButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Primary = true;
            this.saveSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.saveSettingsButton.TabIndex = 5;
            this.saveSettingsButton.Text = "SAVE";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(208, 111);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(99, 19);
            this.materialLabel3.TabIndex = 4;
            this.materialLabel3.Text = "Refresh every";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(357, 111);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(50, 19);
            this.materialLabel2.TabIndex = 3;
            this.materialLabel2.Text = "day(s)";
            // 
            // refreshIntervalTextField
            // 
            this.refreshIntervalTextField.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.refreshIntervalTextField.Depth = 0;
            this.refreshIntervalTextField.Hint = "   1";
            this.refreshIntervalTextField.Location = new System.Drawing.Point(313, 107);
            this.refreshIntervalTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.refreshIntervalTextField.Name = "refreshIntervalTextField";
            this.refreshIntervalTextField.Padding = new System.Windows.Forms.Padding(330, 330, 33, 0);
            this.refreshIntervalTextField.PasswordChar = '\0';
            this.refreshIntervalTextField.SelectedText = "";
            this.refreshIntervalTextField.SelectionLength = 0;
            this.refreshIntervalTextField.SelectionStart = 0;
            this.refreshIntervalTextField.Size = new System.Drawing.Size(38, 23);
            this.refreshIntervalTextField.TabIndex = 2;
            this.refreshIntervalTextField.UseSystemPasswordChar = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.repoLabelButton);
            this.tabPage3.Controls.Add(this.myLabel);
            this.tabPage3.Controls.Add(this.pictureBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(598, 284);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "About";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // repoLabelButton
            // 
            this.repoLabelButton.BackColor = System.Drawing.Color.Turquoise;
            this.repoLabelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.repoLabelButton.Depth = 0;
            this.repoLabelButton.Location = new System.Drawing.Point(-15, -4);
            this.repoLabelButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.repoLabelButton.Name = "repoLabelButton";
            this.repoLabelButton.Primary = true;
            this.repoLabelButton.Size = new System.Drawing.Size(627, 56);
            this.repoLabelButton.TabIndex = 4;
            this.repoLabelButton.Text = "BEAUTIFUL WALLPAPERS DELIVERED RIGHT TO YOUR DESKTOP.";
            this.repoLabelButton.UseVisualStyleBackColor = false;
            this.repoLabelButton.Click += new System.EventHandler(this.repoLabelButton_Click);
            // 
            // myLabel
            // 
            this.myLabel.AutoSize = true;
            this.myLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.myLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myLabel.Location = new System.Drawing.Point(95, 244);
            this.myLabel.Name = "myLabel";
            this.myLabel.Size = new System.Drawing.Size(417, 16);
            this.myLabel.TabIndex = 2;
            this.myLabel.Text = "Blake Yu is a 3rd year Software Engineering student at the University of Waterloo" +
    "";
            this.myLabel.Click += new System.EventHandler(this.myLabel_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(-15, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(627, 314);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // saveFileIcon
            // 
            this.saveFileIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveFileIcon.Image = ((System.Drawing.Image)(resources.GetObject("saveFileIcon.Image")));
            this.saveFileIcon.Location = new System.Drawing.Point(532, 65);
            this.saveFileIcon.Name = "saveFileIcon";
            this.saveFileIcon.Size = new System.Drawing.Size(24, 24);
            this.saveFileIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.saveFileIcon.TabIndex = 4;
            this.saveFileIcon.TabStop = false;
            this.saveFileIcon.Click += new System.EventHandler(this.saveFileIcon_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "deskt.op_wallpaper.bmp";
            // 
            // refreshWallpaperIcon
            // 
            this.refreshWallpaperIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refreshWallpaperIcon.Image = ((System.Drawing.Image)(resources.GetObject("refreshWallpaperIcon.Image")));
            this.refreshWallpaperIcon.Location = new System.Drawing.Point(564, 65);
            this.refreshWallpaperIcon.Name = "refreshWallpaperIcon";
            this.refreshWallpaperIcon.Size = new System.Drawing.Size(24, 24);
            this.refreshWallpaperIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.refreshWallpaperIcon.TabIndex = 5;
            this.refreshWallpaperIcon.TabStop = false;
            this.refreshWallpaperIcon.Click += new System.EventHandler(this.refreshWallpaperIcon_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.refreshWallpaperIcon);
            this.Controls.Add(this.saveFileIcon);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.materialTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Sizable = false;
            this.Text = "Deskt.op";
            this.materialTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userWallpaperPictureBox)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveFileIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshWallpaperIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox userWallpaperPictureBox;
        private System.Windows.Forms.PictureBox saveFileIcon;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.PictureBox refreshWallpaperIcon;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label myLabel;
        private MaterialSkin.Controls.MaterialRaisedButton repoLabelButton;
        private System.Windows.Forms.PictureBox pictureBox3;
        private MaterialSkin.Controls.MaterialSingleLineTextField refreshIntervalTextField;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialRaisedButton saveSettingsButton;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBox1;
    }
}