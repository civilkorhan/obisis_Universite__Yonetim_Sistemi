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
    public partial class frm_Bolumler : Form
    {
        public frm_Bolumler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-Q60UHL2\SQLEXPRESS05;Initial Catalog=Obisis;Integrated Security=True;");
        public void listele()  //void yazmayı unutma 
        {
            DataTable blmtbl = new DataTable();
            SqlDataAdapter gtr = new SqlDataAdapter("select * from tbl_bolumler", conn);
            gtr.Fill(blmtbl);
            dataGridView1.DataSource = blmtbl;
        }
        
        private void frm_Bolumler_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbox_id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtbox_ad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand add =new SqlCommand("insert into tbl_bolumler (bolum_ad) values (@p1)",conn);
            add.Parameters.AddWithValue("@p1",txtbox_ad.Text);
            add.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Bölüm Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        

        private void pictureBox_cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox_cikis_MouseHover(object sender, EventArgs e)
        {
            pictureBox_cikis.BackColor = Color.Red;
        }

        private void pictureBox_cikis_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_cikis.BackColor = Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand dlt = new SqlCommand("delete from tbl_bolumler where bolum_id=@p1",conn);
            dlt.Parameters.AddWithValue("@p1",txtbox_id.Text);
            dlt.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Bölüm Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        private void btn_updt_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand uptade = new SqlCommand("update tbl_bolumler set bolum_ad=@p1 where bolum_id=@p2" ,conn);
            uptade.Parameters.AddWithValue("@p1",txtbox_ad.Text);
            uptade.Parameters.AddWithValue("@p2",txtbox_id.Text);
            uptade.ExecuteNonQuery();   
            conn.Close();
            MessageBox.Show("Bölüm Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
    }
}
