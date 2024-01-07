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
    public partial class frm_personel_islem : Form
    {
        public frm_personel_islem()
        {
            InitializeComponent();
        }

        

       
        
        private void btn_ders_islm_Click(object sender, EventArgs e)
        {
            frm_dersler fr = new frm_dersler();
            fr.Show();

        }

        private void btn_blm_islm_Click(object sender, EventArgs e)
        {
           
            frm_Bolumler fr = new frm_Bolumler();
            fr.Show();
        }

        private void btn_snv_not_Click(object sender, EventArgs e)
        {
            frm_Ogrenci_Notlar fr=new frm_Ogrenci_Notlar();
            fr.Show();
        }

        private void btn_pers_Click(object sender, EventArgs e)
        {
           frm_ogretmen fr=new frm_ogretmen();
            fr.Show();
        }

        private void btn_ogr_islm_Click(object sender, EventArgs e)
        {
            frm_ogrenciler fr = new frm_ogrenciler();
            fr.Show();
        }
    }

        
      
    
}
