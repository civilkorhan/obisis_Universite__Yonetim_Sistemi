using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace obisis
{
    public partial class frm_giris : Form
    {
        public frm_giris()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frm_Ogrenci_Notlar fr=new frm_Ogrenci_Notlar();
            fr.numara = textBox1.Text;
            fr.Show();
        }

        private void frm_giris_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frm_personel_islem fr=new frm_personel_islem();
            fr.Show();
        }
    }
}
