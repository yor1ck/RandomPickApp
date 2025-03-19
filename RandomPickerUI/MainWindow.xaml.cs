using RandomPickerUI.Entities;
using RandomPickerUI.Logic;
using System.ComponentModel;
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
            base.Closing += this.MainWindow_Closing;

        }

        private void MainWindow_Closing(object? sender, CancelEventArgs e)
        {
            ViewModel.SaveToFile();
        }

        private void randomList_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.PickFromFullList();
            
        }
        private void randomGroup_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.PickFromGroup();
        }

        private void addItem_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddItemToList();
            editItem.Focus();
        }

        private void deleteItem_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteItemFromList();
        }

        private void addList_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddFullList();
            editSet.Focus();
        }

        private void deleteList_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteList();
        }

        private void addToGroup_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddItemToGroup();
        }

        private void DeleteItemFromGroup_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteItemFromGroup();
        }

        private void addGroup_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddGroup();
        }

        private void deleteGroup_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteGroup();
        }
    }
}