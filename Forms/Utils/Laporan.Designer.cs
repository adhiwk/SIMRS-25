
namespace SIMRS25.Forms.Utils
{
    partial class Laporan
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
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(btnClose);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            layoutControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            layoutControl1.Margin = new Padding(2);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(886, 324, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(994, 675);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // btnClose
            // 
            btnClose.ImageOptions.Image = Properties.Resources.close_window24;
            btnClose.Location = new Point(900, 6);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(88, 34);
            btnClose.StyleController = layoutControl1;
            btnClose.TabIndex = 5;
            btnClose.Text = "Tutup";
            btnClose.Click += btnClose_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, emptySpaceItem1 });
            Root.Name = "Root";
            Root.Size = new Size(994, 675);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Location = new Point(0, 46);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(994, 629);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = btnClose;
            layoutControlItem2.Location = new Point(894, 0);
            layoutControlItem2.MaxSize = new Size(100, 46);
            layoutControlItem2.MinSize = new Size(100, 46);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(100, 46);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new Point(0, 0);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(894, 46);
            // 
            // Laporan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(994, 675);
            Controls.Add(layoutControl1);
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Laporan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Laporan";
            Load += Laporan_Load;
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrViewer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}