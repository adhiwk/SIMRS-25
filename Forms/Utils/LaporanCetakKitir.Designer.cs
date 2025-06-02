
namespace SIMRS25.Forms.Utils
{
    partial class LaporanCetakKitir
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
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            btnClose = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            CrViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(btnClose);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            layoutControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            layoutControl1.Margin = new Padding(4, 3, 4, 3);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(855, 189, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(915, 647);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // btnClose
            // 
            btnClose.ImageOptions.Image = Properties.Resources.close_window24;
            btnClose.Location = new Point(821, 6);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(88, 34);
            btnClose.StyleController = layoutControl1;
            btnClose.TabIndex = 6;
            btnClose.Text = "Tutup";
            btnClose.Click += btnClose_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, emptySpaceItem2, layoutControlItem2 });
            Root.Name = "Root";
            Root.Size = new Size(915, 647);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = btnClose;
            layoutControlItem1.Location = new Point(815, 0);
            layoutControlItem1.MaxSize = new Size(100, 46);
            layoutControlItem1.MinSize = new Size(100, 46);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(100, 46);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.Location = new Point(0, 0);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new Size(815, 46);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Location = new Point(0, 46);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(915, 601);
            layoutControlItem2.TextVisible = false;
            // CrViewer
            // 
            CrViewer.ActiveViewIndex = -1;
            CrViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            CrViewer.Cursor = System.Windows.Forms.Cursors.Default;
            CrViewer.Location = new System.Drawing.Point(5, 45);
            CrViewer.Margin = new System.Windows.Forms.Padding(2);
            CrViewer.Name = "CrViewer";
            CrViewer.Size = new System.Drawing.Size(774, 511);
            CrViewer.TabIndex = 7;
            CrViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;


            // 
            // LaporanCetakKitir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 647);
            Controls.Add(layoutControl1);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LaporanCetakKitir";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cetak Kitir";
            Load += LaporanCetakKitir_Load;
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrViewer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}