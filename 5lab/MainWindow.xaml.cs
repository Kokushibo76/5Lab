using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _5lab.Flower_shopDataSetTableAdapters;

namespace _5lab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Flower_shopEntities db = new Flower_shopEntities();
        FlowerTableAdapter flowerTable = new FlowerTableAdapter();
        DataGrid RabDgr;
        Flower_shopEntities ct = new Flower_shopEntities();
        DataGrid CvetokDgr;
        FlowerTableAdapter adapter = new FlowerTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            FlowerDgr.ItemsSource = flowerTable.GetData();

            EmplDgr.ItemsSource = db.Employee.ToList();
            EmployeesDgr.ItemsSource = db.Employee.ToList();

            FlowerDgr.ItemsSource = db.Flower.ToList();

            EmpDgr4.ItemsSource = ct.Employee.ToList();
            JBCbx.ItemsSource = ct.Job_title.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var psswrd = adapter.GetData().Rows;
            for (int i = 0; psswrd.Count > i; i++)
            {
                if (psswrd[i][1].ToString() == LoginTbx.Text && psswrd[i][5].ToString() == PasswordTbx.Text)
                {
                    int done = (int)psswrd[i][4];
                    switch (done)
                    {
                        case 1:
                            Window1 window = new Window1(); window.Show();
                            break;
                        case 2:
                            Window2 window2 = new Window2(); window2.Show();
                            break;
                        case 3:
                            Window3 window3 = new Window3();
                            window3.Show();
                            break;
                        case 4:
                            Window4 window4 = new Window4(); window4.Show();
                            break;
                    }
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_ClickCheck(object sender, RoutedEventArgs e)
        {
            var checkWindow = new Check();
            checkWindow.Show();
        }

        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("№1.xaml", UriKind.Relative);
            NavigationFrame.Navigate(uri);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dannye = (Job_titlesCbx.SelectedItem as DataRowView).Row;
            GG.Text = dannye[1].ToString();
            Job_titlesCbx.SelectedValue = Convert.ToInt32(dannye[1]);
        }


        //Up,Del,Ch - emp
        private void EmployeesDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRow = EmployeesDgr.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                GG.Text = selectedRow[1].ToString();
                Job_titlesCbx.SelectedValue = Convert.ToInt32(selectedRow[1]);
            }
        }

        private void Button_Click_AddEmp(object sender, RoutedEventArgs e)
        {
            var addEmployee = new Employee();
            db.Employee.Add(addEmployee);
            db.SaveChanges();
            EmployeesDgr.ItemsSource = db.Employee.ToList();
        }

        private void Button_ClickDelEmp(object sender, RoutedEventArgs e)
        {
            if (EmployeesDgr.SelectedItem != null)
            {
                var deleteEmployee = EmployeesDgr.SelectedItem as Employee;
                db.Employee.Remove(deleteEmployee);
                db.SaveChanges();
                EmployeesDgr.ItemsSource = db.Employee.ToList();
            }
        }

        private void Button_Click_ChEmp(object sender, RoutedEventArgs e)
        {
            if (EmployeesDgr.SelectedItem != null)
            {
                var chEmployee = EmployeesDgr.SelectedItem as Employee;
                chEmployee.Firstname = EmployeeTbx.Text;
                db.SaveChanges();
                EmployeesDgr.ItemsSource = db.Employee.ToList();
            }
        }

        private void JBCbx_SelectionChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (JBCbx.SelectedItem != null)
            {
                var sel = JBCbx.SelectedItem as Job_title;
                EmpDgr4.ItemsSource = ct.Employee.ToList().Where(Item => Item.Job_title == sel);
            }
        }

        private void Button_ClickSearch(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchTbx.Text))
            {
                EmpDgr4.ItemsSource = ct.Employee.ToList().Where(item => item.Firstname.Contains(SearchTbx.Text) || item.Firstname.Contains(SearchTbx.Text));
            }
            else
            {
                EmpDgr4.ItemsSource = ct.Employee.ToList();
            }
        }

        //
        private void FlowerDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRow = FlowerDgr.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                GG.Text = selectedRow[1].ToString();
                Flower_typeCbx.SelectedValue = Convert.ToInt32(selectedRow[1]);
            }
        }

        private void Button_Click_AddFl(object sender, RoutedEventArgs e)
        {
            var addFlow = new Flower();
            db.Flower.Add(addFlow);
            db.SaveChanges();
            FlowerDgr.ItemsSource = db.Flower.ToList();
        }

        private void Button_ClickDelFl(object sender, RoutedEventArgs e)
        {
            if (FlowerDgr.SelectedItem != null)
            {
                var deleteFlow = FlowerDgr.SelectedItem as Flower;
                db.Flower.Remove(deleteFlow);
                db.SaveChanges();
                FlowerDgr.ItemsSource = db.Flower.ToList();
            }
        }

        private void Button_Click_ChFl(object sender, RoutedEventArgs e)
        {
            if (FlowerDgr.SelectedItem != null)
            {
                var chFlow = FlowerDgr.SelectedItem as Flower;
                chFlow.Name_of_flower = FlowTbx.Text;
                db.SaveChanges();
                FlowerDgr.ItemsSource = db.Flower.ToList();
            }
        }

        private void FlowDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRow = FlowerDgr.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                GG.Text = selectedRow[1].ToString();
                Flower_typeCbx.SelectedValue = Convert.ToInt32(selectedRow[1]);
            }
        }

        //
        private void StoreDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRow = StorDgr.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                GG.Text = selectedRow[1].ToString();
                StreetCbx.SelectedValue = Convert.ToInt32(selectedRow[1]);
            }
        }

        private void Button_Click_AddSt(object sender, RoutedEventArgs e)
        {
            var addStr = new Store();
            db.Store.Add(addStr);
            db.SaveChanges();
            StorDgr.ItemsSource = db.Store.ToList();
        }

        private void Button_ClickDelSt(object sender, RoutedEventArgs e)
        {
            if (StorDgr.SelectedItem != null)
            {
                var deleteStr = StorDgr.SelectedItem as Store;
                db.Store.Remove(deleteStr);
                db.SaveChanges();
                StorDgr.ItemsSource = db.Store.ToList();
            }
        }

        private void Button_Click_ChSt(object sender, RoutedEventArgs e)
        {
            if (StorDgr.SelectedItem != null)
            {
                var chStr = StorDgr.SelectedItem as Store;
                chStr.Street = StorTbx.Text;
                db.SaveChanges();
                StorDgr.ItemsSource = db.Store.ToList();
            }
        }
    }
}