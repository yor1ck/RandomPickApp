using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomPickerUI.Entities;
using RandomPickerUI.Logic;
using RandomPickerUI.Model;

namespace RandomPickerUI
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<Set> sets;

        public ObservableCollection<Set> Sets
        {
            get { return sets; }
            set { sets = value;
                RaisePropertyChanged(nameof(Sets));
            }
        }
        private Set currentSet;

        public Set CurrentSet
        {
            get { return currentSet; }
            set { currentSet = value;
                RaisePropertyChanged(nameof(CurrentSet));
            }
        }
        private Item currentItem;

        public Item CurrentItem
        {
            get { return currentItem; }
            set { currentItem = value;
                RaisePropertyChanged(nameof(currentItem));
            }
        }
        private ObservableCollection<string> resultString;
        public ObservableCollection<string> ResultString
        {
            get { return resultString; }
            set
            {
                resultString = value;
                RaisePropertyChanged(nameof(ResultString));
            }
        }

        public MainWindowViewModel()
        {
            Sets = new ObservableCollection<Set>();
            var testSet = new Set("Test");
            testSet.Items.Add(new Item("One"));
            testSet.Items.Add(new Item("Two"));
            testSet.Items.Add(new Item("Three"));
            testSet.Items.Add(new Item("Four"));
            testSet.Items.Add(new Item("Five"));
            Sets.Add( testSet );
            CurrentSet = Sets.First();
            CurrentItem = Sets.First().Items.First();
        }
        public void Pick()
        {
            var currentItems = new List<Item>();
            currentItems = CurrentSet.Items.ToList();
            var picker = new PickRequest(currentItems,3);
            ChoosingService chooser = new ChoosingService();
            var resultList = new List<string>();
            resultList = chooser.Random(picker);
            ResultString = new ObservableCollection<string>(resultList);

        }

    }
}
