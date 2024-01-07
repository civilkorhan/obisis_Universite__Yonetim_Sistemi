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
    public partial class frm_ogrenciler : Form
    {
        public frm_ogrenciler()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-Q60UHL2\SQLEXPRESS05;Initial Catalog=Obisis;Integrated Security=True;");
        DataSet1TableAdapters.DataTable1TableAdapter dsnw = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void frm_ogrenciler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dsnw.Ogrenci_Listesi();
            conn.Open();
            SqlCommand gtr = new SqlCommand("Select * from tbl_bolumler", conn);
            SqlDataAdapter da =new SqlDataAdapter(gtr);
            DataTable dt = new DataTable(); 
            da.Fill(dt);
            cmbo_box_bolumler.DisplayMember = "bolum_ad";
            cmbo_box_bolumler.ValueMember = "bolum_id";
            cmbo_box_bolumler.DataSource = dt;
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dsnw.Ogrenci_Listesi();

        }
        string c = "";
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "Kız";
            }
            if (radioButton2.Checked == true)
            {
                c = "Erkek";
            }
            dsnw.ogrenci_Ekle(txtbox_ad.Text, txtbx_soyad.Text, byte.Parse(cmbo_box_bolumler.Text), c);
            MessageBox.Show("Öğrenci Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbox_id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtbox_ad.Text=dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtbx_soyad.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbo_box_bolumler.Text= dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            c = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Kız")
            { 
                radioButton1.Checked = true;


             }
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Erkek")
            {
                radioButton2.Checked = true;   
            }
            
        }

        private void btn_dlt_Click(object sender, EventArgs e)
        {
            dsnw.ogrenci_sil(int.Parse(txtbox_id.Text));
            MessageBox.Show("Öğrenci Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            
            dsnw.ogrenci_gnclleme(txtbox_ad.Text, txtbx_soyad.Text, byte.Parse(cmbo_box_bolumler.SelectedValue.ToString()), c, int.Parse(txtbox_id.Text));
            MessageBox.Show("Öğrenci Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "Kız";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                c = "Erkek";
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=dsnw.ogrenci_Getir(txtbox_ara.Text);
        }
    }
}
