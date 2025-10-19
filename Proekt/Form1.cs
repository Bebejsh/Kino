using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proekt
{
    public partial class Form1 : Form
    {
        //private string connections = "server = 192.168.0.89; port = 3306; username =  _npr2214; password =  _npr2214;database= _npr2214_ycheb";
        private string connections = "server = 127.0.0.1; port = 3306; username = root; password = root;database= _npr2214_ycheb";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connections);
            connection.Open();
            string cmd = "SELECT COUNT(*) FROM users WHERE Login = @Login AND Password = @Password";
            MySqlCommand Command = new MySqlCommand(cmd, connection);
            using (Command)
            {
                Command.Parameters.AddWithValue("@Login", TextBox1.Text);
                Command.Parameters.AddWithValue("@Password", TextBox2.Text);

                int count = Convert.ToInt32(Command.ExecuteScalar());



                if (count > 0)
                {
                    Osn form2 = new Osn();
                    //Form3 form3 = new Form3();


                    string query = "SELECT idUsers, NameU, Surname, Role_idRole FROM users WHERE Login = @Login";
                    MySqlCommand getUserCommand = new MySqlCommand(query, connection);
                    getUserCommand.Parameters.AddWithValue("@Login", TextBox1.Text);

                    using (MySqlDataReader reader = getUserCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Получаем значения из базы данных
                            string Name = reader.GetString("NameU");
                            string Surname = reader.GetString("Surname");
                            int roleId = reader.GetInt32("Role_idRole");
                      
                            // Передаем значения на Form2
                            form2.SetUserData(Name, Surname);
                            //form2.idUser = Convert.ToInt32(reader["idUser"]);
                            //int id = reader.GetInt32("idUser");
                            //Form3.PPP.idUserK = id;
                            if (roleId == 1)
                            {
                                //Wh wh = new Wh();
                                //wh.Variable = wh.Variable + 1;
                                form2.SetButtonVisibility(true, true); // Делаем кнопку button5 видимой
                                
                            }
                        }
                    }
                    this.Hide();
                    form2.Show();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль");
                }
            }
            connection.Close();
        }
    }
}
