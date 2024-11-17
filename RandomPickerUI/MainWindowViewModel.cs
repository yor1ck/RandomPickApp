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
        private Group currentGroup;

        public Group CurrentGroup
        {
            get { return currentGroup; }
            set
            {
                currentGroup = value;
                RaisePropertyChanged(nameof(CurrentGroup));
            }
        }
        private Item currentItem;

        public Item CurrentItem
        {
            get { return currentItem; }
            set { currentItem = value;
                RaisePropertyChanged(nameof(CurrentItem));
            }
        }
        private Item currentGroupItem;

        public Item CurrentGroupItem
        {
            get { return currentGroupItem; }
            set
            {
                currentGroupItem = value;
                RaisePropertyChanged(nameof(CurrentGroupItem));
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
            sets = new ObservableCollection<Set>();
            var testSet = new Set("Test");
            testSet.Items.Add(new Item("One"));
            testSet.Items.Add(new Item("Two"));
            testSet.Items.Add(new Item("Three"));
            testSet.Items.Add(new Item("Four"));
            testSet.Items.Add(new Item("Five"));
            var group1 = new Group("group 1");
            var group2 = new Group("group 2");
            var testArray = testSet.Items.ToArray();
            group1.Items.Add(testArray[0]);
            group1.Items.Add(testArray[1]);
            group1.Items.Add(testArray[2]);
            testSet.Groups.Add(group1);
            group2.Items.Add(testArray[2]);
            group2.Items.Add(testArray[4]);
            testSet.Groups.Add(group2);
            Sets.Add( testSet );
            var testSet2 = new Set("Test2");
            testSet2.Items.Add(new Item("One 2"));
            testSet2.Items.Add(new Item("Two 2"));
            testSet2.Items.Add(new Item("Three 2"));
            Sets.Add(testSet2);
            currentSet = Sets.First();
            currentItem = Sets.First().Items.First();
            currentGroup = currentSet.Groups.First();
        }
        public void PickFromSet()
        {
            var currentItems = new List<Item>();
            currentItems = CurrentSet.Items.ToList();
            var picker = new PickRequest(currentItems,3);
            ChoosingService chooser = new ChoosingService();
            var resultList = new List<string>();
            resultList = chooser.Random(picker);
            ResultString = new ObservableCollection<string>(resultList);

        }

        internal void AddItemToSet()
        {
            var newItem = new Item("New Item");
            currentSet.Items.Add(newItem);
            CurrentItem = newItem;
        }
        internal void DeleteItemFromSet()
        {
            currentSet.Items.Remove(CurrentItem);
        }

        internal void AddSet()
        {
            var newSet = new Set("New Set");
            var newItem = new Item("New Item");
            newSet.Items.Add(newItem);
            Sets.Add(newSet);
            CurrentSet = newSet;
        }

        internal void DeleteSet()
        {
            Sets.Remove(CurrentSet);
        }

        internal void PickFromGroup()
        {
            var currentItems = new List<Item>();
            currentItems = CurrentGroup.Items.ToList();
            var picker = new PickRequest(currentItems, 2);
            ChoosingService chooser = new ChoosingService();
            var resultList = new List<string>();
            resultList = chooser.Random(picker);
            ResultString = new ObservableCollection<string>(resultList);
        }

        internal void AddItemToGroup()
        {
            CurrentGroup.Items.Add(CurrentItem);
        }

        internal void DeleteItemFromGroup()
        {
            CurrentGroup.Items.Remove(CurrentGroupItem);      
        }
    }
}
