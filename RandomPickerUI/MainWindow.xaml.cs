using RandomPickerUI.Entities;
using RandomPickerUI.Logic;
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

namespace RandomPickerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainWindowViewModel();
            DataContext = ViewModel;

        }

        private void random_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Pick();
            
        }

        private void addItem_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddItemToSet();
            editItem.Focus();
        }

        private void deleteItem_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteItemFromSet();
        }

        private void addSet_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddSet();
            editSet.Focus();
        }

        private void deleteSet_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteSet();
        }
    }
}