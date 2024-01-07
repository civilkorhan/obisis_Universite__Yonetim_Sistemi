using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace obisis
{
    public partial class frm_dersler : Form
    {
        public frm_dersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tbl_derslerTableAdapter ds = new DataSet1TableAdapters.tbl_derslerTableAdapter();


        private void frm_dersler_Load(object sender, EventArgs e)
        {
            // data set kullanımı çoğunu sihirbaza yaptırdık 2 satır kod yazdık
            // artık bağlantı adresimiz app.config içinde 
            dataGridView1.DataSource = ds.Ders_Listesi();
        }

        private void btn_list_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=ds.Ders_Listesi();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            ds.ders_ekle(txt_ad.Text);
            MessageBox.Show("Ders Eklenmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.AliceBlue;

        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            ds.ders_sil( byte.Parse(txtbox_id.Text)); // id yi tinyint yani byte olrak tutmuşuz çevirme yapılacak
            
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            ds.ders_güncelle(txt_ad.Text,byte.Parse(txtbox_id.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbox_id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_ad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
