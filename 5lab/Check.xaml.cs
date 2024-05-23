using _5lab.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
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

namespace _5lab
{
    /// <summary>
    /// Логика взаимодействия для Check.xaml
    /// </summary>
    public partial class Check : Window
    {
        Flower_shopEntities db = new Flower_shopEntities();
        FlowerTableAdapter flowerTable = new FlowerTableAdapter();
        DataGrid RabDgr;
        Flower_shopEntities ct = new Flower_shopEntities();
        DataGrid CvetokDgr;
        FlowerTableAdapter adapter = new FlowerTableAdapter();
        public Check()
        {
            InitializeComponent();
            LoadCheckData();
        }

        private void LoadCheckData()
        {
            CheckDgr.ItemsSource = db.Checks.ToList();
        }

        private void Button_ClickAddCheck(object sender, RoutedEventArgs e)
        {
            var newCheck = new Checks();
            db.Checks.Add(newCheck);
            db.SaveChanges();
            LoadCheckData();
        }

        private void Button_ClickDelCheck(object sender, RoutedEventArgs e)
        {
            if (CheckDgr.SelectedItem != null)
            {
                var selectedCheck = CheckDgr.SelectedItem as Checks;
                db.Checks.Remove(selectedCheck);
                db.SaveChanges();
                LoadCheckData();
            }
        }

        private void Button_ClickChCheck(object sender, RoutedEventArgs e)
        {
            if (CheckDgr.SelectedItem != null)
            {
                var selectedCheck = CheckDgr.SelectedItem as Check;
                db.SaveChanges();
                LoadCheckData();
            }
        }
    }
}
