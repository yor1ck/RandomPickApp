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
        public MainWindow()
        {
            InitializeComponent();
            var testList = new List<Item>();
            testList.Add(new Item(1, "One"));
            testList.Add(new Item(2, "Two"));
            testList.Add(new Item(3, "Three"));
            testList.Add(new Item(4, "Four"));
            var currentRequest = new Request(testList, 2); 
            ChoosingService chooser = new ChoosingService();
            var resultList = new List<string>();
            resultList = chooser.Random(currentRequest);
            var resulString = "";
            foreach (var item in resultList)
            {
                resulString = resulString + item;
            }
            result.Text = resulString;
        }
    }
}