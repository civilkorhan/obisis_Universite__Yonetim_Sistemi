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
    public partial class frm_Ogrenci_Notlar : Form
    {
        public frm_Ogrenci_Notlar()
        {
            InitializeComponent();
        }
        public string numara;

        SqlConnection bgl=new SqlConnection(@"Data Source=DESKTOP-Q60UHL2\SQLEXPRESS05;Initial Catalog=Obisis;Integrated Security=True;");
        private void frm_Ogrenci_Notlar_Load(object sender, EventArgs e)
        {
            SqlCommand gtr = new SqlCommand("select ders_ad, vize_1,vize_2,final, gano, durum from tbl_notlar inner join tbl_dersler on  tbl_notlar.ders_id=tbl_dersler.ders_id where ogr_id=@p1", bgl);
            gtr.Parameters.AddWithValue("@p1", numara);
            //this.Text = numara;
            SqlDataAdapter da= new SqlDataAdapter(gtr);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
