using System.Data;
using System.Data.SqlClient;
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

namespace _6_DisconnectedMode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataSet set;


        public MainWindow()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SportShop;Integrated Security=True;Connect Timeout=2");
          
            InitializeComponent();

        }
        //fill btn
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sql = commandText.Text;
            adapter = new SqlDataAdapter(sql, connection);
            set = new DataSet();
            new SqlCommandBuilder(adapter);
            adapter.Fill(set,"Products");
            dataGrid.ItemsSource = set.Tables["Products"].DefaultView;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            adapter.Update(set, "Products");
        }
    }
}