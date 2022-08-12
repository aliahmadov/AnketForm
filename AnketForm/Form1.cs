using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnketForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClearTextBoxes()
        {
            foreach (var item in guna2CustomGradientPanel2.Controls)
            {
                if (item is TextBox tb)
                {
                    tb.Clear();
                }
                else if (item is MaskedTextBox mb)
                {
                    mb.Clear();
                }
            }
            phoneMaskedBox.Text = "994";
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                Name = nameTxtb.Text,
                Surname = surnameTxtb.Text,
                Date = dateMaskedBox.Text,
                Email = emailTxtb.Text,
                Phone = phoneMaskedBox.Text
            };
            listBox1.Items.Add(user);
            ClearTextBoxes();



        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var user = listBox1.SelectedItem as User;

            if (user != null)
            {
                if (fileNameTxtb.Text != "")
                {
                    user.FileName = fileNameTxtb.Text;
                    FileHelper.SerializeDatabase(user);
                    MessageBox.Show($"File name for {user.Name} has been successfully saved");
                    fileNameTxtb.Clear();
                }
                else
                {
                    MessageBox.Show("File name must be defined");

                }
            }
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var user = FileHelper.DeserializeDatabase(listBox1.SelectedItem as User);
                if (user != null)
                {

                    nameTxtb.Text = user.Name;
                    surnameTxtb.Text = user.Surname;
                    dateMaskedBox.Text = user.Date;
                    emailTxtb.Text = user.Email;
                    phoneMaskedBox.Text = user.Phone;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"File has not been found");
            }

        }

        private void changeBtn_Click(object sender, EventArgs e)
        {

            var user = listBox1.SelectedItem as User;


            User newUser = new User()
            {
                Name = nameTxtb.Text,
                Surname = surnameTxtb.Text,
                Date = dateMaskedBox.Text,
                Email = emailTxtb.Text,
                Phone = phoneMaskedBox.Text,
                FileName = user.FileName
            };
            listBox1.Items.Remove(user);
            listBox1.Items.Add(newUser);
            FileHelper.SerializeDatabase(newUser);
            ClearTextBoxes();
        }
    }
}
