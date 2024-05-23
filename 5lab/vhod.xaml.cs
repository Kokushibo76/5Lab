using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using _5lab.Flower_shopDataSetTableAdapters;

namespace _5lab
{
    /// <summary>
    /// Логика взаимодействия для vhod.xaml
    /// </summary>
    public partial class vhod : Window
    {
        UsersTableAdapter adapter = new UsersTableAdapter();
        public vhod()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxLogin.Text) || string.IsNullOrEmpty(passwordBox.Password))
            {
                MessageBox.Show("Введите логин с паролем");
                return;
            }

            var allLogins = adapter.GetData().Rows;
            bool foundUser = false;

            for (int i = 0; i < allLogins.Count; i++)
            {
                if (allLogins[i][1].ToString() == textBoxLogin.Text &&
                    allLogins[i][2].ToString() == passwordBox.Password)
                {
                    int roleId = (int)allLogins[i][3];
                    foundUser = true;

                    switch (roleId)
                    {
                        case 1:
                            Window1 admin = new Window1();
                            admin.Show();
                            this.Close();
                            break;
                        case 2:
                            Window2 klient = new Window2();
                            klient.Show();
                            this.Close();
                            break;
                    }
                    break;
                }
            }
            if (!foundUser)
            {
                MessageBox.Show("Введен неверный логи или пароль");
            }
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
