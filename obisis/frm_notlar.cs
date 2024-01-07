using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace obisis
{
    public partial class frm_notlar : Form
    {
        public frm_notlar()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-Q60UHL2\SQLEXPRESS05;Initial Catalog=Obisis;Integrated Security=True;");


        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
        DataSet1TableAdapters.tbl_notlar1TableAdapter ds_newnots = new DataSet1TableAdapters.tbl_notlar1TableAdapter();
        private void btn_ara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds_newnots.GetData_nots(int.Parse(txtbox_id.Text));
        }

        private void frm_notlar_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand gtr = new SqlCommand("Select * from tbl_dersler", conn);
            SqlDataAdapter da = new SqlDataAdapter(gtr);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox_dersler.DisplayMember = "ders_ad";
            comboBox_dersler.ValueMember = "ders_id";
            comboBox_dersler.DataSource = dt;
        }
        int not_id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            not_id = int.Parse( dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            txtbox_id.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtbox_vize1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtbox_vize2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtbox_final.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            comboBox_dersler.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtbox_gano.Text= dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtbox_durum.Text= dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void btn_hesapla_Click(object sender, EventArgs e)
        {
            int vize1, vize2, final;
            double gano;
           // string durum;
            vize1=Convert.ToInt16(txtbox_vize1.Text);
            vize2 = Convert.ToInt16(txtbox_vize2.Text);
            final=Convert.ToInt16(txtbox_final.Text);
            gano = (vize1 * 0.2 + vize2 * 0.2 + final * 0.6) / 1;
            txtbox_gano.Text = gano.ToString();
            if (gano >= 50)
            {
                txtbox_durum.Text = "True";
            }
            else
            {
                txtbox_durum.Text= "False";
            }
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            txtbox_id.Text = "";
            comboBox_dersler.Text = "";
            txtbox_vize1.Text = "";
            txtbox_vize2.Text = "";
            txtbox_final.Text = "";
            txtbox_gano.Text = "";
            txtbox_durum.Text = "";


        }

        private void button3_Click(object sender, EventArgs e)
        {
          ds_newnots.UpdateQuery(byte.Parse(comboBox_dersler.SelectedValue.ToString()),int.Parse(txtbox_id.Text),byte.Parse(txtbox_vize1.Text),byte.Parse(txtbox_vize2.Text),byte.Parse(txtbox_final.Text),decimal.Parse(txtbox_gano.Text),
           bool.Parse(txtbox_durum.Text),not_id);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
