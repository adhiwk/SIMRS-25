using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIMRS25.Class;
namespace SIMRS25.Forms.Utils
{
    public partial class SecurityText : Form
    {
        public SecurityText()
        {
            InitializeComponent();
        }

        private void SecurityText_Load(object sender, EventArgs e)
        {
            txtToEncrypt.Text = "";
            txtEncryptResult.Text = "";
            txtToDecrypt.Text = "";
            txtDecryptResult.Text = "";
        }

        private void txtToEncrypt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                var enc = AesEncryptionService.CreateService();
                byte[] encryptedBytes = enc.Encrypt(txtToEncrypt.Text.Trim());
                string encryptedBase64 = Convert.ToBase64String(encryptedBytes);
                txtEncryptResult.Text = encryptedBase64;
            }
        }

        private void txtToDecrypt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                var dec = AesEncryptionService.CreateService();
                byte[] decryptedBytes = Convert.FromBase64String(txtToDecrypt.Text);
                string decryptedText = dec.Decrypt(decryptedBytes);
                txtDecryptResult.Text = decryptedText;
            }
        }
    }
}
