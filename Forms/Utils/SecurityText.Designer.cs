namespace SIMRS25.Forms.Utils
{
    partial class SecurityText
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
            txtDecryptResult = new TextBox();
            txtToDecrypt = new TextBox();
            txtEncryptResult = new TextBox();
            txtToEncrypt = new TextBox();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(simpleButton1);
            layoutControl1.Controls.Add(txtDecryptResult);
            layoutControl1.Controls.Add(txtToDecrypt);
            layoutControl1.Controls.Add(txtEncryptResult);
            layoutControl1.Controls.Add(txtToEncrypt);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(710, 185, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(800, 450);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // txtDecryptResult
            // 
            txtDecryptResult.Location = new Point(12, 331);
            txtDecryptResult.Multiline = true;
            txtDecryptResult.Name = "txtDecryptResult";
            txtDecryptResult.Size = new Size(776, 75);
            txtDecryptResult.TabIndex = 7;
            // 
            // txtToDecrypt
            // 
            txtToDecrypt.Location = new Point(12, 236);
            txtToDecrypt.Multiline = true;
            txtToDecrypt.Name = "txtToDecrypt";
            txtToDecrypt.Size = new Size(776, 75);
            txtToDecrypt.TabIndex = 6;
            txtToDecrypt.KeyPress += txtToDecrypt_KeyPress;
            // 
            // txtEncryptResult
            // 
            txtEncryptResult.Location = new Point(12, 123);
            txtEncryptResult.Multiline = true;
            txtEncryptResult.Name = "txtEncryptResult";
            txtEncryptResult.Size = new Size(776, 75);
            txtEncryptResult.TabIndex = 5;
            // 
            // txtToEncrypt
            // 
            txtToEncrypt.Location = new Point(12, 28);
            txtToEncrypt.Multiline = true;
            txtToEncrypt.Name = "txtToEncrypt";
            txtToEncrypt.Size = new Size(776, 75);
            txtToEncrypt.TabIndex = 4;
            txtToEncrypt.KeyPress += txtToEncrypt_KeyPress;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, emptySpaceItem1, layoutControlItem2, simpleSeparator1, layoutControlItem3, layoutControlItem4, emptySpaceItem2, layoutControlItem5 });
            Root.Name = "Root";
            Root.Size = new Size(800, 450);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = txtToEncrypt;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.MaxSize = new Size(780, 95);
            layoutControlItem1.MinSize = new Size(780, 95);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(780, 95);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.Text = "Text To Encrypt";
            layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem1.TextSize = new Size(78, 13);
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new Point(136, 398);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(644, 32);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = txtEncryptResult;
            layoutControlItem2.Location = new Point(0, 95);
            layoutControlItem2.MaxSize = new Size(780, 95);
            layoutControlItem2.MinSize = new Size(780, 95);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(780, 95);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.Text = "Encrypt Result";
            layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem2.TextSize = new Size(78, 13);
            // 
            // simpleSeparator1
            // 
            simpleSeparator1.Location = new Point(0, 190);
            simpleSeparator1.Name = "simpleSeparator1";
            simpleSeparator1.Size = new Size(780, 1);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = txtToDecrypt;
            layoutControlItem3.Location = new Point(0, 208);
            layoutControlItem3.MaxSize = new Size(780, 95);
            layoutControlItem3.MinSize = new Size(780, 95);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(780, 95);
            layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem3.Text = "Text To Decrypt";
            layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem3.TextSize = new Size(78, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = txtDecryptResult;
            layoutControlItem4.Location = new Point(0, 303);
            layoutControlItem4.MaxSize = new Size(780, 95);
            layoutControlItem4.MinSize = new Size(780, 95);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(780, 95);
            layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem4.Text = "Decrypt Result";
            layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem4.TextSize = new Size(78, 13);
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.Location = new Point(0, 191);
            emptySpaceItem2.MaxSize = new Size(780, 17);
            emptySpaceItem2.MinSize = new Size(780, 17);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new Size(780, 17);
            emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // simpleButton1
            // 
            simpleButton1.ImageOptions.Image = Properties.Resources.general_printer24;
            simpleButton1.Location = new Point(12, 410);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new Size(132, 28);
            simpleButton1.StyleController = layoutControl1;
            simpleButton1.TabIndex = 8;
            simpleButton1.Text = "simpleButton1";
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = simpleButton1;
            layoutControlItem5.Location = new Point(0, 398);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new Size(136, 32);
            layoutControlItem5.TextVisible = false;
            // 
            // SecurityText
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(layoutControl1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SecurityText";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SecurityText";
            Load += SecurityText_Load;
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private TextBox txtEncryptResult;
        private TextBox txtToEncrypt;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private TextBox txtDecryptResult;
        private TextBox txtToDecrypt;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}