using _5lab.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Items.xaml
    /// </summary>
    public partial class Items : Window
    {
        Flower_shopEntities db = new Flower_shopEntities();
        FlowerTableAdapter flowerTable = new FlowerTableAdapter();
        DataGrid RabDgr;
        Flower_shopEntities ct = new Flower_shopEntities();
        DataGrid CvetokDgr;
        FlowerTableAdapter adapter = new FlowerTableAdapter();

        public Items()
        {
            InitializeComponent();

            FlowerDgr.ItemsSource = db.Flower.ToList();
        }

        private void JBCbx_SelectionChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (JBCbx.SelectedItem != null)
            {
                var id = (JBCbx.SelectedItem as DataRowView).Row[0];
                FlowerDgr.ItemsSource = db.Flower.ToList().Where(item => item.Flower_type == id);
            }
        }

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
    }
}
