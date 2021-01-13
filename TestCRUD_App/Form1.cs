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

namespace TestCRUD_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True;Pooling=False";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO UserTab VALUES (@Id,@Name,@Age)",con);
            cmd.Parameters.AddWithValue("@Id" , int.Parse(textBoxID.Text));
            cmd.Parameters.AddWithValue("@Name" , textBoxName.Text);
            cmd.Parameters.AddWithValue("@Age" , double.Parse(textBoxAge.Text));
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Succes - Insert");

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True;Pooling=False";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE UserTab SET Name=@Name, Age= @Age WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBoxID.Text));
            cmd.Parameters.AddWithValue("@Name", textBoxName.Text);
            cmd.Parameters.AddWithValue("@Age", double.Parse(textBoxAge.Text));
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Succes - Update");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True;Pooling=False";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE UserTab where Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBoxID.Text));
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Succes - Delete");
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True;Pooling=False";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM UserTab WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBoxID.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataGridView1.DataSource = dt;
            da.Fill(dt);

        }
    }
}
