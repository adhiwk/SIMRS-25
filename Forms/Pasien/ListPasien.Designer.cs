
namespace SIMRS25.Forms.Pasien
{
    partial class ListPasien
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            grdPasien = new Telerik.WinControls.UI.RadGridView();
            btnCariData = new DevExpress.XtraEditors.ButtonEdit();
            btnCetakGelang = new DevExpress.XtraEditors.SimpleButton();
            btnCetakLabel = new DevExpress.XtraEditors.SimpleButton();
            btnCetakKartu = new DevExpress.XtraEditors.SimpleButton();
            btnBatal = new DevExpress.XtraEditors.SimpleButton();
            btnTutup = new DevExpress.XtraEditors.SimpleButton();
            btnHapus = new DevExpress.XtraEditors.SimpleButton();
            btnUbah = new DevExpress.XtraEditors.SimpleButton();
            btnTambah = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdPasien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdPasien.MasterTemplate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCariData.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem10).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(grdPasien);
            layoutControl1.Controls.Add(btnCariData);
            layoutControl1.Controls.Add(btnCetakGelang);
            layoutControl1.Controls.Add(btnCetakLabel);
            layoutControl1.Controls.Add(btnCetakKartu);
            layoutControl1.Controls.Add(btnBatal);
            layoutControl1.Controls.Add(btnTutup);
            layoutControl1.Controls.Add(btnHapus);
            layoutControl1.Controls.Add(btnUbah);
            layoutControl1.Controls.Add(btnTambah);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            layoutControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            layoutControl1.Margin = new Padding(4, 3, 4, 3);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(886, 306, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(1304, 654);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // grdPasien
            // 
            grdPasien.BackColor = SystemColors.Control;
            grdPasien.Font = new Font("Segoe UI", 8.25F);
            grdPasien.ForeColor = Color.Black;
            grdPasien.ImeMode = ImeMode.NoControl;
            grdPasien.Location = new Point(6, 84);
            // 
            // 
            // 
            grdPasien.MasterTemplate.AllowAddNewRow = false;
            grdPasien.MasterTemplate.AllowEditRow = false;
            grdPasien.MasterTemplate.ViewDefinition = tableViewDefinition1;
            grdPasien.Name = "grdPasien";
            grdPasien.RightToLeft = RightToLeft.No;
            grdPasien.ShowGroupPanel = false;
            grdPasien.Size = new Size(1292, 564);
            grdPasien.TabIndex = 47;
            grdPasien.Click += grdPasien_Click;
            grdPasien.KeyDown += GrdPasien_KeyDown;
            // 
            // btnCariData
            // 
            btnCariData.EnterMoveNextControl = true;
            btnCariData.Location = new Point(57, 52);
            btnCariData.Margin = new Padding(4, 3, 4, 3);
            btnCariData.Name = "btnCariData";
            btnCariData.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search) });
            btnCariData.Size = new Size(1241, 20);
            btnCariData.StyleController = layoutControl1;
            btnCariData.TabIndex = 46;
            btnCariData.KeyPress += BtnCariData_KeyPress;
            // 
            // btnCetakGelang
            // 
            btnCetakGelang.Location = new Point(774, 6);
            btnCetakGelang.Margin = new Padding(4, 3, 4, 3);
            btnCetakGelang.Name = "btnCetakGelang";
            btnCetakGelang.Size = new Size(116, 34);
            btnCetakGelang.StyleController = layoutControl1;
            btnCetakGelang.TabIndex = 45;
            btnCetakGelang.Text = "Cetak Gelang";
            btnCetakGelang.Click += BtnCetakGelang_Click;
            // 
            // btnCetakLabel
            // 
            btnCetakLabel.Location = new Point(646, 6);
            btnCetakLabel.Margin = new Padding(2);
            btnCetakLabel.Name = "btnCetakLabel";
            btnCetakLabel.Size = new Size(116, 34);
            btnCetakLabel.StyleController = layoutControl1;
            btnCetakLabel.TabIndex = 44;
            btnCetakLabel.Text = "Cetak Label";
            btnCetakLabel.Click += BtnCetakLabel_Click;
            // 
            // btnCetakKartu
            // 
            btnCetakKartu.Location = new Point(518, 6);
            btnCetakKartu.Margin = new Padding(2);
            btnCetakKartu.Name = "btnCetakKartu";
            btnCetakKartu.Size = new Size(116, 34);
            btnCetakKartu.StyleController = layoutControl1;
            btnCetakKartu.TabIndex = 43;
            btnCetakKartu.Text = "Cetak Kartu";
            btnCetakKartu.Click += BtnCetakKartu_Click;
            // 
            // btnBatal
            // 
            btnBatal.ImageOptions.Image = Properties.Resources.undo24;
            btnBatal.Location = new Point(390, 6);
            btnBatal.Margin = new Padding(4, 3, 4, 3);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(116, 34);
            btnBatal.StyleController = layoutControl1;
            btnBatal.TabIndex = 42;
            btnBatal.Text = "&Batal";
            btnBatal.Click += btnBatal_Click;
            // 
            // btnTutup
            // 
            btnTutup.ImageOptions.Image = Properties.Resources.close_window24;
            btnTutup.Location = new Point(902, 6);
            btnTutup.Margin = new Padding(4, 3, 4, 3);
            btnTutup.Name = "btnTutup";
            btnTutup.Size = new Size(116, 34);
            btnTutup.StyleController = layoutControl1;
            btnTutup.TabIndex = 41;
            btnTutup.Text = "T&utup";
            btnTutup.Click += BtnTutup_Click;
            // 
            // btnHapus
            // 
            btnHapus.ImageOptions.Image = Properties.Resources.delete_data24;
            btnHapus.Location = new Point(262, 6);
            btnHapus.Margin = new Padding(4, 3, 4, 3);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(116, 34);
            btnHapus.StyleController = layoutControl1;
            btnHapus.TabIndex = 40;
            btnHapus.Text = "&Hapus";
            btnHapus.Click += btnHapus_Click;
            // 
            // btnUbah
            // 
            btnUbah.ImageOptions.Image = Properties.Resources.data_edit24;
            btnUbah.Location = new Point(134, 6);
            btnUbah.Margin = new Padding(4, 3, 4, 3);
            btnUbah.Name = "btnUbah";
            btnUbah.Size = new Size(116, 34);
            btnUbah.StyleController = layoutControl1;
            btnUbah.TabIndex = 39;
            btnUbah.Text = "&Ubah";
            btnUbah.Click += BtnUbah_Click;
            // 
            // btnTambah
            // 
            btnTambah.ImageOptions.Image = Properties.Resources.add_file24;
            btnTambah.Location = new Point(6, 6);
            btnTambah.Margin = new Padding(4, 3, 4, 3);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(116, 34);
            btnTambah.StyleController = layoutControl1;
            btnTambah.TabIndex = 38;
            btnTambah.Text = "&Tambah";
            btnTambah.Click += BtnTambah_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem5, layoutControlItem4, layoutControlItem3, layoutControlItem2, emptySpaceItem2, layoutControlItem8, layoutControlItem7, layoutControlItem6, layoutControlItem9, layoutControlItem10 });
            Root.Name = "Root";
            Root.Size = new Size(1304, 654);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = btnBatal;
            layoutControlItem1.Location = new Point(384, 0);
            layoutControlItem1.MaxSize = new Size(128, 46);
            layoutControlItem1.MinSize = new Size(128, 46);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(128, 46);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = btnTambah;
            layoutControlItem5.Location = new Point(0, 0);
            layoutControlItem5.MaxSize = new Size(128, 46);
            layoutControlItem5.MinSize = new Size(128, 46);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new Size(128, 46);
            layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = btnUbah;
            layoutControlItem4.Location = new Point(128, 0);
            layoutControlItem4.MaxSize = new Size(128, 46);
            layoutControlItem4.MinSize = new Size(128, 46);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(128, 46);
            layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = btnHapus;
            layoutControlItem3.Location = new Point(256, 0);
            layoutControlItem3.MaxSize = new Size(128, 46);
            layoutControlItem3.MinSize = new Size(128, 46);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(128, 46);
            layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = btnTutup;
            layoutControlItem2.Location = new Point(896, 0);
            layoutControlItem2.MaxSize = new Size(128, 46);
            layoutControlItem2.MinSize = new Size(128, 46);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(128, 46);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.Location = new Point(1024, 0);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new Size(280, 46);
            // 
            // layoutControlItem8
            // 
            layoutControlItem8.Control = btnCetakKartu;
            layoutControlItem8.Location = new Point(512, 0);
            layoutControlItem8.MaxSize = new Size(128, 46);
            layoutControlItem8.MinSize = new Size(128, 46);
            layoutControlItem8.Name = "layoutControlItem8";
            layoutControlItem8.Size = new Size(128, 46);
            layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.Control = btnCetakLabel;
            layoutControlItem7.Location = new Point(640, 0);
            layoutControlItem7.MaxSize = new Size(128, 46);
            layoutControlItem7.MinSize = new Size(128, 46);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.Size = new Size(128, 46);
            layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = btnCetakGelang;
            layoutControlItem6.Location = new Point(768, 0);
            layoutControlItem6.MaxSize = new Size(128, 46);
            layoutControlItem6.MinSize = new Size(128, 46);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new Size(128, 46);
            layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            layoutControlItem9.Control = btnCariData;
            layoutControlItem9.Location = new Point(0, 46);
            layoutControlItem9.Name = "layoutControlItem9";
            layoutControlItem9.Size = new Size(1304, 32);
            layoutControlItem9.Text = "Cari Data";
            layoutControlItem9.TextSize = new Size(45, 13);
            // 
            // layoutControlItem10
            // 
            layoutControlItem10.Control = grdPasien;
            layoutControlItem10.Location = new Point(0, 78);
            layoutControlItem10.Name = "layoutControlItem10";
            layoutControlItem10.Size = new Size(1304, 576);
            layoutControlItem10.TextVisible = false;
            // 
            // ListPasien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1304, 654);
            Controls.Add(layoutControl1);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ListPasien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "List Data Pasien";
            Activated += ListPasien_Activated;
            Load += ListPasien_Load;
            Shown += ListPasien_Shown;
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdPasien.MasterTemplate).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdPasien).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCariData.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem10).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btnBatal;
        private DevExpress.XtraEditors.SimpleButton btnTutup;
        private DevExpress.XtraEditors.SimpleButton btnHapus;
        private DevExpress.XtraEditors.SimpleButton btnUbah;
        private DevExpress.XtraEditors.SimpleButton btnTambah;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.SimpleButton btnCetakGelang;
        private DevExpress.XtraEditors.SimpleButton btnCetakLabel;
        private DevExpress.XtraEditors.SimpleButton btnCetakKartu;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private Telerik.WinControls.UI.RadGridView grdPasien;
        private DevExpress.XtraEditors.ButtonEdit btnCariData;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashManager;
    }
}