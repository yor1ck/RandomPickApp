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


            //var testList = new List<Thing>();
            //testList.Add(new Thing("One"));
            //testList.Add(new Thing("Two"));
            //testList.Add(new Thing("Three"));
            //testList.Add(new Thing("Four"));

            //var currentRequest = new PickRequest(testList, 2);
            //ChoosingService chooser = new ChoosingService();
            //var resultList = new List<string>();
            //resultList = chooser.Random(currentRequest);
            //var resulString = "";
            //foreach (var item in resultList)
            //{
            //    resulString = resulString + item + "\n";
            //}


        }

        private void random_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Pick();
            
        }
    }
}