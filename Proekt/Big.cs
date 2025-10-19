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

namespace Proekt
{
    public partial class Big : Form
    {
        public int IdDataF { get; set; }
        public Big()
        {
            InitializeComponent();
            Wh wh = new Wh();
            C1.Text = "450";
            C2.Text = "450";
            C3.Text = "450"; C4.Text = "450"; C5.Text = "450";
            C21.Text = "550";
            C22.Text = "550";
            C23.Text = "550"; C24.Text = "550"; C25.Text = "450";
            C31.Text = "550";
            C32.Text = "550";
            C23.Text = "550"; C34.Text = "550"; C35.Text = "450";
            C41.Text = "450";
            C42.Text = "450";
            C43.Text = "450"; C44.Text = "450"; C45.Text = "450";
            C51.Text = "450";
            C52.Text = "450";
            C53.Text = "450"; C54.Text = "450"; C55.Text = "450";
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void SetPanelColorByName(string panelName, Color color)
        {
            Control[] controls = this.Controls.Find(panelName, true);
            if (controls.Length > 0 && controls[0] is Panel)
            {
                Panel panel = (Panel)controls[0];
                panel.BackColor = color;
            }
        }
        private Dictionary<string, int> GetPanelsStatusFromDatabase(int idDataF)
        {
            Dictionary<string, int> panelStatuses = new Dictionary<string, int>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Mesto, idSostayanieB FROM bilet Where idDataF = @IdDataF";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdDataF", idDataF); // Добавляем параметр @IdDataF

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string panelName = "M" + reader["Mesto"].ToString();
                        int status = Convert.ToInt32(reader["idSostayanieB"]);

                        if (!panelStatuses.ContainsKey(panelName))
                        {
                            panelStatuses.Add(panelName, status);
                        }
                    }
                }
            }

            return panelStatuses;
        }
        private void DeleteSelectedPanelFromDatabase(string panelName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM bilet WHERE Mesto = @panelName";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@panelName", panelName);

                command.ExecuteNonQuery();
            }
        }
        private void Big_Load(object sender, EventArgs e)
        {
            int idDataF = IdDataF;

            Dictionary<string, int> panelStatuses = GetPanelsStatusFromDatabase(idDataF);

            foreach (string panelName in panelStatuses.Keys)
            {
                Color panelColor = panelStatuses[panelName] == 1 ? Color.Green : Color.Firebrick;
                SetPanelColorByName(panelName, panelColor);
            }


        }
        private string connectionString = "server = 127.0.0.1; port = 3306; username = root; password = root;database= _npr2214_ycheb";

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedNumber = comboBox1.SelectedItem.ToString();

                int idSostayanieB = checkBox1.Checked ? 1 : 2; // 1 если checkbox1 выбран, иначе 2
                int idDataF = IdDataF;

                if (CheckIfItemExistsInDatabase(selectedNumber, IdDataF))
                {
                    MessageBox.Show("Данное место уже занято.");
                    return;
                }

                string message = checkBox1.Checked ? $"Куплено {selectedNumber}" : $"Бронирование {selectedNumber}";
                Color panelColor = checkBox1.Checked ? Color.Green : Color.Firebrick;

                MessageBox.Show(message);

                string panelName = "M" + selectedNumber;
                Control[] controls = this.Controls.Find(panelName, true);

                if (controls.Length > 0 && controls[0] is Panel)
                {
                    Panel selectedPanel = (Panel)controls[0];
                    selectedPanel.BackColor = panelColor;
                }
                else
                {
                    MessageBox.Show($"Панель {panelName} не найдена.");
                }

                // Запись в базу данных
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO bilet (Mesto, idSostayanieB, idDataF) VALUES(@Mesto, @idSostayanieB, @idDataF)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Mesto", selectedNumber);
                    cmd.Parameters.AddWithValue("@idSostayanieB", idSostayanieB);
                    cmd.Parameters.AddWithValue("@idDataF", IdDataF);
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите номер.");
            }
        }

        private void M11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Application.Exit();

        }
        private bool CheckIfItemExistsInDatabase(string itemText, int idDataF)
        {
            bool exists = false;

            string connectionString = "server=127.0.0.1;port=3306;username=root;password=root;database= _npr2214_ycheb;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM bilet WHERE Mesto = @Mesto AND idDataF = @IdDataF";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Mesto", itemText);
                command.Parameters.AddWithValue("@IdDataF", IdDataF);

                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    exists = true;
                    Console.WriteLine("Данное место занято");
                }
            }

            return exists;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedPanelName = comboBox1.SelectedItem.ToString();
                DeleteSelectedPanelFromDatabase(selectedPanelName);

                // После удаления перезагрузите комбобокс или обновите данные, чтобы отразить изменения
                string selectedNumber = comboBox1.SelectedItem.ToString();
                string panelName = "M" + selectedNumber;

                // Устанавливаем панели цвет серый
                SetPanelColorByName(panelName, Color.Gray);

                MessageBox.Show("Место успешно очищено");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите место для удаления из базы данных.");
            }
        }
    }
}
