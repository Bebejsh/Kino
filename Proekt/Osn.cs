using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X500;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proekt
{
    public partial class Osn : Form
    {
        private List<Label> labels = new List<Label>();
        private List<PictureBox> pictureBoxes = new List<PictureBox>();
        private List<Panel> panels = new List<Panel>();

        private List<Button> buttons = new List<Button>();

        private string connectionString = "server = 127.0.0.1; port = 3306; username = root; password = root;database= _npr2214_ycheb";
        private MySqlConnection connection;
        private MySqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private MySqlCommandBuilder commandBuilder;

        public int Per { get; set; }
        Wh wh = new Wh();
        public Osn()
        {
            InitializeComponent();

            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label7);
            labels.Add(label8);

            pictureBoxes.Add(pictureBox1);
            pictureBoxes.Add(pictureBox2);
            pictureBoxes.Add(pictureBox3);
            pictureBoxes.Add(pictureBox4);
            pictureBoxes.Add(pictureBox5);
            pictureBoxes.Add(pictureBox6);
            pictureBoxes.Add(pictureBox7);
            pictureBoxes.Add(pictureBox8);

            panels.Add(panel1);
            panels.Add(panel2);
            panels.Add(panel3);
            panels.Add(panel4);
            panels.Add(panel5);
            panels.Add(panel6);
            panels.Add(panel7);
            panels.Add(panel8);

            buttons.Add(button14);
            buttons.Add(button15);
            buttons.Add(button16);
            
        }

        private void Osn_Load(object sender, EventArgs e)
        {
            button23.Text = "Маленький зал";
            button24.Text = "Средний зал";
            button25.Text = "Большой зал";
            //string connStr = "server = 192.168.0.89; port = 3306; username =  _npr2214; password =  _npr2214;database= _npr2214_ycheb;";
            string connStr = "server = localhost; port = 3306; username = root; password = root;database= _npr2214_ycheb";

            MySqlConnection conn = new MySqlConnection(connStr);
            
            try
            {
                conn.Open();

                string sql = "SELECT NameF, Kartinka FROM film";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                int index = 0;

                while (rdr.Read() && index < labels.Count && index < pictureBoxes.Count)
                {
                    string nazvf = rdr.GetString(0);
                    string kartinkaPath = rdr.GetString(1);

                    labels[index].Text = nazvf;
                    pictureBoxes[index].Image = Image.FromFile(kartinkaPath);

                    panels[index].Visible = true;

                    index++;
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            
        }
    
        internal void SetUserData(string Name, string Surname)
        {
            label9.Text = $"{Name} {Surname} ";
        }

        internal void SetButtonVisibility(bool isVisibleButton5, bool isVisibleButton8)
        {
            button5.Visible = isVisibleButton5;
            button8.Visible = isVisibleButton8;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel10.Visible = false;
            panel11.Visible = true;
            button7.Visible = true;
            button6.Visible = false;
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CheckVariantAndQueryDatabase()
        {
            if (wh.Variant == 1)
            {
                string connStr = "server=127.0.0.1;port=3306;username=root;password=root;database= _npr2214_ycheb";

                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    conn.Open();

                    string query = $"SELECT idFilm, NameF, Kartinka FROM film WHERE idFilm = {1}";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        string filmName = rdr["NameF"].ToString();
                        string imageUrl = rdr["Kartinka"].ToString();

                        label10.Text = filmName;
                        pictureBox9.ImageLocation = imageUrl;
                        pictureBox9.SizeMode = PictureBoxSizeMode.Zoom; 
                    }

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                string sql = "SELECT DataFilma FROM dataf WHERE Film_idFilm = 1";
                MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader rdr = cmd1.ExecuteReader();

                    int index = 0;

                    while (rdr.Read() && index < buttons.Count)
                    {
                        if (rdr["DataFilma"] != DBNull.Value)
                        {
                            DateTime dataFilma = rdr.GetDateTime(0);
                            string formattedDate = dataFilma.ToString("yyyy-MM-dd HH:mm:ss");

                            buttons[index].Text = formattedDate;
                            buttons[index].Visible = true;
                            index++;
                        }
                    }

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            if (wh.Variant == 2)
            {
                string connStr = "server=127.0.0.1;port=3306;username=root;password=root;database= _npr2214_ycheb";

                MySqlConnection conn = new MySqlConnection(connStr);

                try
                {
                    conn.Open();

                    string query = $"SELECT idFilm, NameF, Kartinka FROM film WHERE idFilm = {2}";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        string filmName = rdr["NameF"].ToString();
                        string imageUrl = rdr["Kartinka"].ToString();

                        label10.Text = filmName;
                        pictureBox9.ImageLocation = imageUrl;
                        pictureBox9.SizeMode = PictureBoxSizeMode.Zoom; 
                    }

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                string sql = "SELECT DataFilma FROM dataf WHERE Film_idFilm = 2";
                MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader rdr = cmd1.ExecuteReader();

                    int index = 0;

                    while (rdr.Read() && index < buttons.Count)
                    {
                        if (rdr["DataFilma"] != DBNull.Value)
                        {
                            DateTime dataFilma = rdr.GetDateTime(0);
                            string formattedDate = dataFilma.ToString("yyyy-MM-dd HH:mm:ss");

                            buttons[index].Text = formattedDate;
                            buttons[index].Visible = true;
                            index++;
                        }
                    }

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            if (wh.Variant == 3)
            {
                string connStr = "server=127.0.0.1;port=3306;username=root;password=root;database= _npr2214_ycheb";

                MySqlConnection conn = new MySqlConnection(connStr);

                try
                {
                    conn.Open();

                    string query = $"SELECT idFilm, NameF, Kartinka FROM film WHERE idFilm = {3}";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        string filmName = rdr["NameF"].ToString();
                        string imageUrl = rdr["Kartinka"].ToString();

                        label10.Text = filmName;
                        pictureBox9.ImageLocation = imageUrl;
                        pictureBox9.SizeMode = PictureBoxSizeMode.Zoom; 
                    }

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                string sql = "SELECT DataFilma FROM dataf WHERE Film_idFilm = 3";
                MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader rdr = cmd1.ExecuteReader();

                    int index = 0;

                    while (rdr.Read() && index < buttons.Count)
                    {
                        if (rdr["DataFilma"] != DBNull.Value)
                        {
                            DateTime dataFilma = rdr.GetDateTime(0);
                            string formattedDate = dataFilma.ToString("yyyy-MM-dd HH:mm:ss");

                            buttons[index].Text = formattedDate;
                            buttons[index].Visible = true;
                            index++;
                        }
                    }

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            if (wh.Variant == 4)
            {
                string connStr = "server=127.0.0.1;port=3306;username=root;password=root;database= _npr2214_ycheb";

                MySqlConnection conn = new MySqlConnection(connStr);

                try
                {
                    conn.Open();

                    string query = $"SELECT idFilm, NameF, Kartinka FROM film WHERE idFilm = {4}";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        string filmName = rdr["NameF"].ToString();
                        string imageUrl = rdr["Kartinka"].ToString();

                        label10.Text = filmName;
                        pictureBox9.ImageLocation = imageUrl;
                        pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
                    }

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                string sql = "SELECT DataFilma FROM dataf WHERE Film_idFilm = 4";
                MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader rdr = cmd1.ExecuteReader();

                    int index = 0;

                    while (rdr.Read() && index < buttons.Count)
                    {
                        if (rdr["DataFilma"] != DBNull.Value)
                        {
                            DateTime dataFilma = rdr.GetDateTime(0);
                            string formattedDate = dataFilma.ToString("yyyy-MM-dd HH:mm:ss");

                            buttons[index].Text = formattedDate;
                            buttons[index].Visible = true;
                            index++;
                        }
                    }

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            if (wh.Variant == 5)
            {
                string connStr = "server=127.0.0.1;port=3306;username=root;password=root;database= _npr2214_ycheb";

                MySqlConnection conn = new MySqlConnection(connStr);

                try
                {
                    conn.Open();

                    string query = $"SELECT idFilm, NameF, Kartinka FROM film WHERE idFilm = {5}";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        string filmName = rdr["NameF"].ToString();
                        string imageUrl = rdr["Kartinka"].ToString();

                        label10.Text = filmName;
                        pictureBox9.ImageLocation = imageUrl;
                        pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
                    }

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                string sql = "SELECT DataFilma FROM dataf WHERE Film_idFilm = 5";
                MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader rdr = cmd1.ExecuteReader();

                    int index = 0;

                    while (rdr.Read() && index < buttons.Count)
                    {
                        if (rdr["DataFilma"] != DBNull.Value)
                        {
                            DateTime dataFilma = rdr.GetDateTime(0);
                            string formattedDate = dataFilma.ToString("yyyy-MM-dd HH:mm:ss");

                            buttons[index].Text = formattedDate;
                            buttons[index].Visible = true;
                            index++;
                        }
                    }

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            if (wh.Variant == 6)
            {
                string connStr = "server=127.0.0.1;port=3306;username=root;password=root;database= _npr2214_ycheb";

                MySqlConnection conn = new MySqlConnection(connStr);

                try
                {
                    conn.Open();

                    string query = $"SELECT idFilm, NameF, Kartinka FROM film WHERE idFilm = {6}";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        string filmName = rdr["NameF"].ToString();
                        string imageUrl = rdr["Kartinka"].ToString();

                        label10.Text = filmName;
                        pictureBox9.ImageLocation = imageUrl;
                        pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
                    }

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                string sql = "SELECT DataFilma FROM dataf WHERE Film_idFilm = 6";
                MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader rdr = cmd1.ExecuteReader();

                    int index = 0;

                    while (rdr.Read() && index < buttons.Count)
                    {
                        if (rdr["DataFilma"] != DBNull.Value)
                        {
                            DateTime dataFilma = rdr.GetDateTime(0);
                            string formattedDate = dataFilma.ToString("yyyy-MM-dd HH:mm:ss");

                            buttons[index].Text = formattedDate;
                            buttons[index].Visible = true;
                            index++;
                        }
                    }

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            if (wh.Variant == 7)
            {
                string connStr = "server=127.0.0.1;port=3306;username=root;password=root;database= _npr2214_ycheb";

                MySqlConnection conn = new MySqlConnection(connStr);

                try
                {
                    conn.Open();

                    string query = $"SELECT idFilm, NameF, Kartinka FROM film WHERE idFilm = {7}";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        string filmName = rdr["NameF"].ToString();
                        string imageUrl = rdr["Kartinka"].ToString();

                        label10.Text = filmName;
                        pictureBox9.ImageLocation = imageUrl;
                        pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
                    }

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                string sql = "SELECT DataFilma FROM dataf WHERE Film_idFilm = 7";
                MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader rdr = cmd1.ExecuteReader();

                    int index = 0;

                    while (rdr.Read() && index < buttons.Count)
                    {
                        if (rdr["DataFilma"] != DBNull.Value)
                        {
                            DateTime dataFilma = rdr.GetDateTime(0);
                            string formattedDate = dataFilma.ToString("yyyy-MM-dd HH:mm:ss");

                            buttons[index].Text = formattedDate;
                            buttons[index].Visible = true;
                            index++;
                        }
                    }

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            if (wh.Variant == 8)
            {
                string connStr = "server=127.0.0.1;port=3306;username=root;password=root;database= _npr2214_ycheb";

                MySqlConnection conn = new MySqlConnection(connStr);

                try
                {
                    conn.Open();

                    string query = $"SELECT idFilm, NameF, Kartinka FROM film WHERE idFilm = {8}";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        string filmName = rdr["NameF"].ToString();
                        string imageUrl = rdr["Kartinka"].ToString();

                        label10.Text = filmName;
                        pictureBox9.ImageLocation = imageUrl;
                        pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
                    }

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                string sql = "SELECT DataFilma FROM dataf WHERE Film_idFilm = 8";
                MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader rdr = cmd1.ExecuteReader();

                    int index = 0;

                    while (rdr.Read() && index < buttons.Count)
                    {
                        if (rdr["DataFilma"] != DBNull.Value)
                        {
                            DateTime dataFilma = rdr.GetDateTime(0);
                            string formattedDate = dataFilma.ToString("yyyy-MM-dd HH:mm:ss");

                            buttons[index].Text = formattedDate;
                            buttons[index].Visible = true;
                            index++;
                        }
                    }

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wh.Variant = wh.Variant + 1;
            CheckVariantAndQueryDatabase();
            panel9.Visible = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wh.Variant = wh.Variant + 2;
            CheckVariantAndQueryDatabase();
            panel9.Visible = true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            wh.Variant = wh.Variant + 3;
            CheckVariantAndQueryDatabase();
            panel9.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            wh.Variant = wh.Variant + 4;
            CheckVariantAndQueryDatabase();
            panel9.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            wh.Variant = wh.Variant + 5;
            CheckVariantAndQueryDatabase();
            panel9.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            wh.Variant = wh.Variant + 6;
            CheckVariantAndQueryDatabase();
            panel9.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            wh.Variant = wh.Variant + 7;
            CheckVariantAndQueryDatabase();
            panel9.Visible = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            wh.Variant = wh.Variant + 8;
            CheckVariantAndQueryDatabase();
            panel9.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
            wh.Variant = 0;
            panel9.Visible = false; 
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel11.Visible = false;
            panel10.Visible = true;
            button7.Visible = false;
            button6.Visible = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string dateToSearch = btn.Text;

            CheckButtonVisibility(dateToSearch);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string dateToSearch = btn.Text;

            CheckButtonVisibility(dateToSearch);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string dateToSearch = btn.Text;

            CheckButtonVisibility(dateToSearch);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadData();
            panel12.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoadData1();
            panel13.Visible = true;
        }

        private void LoadData()
        {
            connection = new MySqlConnection(connectionString);
            dataAdapter = new MySqlDataAdapter("SELECT idFilm, NameF, Kartinka FROM film", connection);
            dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }

        private void LoadData1()
        {
            connection = new MySqlConnection(connectionString);
            dataAdapter = new MySqlDataAdapter("SELECT idDataF, DataFilma, Film_idFilm, Zal_idZal FROM dataf", connection);
            dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            dataGridView2.DataSource = dataTable;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            panel12.Visible=false;

            string connStr = "server = 127.0.0.1; port = 3306; username = root; password = root;database= _npr2214_ycheb";

            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();

                string sql = "SELECT NameF, Kartinka FROM film";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                int index = 0;

                while (rdr.Read() && index < labels.Count && index < pictureBoxes.Count)
                {
                    string nazvf = rdr.GetString(0);
                    string kartinkaPath = rdr.GetString(1);

                    labels[index].Text = nazvf;
                    pictureBoxes[index].Image = Image.FromFile(kartinkaPath);

                    panels[index].Visible = true;

                    index++;
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            string connStr = "server = localhost; port = 3306; username = root; password = root;database= _npr2214_ycheb";

            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();

                string sql = "SELECT NameF, Kartinka FROM film";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                int index = 0;

                while (rdr.Read() && index < labels.Count && index < pictureBoxes.Count)
                {
                    string nazvf = rdr.GetString(0);
                    string kartinkaPath = rdr.GetString(1);

                    labels[index].Text = nazvf;
                    pictureBoxes[index].Image = Image.FromFile(kartinkaPath);

                    panels[index].Visible = true;

                    index++;
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            commandBuilder = new MySqlCommandBuilder(dataAdapter);

            dataAdapter.Update(dataTable);

            MessageBox.Show("Изменения сохранены в базе данных.");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            panel13.Visible = false;

        }

        private void button19_Click(object sender, EventArgs e)
        {
            string connStr = "server = localhost; port = 3306; username = root; password = root;database= _npr2214_ycheb";

            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();

                string sql = "SELECT NameF, Kartinka FROM film";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                int index = 0;

                while (rdr.Read() && index < labels.Count && index < pictureBoxes.Count)
                {
                    string nazvf = rdr.GetString(0);
                    string kartinkaPath = rdr.GetString(1);

                    labels[index].Text = nazvf;
                    pictureBoxes[index].Image = Image.FromFile(kartinkaPath);

                    panels[index].Visible = true;

                    index++;
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            commandBuilder = new MySqlCommandBuilder(dataAdapter);

            dataAdapter.Update(dataTable);

            MessageBox.Show("Изменения сохранены в базе данных.");
        }
        private void CheckButtonVisibility(string dateToSearch)
        {
            Sred sred = new Sred();
            Big big = new Big();
            Malenki mal = new Malenki();

            if (wh.Variant == 1)
            {
                string connStr = "server=127.0.0.1;port=3306;username=root;password=root;database= _npr2214_ycheb";
                MySqlConnection conn = new MySqlConnection(connStr);

                string sql = "SELECT Zal_idZal FROM dataf WHERE Film_idFilm = 1 AND DataFilma = @DataFilma";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@DataFilma", dateToSearch);

                try
                {
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        int Zal_idZal = rdr.GetInt32(0);
                        rdr.Close();

                        sql = "SELECT Razmer_idRazmer FROM Zal WHERE idZal = @Zal_idZal";
                        MySqlCommand cmdZal = new MySqlCommand(sql, conn);
                        cmdZal.Parameters.AddWithValue("@Zal_idZal", Zal_idZal);
                        MySqlDataReader rdrZal = cmdZal.ExecuteReader();

                        if (rdrZal.Read())
                        {
                            int Razmer_idRazmer = rdrZal.GetInt32(0);

                            if (Razmer_idRazmer == 1)
                            {
                                button23.Visible = true;
                                button24.Visible = false;
                                button25.Visible = false;
                            }
                            else if (Razmer_idRazmer == 2)
                            {
                                button23.Visible = false;
                                button24.Visible = true;
                                button25.Visible = false;
                            }
                            else if (Razmer_idRazmer == 3)
                            {
                                button23.Visible = false;
                                button24.Visible = false;
                                button25.Visible = true;
                            }
                        }

                        rdrZal.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                int idDataF = -1; // Переменная для хранения idDataF
                string sql1 = "SELECT idDataF FROM dataf WHERE Film_idFilm = 1 AND DataFilma = @DataFilma";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@DataFilma", dateToSearch);

                try
                {
                    conn.Open();
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    if (rdr1.Read())
                    {
                        idDataF = rdr1.GetInt32(0);
                        Per = idDataF;
                        rdr1.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            if (wh.Variant == 2)
            {
                string connStr = "server=127.0.0.1;port=3306;username=root;password=root;database= _npr2214_ycheb";
                MySqlConnection conn = new MySqlConnection(connStr);

                string sql = "SELECT Zal_idZal FROM dataf WHERE Film_idFilm = 2 AND DataFilma = @DataFilma";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@DataFilma", dateToSearch);

                try
                {
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        int Zal_idZal = rdr.GetInt32(0);
                        rdr.Close();

                        sql = "SELECT Razmer_idRazmer FROM Zal WHERE idZal = @Zal_idZal";
                        MySqlCommand cmdZal = new MySqlCommand(sql, conn);
                        cmdZal.Parameters.AddWithValue("@Zal_idZal", Zal_idZal);
                        MySqlDataReader rdrZal = cmdZal.ExecuteReader();

                        if (rdrZal.Read())
                        {
                            int Razmer_idRazmer = rdrZal.GetInt32(0);

                            if (Razmer_idRazmer == 1)
                            {
                                button23.Visible = true;
                                button24.Visible = false;
                                button25.Visible = false;
                            }
                            else if (Razmer_idRazmer == 2)
                            {
                                button23.Visible = false;
                                button24.Visible = true;
                                button25.Visible = false;
                            }
                            else if (Razmer_idRazmer == 3)
                            {
                                button23.Visible = false;
                                button24.Visible = false;
                                button25.Visible = true;
                            }
                        }

                        rdrZal.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                int idDataF = -1; // Переменная для хранения idDataF
                string sql1 = "SELECT idDataF FROM dataf WHERE Film_idFilm = 2 AND DataFilma = @DataFilma";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@DataFilma", dateToSearch);

                try
                {
                    conn.Open();
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    if (rdr1.Read())
                    {
                        idDataF = rdr1.GetInt32(0);
                        Per = idDataF;
                        rdr1.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            if (wh.Variant == 3)
            {
                string connStr = "server=127.0.0.1;port=3306;username=root;password=root;database= _npr2214_ycheb";
                MySqlConnection conn = new MySqlConnection(connStr);

                string sql = "SELECT Zal_idZal FROM dataf WHERE Film_idFilm = 3 AND DataFilma = @DataFilma";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@DataFilma", dateToSearch);

                try
                {
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        int Zal_idZal = rdr.GetInt32(0);
                        rdr.Close();

                        sql = "SELECT Razmer_idRazmer FROM Zal WHERE idZal = @Zal_idZal";
                        MySqlCommand cmdZal = new MySqlCommand(sql, conn);
                        cmdZal.Parameters.AddWithValue("@Zal_idZal", Zal_idZal);
                        MySqlDataReader rdrZal = cmdZal.ExecuteReader();

                        if (rdrZal.Read())
                        {
                            int Razmer_idRazmer = rdrZal.GetInt32(0);

                            if (Razmer_idRazmer == 1)
                            {
                                button23.Visible = true;
                                button24.Visible = false;
                                button25.Visible = false;
                            }
                            else if (Razmer_idRazmer == 2)
                            {
                                button23.Visible = false;
                                button24.Visible = true;
                                button25.Visible = false;
                            }
                            else if (Razmer_idRazmer == 3)
                            {
                                button23.Visible = false;
                                button24.Visible = false;
                                button25.Visible = true;
                            }
                        }

                        rdrZal.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                int idDataF = -1; // Переменная для хранения idDataF
                string sql1 = "SELECT idDataF FROM dataf WHERE Film_idFilm = 3 AND DataFilma = @DataFilma";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@DataFilma", dateToSearch);

                try
                {
                    conn.Open();
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    if (rdr1.Read())
                    {
                        idDataF = rdr1.GetInt32(0);
                        Per = idDataF;
                        rdr1.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            if (wh.Variant == 4)
            {
                string connStr = "server=127.0.0.1;port=3306;username=root;password=root;database= _npr2214_ycheb";
                MySqlConnection conn = new MySqlConnection(connStr);

                string sql = "SELECT Zal_idZal FROM dataf WHERE Film_idFilm = 4 AND DataFilma = @DataFilma";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@DataFilma", dateToSearch);

                try
                {
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        int Zal_idZal = rdr.GetInt32(0);
                        rdr.Close();

                        sql = "SELECT Razmer_idRazmer FROM Zal WHERE idZal = @Zal_idZal";
                        MySqlCommand cmdZal = new MySqlCommand(sql, conn);
                        cmdZal.Parameters.AddWithValue("@Zal_idZal", Zal_idZal);
                        MySqlDataReader rdrZal = cmdZal.ExecuteReader();

                        if (rdrZal.Read())
                        {
                            int Razmer_idRazmer = rdrZal.GetInt32(0);

                            if (Razmer_idRazmer == 1)
                            {
                                button23.Visible = true;
                                button24.Visible = false;
                                button25.Visible = false;
                            }
                            else if (Razmer_idRazmer == 2)
                            {
                                button23.Visible = false;
                                button24.Visible = true;
                                button25.Visible = false;
                            }
                            else if (Razmer_idRazmer == 3)
                            {
                                button23.Visible = false;
                                button24.Visible = false;
                                button25.Visible = true;
                            }
                        }

                        rdrZal.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                int idDataF = -1; // Переменная для хранения idDataF
                string sql1 = "SELECT idDataF FROM dataf WHERE Film_idFilm = 4 AND DataFilma = @DataFilma";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@DataFilma", dateToSearch);

                try
                {
                    conn.Open();
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    if (rdr1.Read())
                    {
                        idDataF = rdr1.GetInt32(0);
                        Per = idDataF;
                        rdr1.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            if (wh.Variant == 5)
            {
                string connStr = "server=127.0.0.1;port=3306;username=root;password=root;database= _npr2214_ycheb";
                MySqlConnection conn = new MySqlConnection(connStr);

                string sql = "SELECT Zal_idZal FROM dataf WHERE Film_idFilm = 5 AND DataFilma = @DataFilma";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@DataFilma", dateToSearch);

                try
                {
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        int Zal_idZal = rdr.GetInt32(0);
                        rdr.Close();

                        sql = "SELECT Razmer_idRazmer FROM Zal WHERE idZal = @Zal_idZal";
                        MySqlCommand cmdZal = new MySqlCommand(sql, conn);
                        cmdZal.Parameters.AddWithValue("@Zal_idZal", Zal_idZal);
                        MySqlDataReader rdrZal = cmdZal.ExecuteReader();

                        if (rdrZal.Read())
                        {
                            int Razmer_idRazmer = rdrZal.GetInt32(0);

                            if (Razmer_idRazmer == 1)
                            {
                                button23.Visible = true;
                                button24.Visible = false;
                                button25.Visible = false;
                            }
                            else if (Razmer_idRazmer == 2)
                            {
                                button23.Visible = false;
                                button24.Visible = true;
                                button25.Visible = false;
                            }
                            else if (Razmer_idRazmer == 3)
                            {
                                button23.Visible = false;
                                button24.Visible = false;
                                button25.Visible = true;
                            }
                        }

                        rdrZal.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                int idDataF = -1; // Переменная для хранения idDataF
                string sql1 = "SELECT idDataF FROM dataf WHERE Film_idFilm = 5 AND DataFilma = @DataFilma";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@DataFilma", dateToSearch);

                try
                {
                    conn.Open();
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    if (rdr1.Read())
                    {
                        idDataF = rdr1.GetInt32(0);
                        Per = idDataF;
                        rdr1.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            if (wh.Variant == 6)
            {
                string connStr = "server=127.0.0.1;port=3306;username=root;password=root;database= _npr2214_ycheb";
                MySqlConnection conn = new MySqlConnection(connStr);

                string sql = "SELECT Zal_idZal FROM dataf WHERE Film_idFilm = 6 AND DataFilma = @DataFilma";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@DataFilma", dateToSearch);

                try
                {
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        int Zal_idZal = rdr.GetInt32(0);
                        rdr.Close();

                        sql = "SELECT Razmer_idRazmer FROM Zal WHERE idZal = @Zal_idZal";
                        MySqlCommand cmdZal = new MySqlCommand(sql, conn);
                        cmdZal.Parameters.AddWithValue("@Zal_idZal", Zal_idZal);
                        MySqlDataReader rdrZal = cmdZal.ExecuteReader();

                        if (rdrZal.Read())
                        {
                            int Razmer_idRazmer = rdrZal.GetInt32(0);

                            if (Razmer_idRazmer == 1)
                            {
                                button23.Visible = true;
                                button24.Visible = false;
                                button25.Visible = false;
                            }
                            else if (Razmer_idRazmer == 2)
                            {
                                button23.Visible = false;
                                button24.Visible = true;
                                button25.Visible = false;
                            }
                            else if (Razmer_idRazmer == 3)
                            {
                                button23.Visible = false;
                                button24.Visible = false;
                                button25.Visible = true;
                            }
                        }

                        rdrZal.Close();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                int idDataF = -1; // Переменная для хранения idDataF
                string sql1 = "SELECT idDataF FROM dataf WHERE Film_idFilm = 6 AND DataFilma = @DataFilma";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@DataFilma", dateToSearch);

                try
                {
                    conn.Open();
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    if (rdr1.Read())
                    {
                        idDataF = rdr1.GetInt32(0);
                        Per = idDataF;
                        rdr1.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

            }
            if (wh.Variant == 7)
            {
                string connStr = "server=127.0.0.1;port=3306;username=root;password=root;database= _npr2214_ycheb";
                MySqlConnection conn = new MySqlConnection(connStr);

                string sql = "SELECT Zal_idZal FROM dataf WHERE Film_idFilm = 7 AND DataFilma = @DataFilma";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@DataFilma", dateToSearch);

                try
                {
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        int Zal_idZal = rdr.GetInt32(0);
                        rdr.Close();

                        sql = "SELECT Razmer_idRazmer FROM Zal WHERE idZal = @Zal_idZal";
                        MySqlCommand cmdZal = new MySqlCommand(sql, conn);
                        cmdZal.Parameters.AddWithValue("@Zal_idZal", Zal_idZal);
                        MySqlDataReader rdrZal = cmdZal.ExecuteReader();

                        if (rdrZal.Read())
                        {
                            int Razmer_idRazmer = rdrZal.GetInt32(0);

                            if (Razmer_idRazmer == 1)
                            {
                                button23.Visible = true;
                                button24.Visible = false;
                                button25.Visible = false;
                            }
                            else if (Razmer_idRazmer == 2)
                            {
                                button23.Visible = false;
                                button24.Visible = true;
                                button25.Visible = false;
                            }
                            else if (Razmer_idRazmer == 3)
                            {
                                button23.Visible = false;
                                button24.Visible = false;
                                button25.Visible = true;
                            }
                        }

                        rdrZal.Close();

                        
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                int idDataF = -1; // Переменная для хранения idDataF
                string sql1 = "SELECT idDataF FROM dataf WHERE Film_idFilm = 7 AND DataFilma = @DataFilma";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@DataFilma", dateToSearch);

                try
                {
                    conn.Open();
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    if (rdr1.Read())
                    {
                        idDataF = rdr1.GetInt32(0);
                        Per = idDataF;
                        rdr1.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            if (wh.Variant == 8)
            {
                string connStr = "server=127.0.0.1;port=3306;username=root;password=root;database= _npr2214_ycheb";
                MySqlConnection conn = new MySqlConnection(connStr);

                string sql = "SELECT Zal_idZal FROM dataf WHERE Film_idFilm = 8 AND DataFilma = @DataFilma";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@DataFilma", dateToSearch);

                try
                {
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        int Zal_idZal = rdr.GetInt32(0);
                        
                        rdr.Close();

                        sql = "SELECT Razmer_idRazmer FROM Zal WHERE idZal = @Zal_idZal";
                        MySqlCommand cmdZal = new MySqlCommand(sql, conn);
                        cmdZal.Parameters.AddWithValue("@Zal_idZal", Zal_idZal);
                        MySqlDataReader rdrZal = cmdZal.ExecuteReader();

                        if (rdrZal.Read())
                        {
                            int Razmer_idRazmer = rdrZal.GetInt32(0);

                            button23.Visible = (Razmer_idRazmer == 1);
                            button24.Visible = (Razmer_idRazmer == 2);
                            button25.Visible = (Razmer_idRazmer == 3);

                            rdrZal.Close();

                        }
                        
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySQL Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                int idDataF = -1; // Переменная для хранения idDataF
                string sql1 = "SELECT idDataF FROM dataf WHERE Film_idFilm = 8 AND DataFilma = @DataFilma";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@DataFilma", dateToSearch);

                try
                {
                    conn.Open();
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    if (rdr1.Read())
                    {
                        idDataF = rdr1.GetInt32(0);
                        Per = idDataF;
                        rdr1.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        
       

      
        private void button23_Click(object sender, EventArgs e)
        {
           
            
            
            Malenki malenki = new Malenki();
            malenki.IdDataF = Per;
            malenki.Show();
            this.Close();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Sred sred = new Sred();
            sred.IdDataF = Per;
            sred.Show();
            this.Close();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Big big = new Big();
            big.IdDataF = Per;
            big.Show();
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

