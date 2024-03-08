using _5_DataAcces.model;
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _4_ConnectedMode_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SportShop_db db;
        public MainWindow()
        {

            InitializeComponent();
            db = new SportShop_db(ConfigurationManager.ConnectionStrings["connSportShop"].ConnectionString);
        }

        private void getProducts(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = db.GetAllProducts();
        }

        private void idProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                int id = int.Parse(idProduct.Text);
                List<Product> prod = new List<Product>();
                prod.Add(db.GetOneProduct(id));
                dataGrid.ItemsSource = prod;


            }
        }
    }
}