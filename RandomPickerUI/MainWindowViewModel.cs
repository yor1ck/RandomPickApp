using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        private ObservableCollection<FullList> fullLists;

        public ObservableCollection<FullList> FullLists
        {
            get { return fullLists; }
            set { fullLists = value;
                RaisePropertyChanged(nameof(FullLists));
            }
        }
        private FullList currentFullList;

        public FullList CurrentFullList
        {
            get { return currentFullList; }
            set { currentFullList = value;
                RaisePropertyChanged(nameof(CurrentFullList));
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
        private int timesFromList;

        public int TimesFromList
        {
            get { return timesFromList; }
            set
            {
                timesFromList = value;
                RaisePropertyChanged(nameof(TimesFromList));
            }
        }
        private int timesFromGroup;

        public int TimesFromGroup
        {
            get { return timesFromGroup; }
            set
            {
                timesFromGroup = value;
                RaisePropertyChanged(nameof(TimesFromGroup));
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
            string fileName = "Lists.json";
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                List<FullList> SetsFromJson = JsonSerializer.Deserialize<List<FullList>>(jsonString)!;
                fullLists = new ObservableCollection<FullList>(SetsFromJson);
                currentFullList = FullLists.First();
                currentItem = FullLists.First().Items.First();
                currentGroup = currentFullList.Groups.First();
                currentGroupItem = currentGroup.Items.First();
                resultString = new ObservableCollection<string>();
                TimesFromList = 1;
                TimesFromGroup = 1;
            }
            else
            {
                fullLists = new ObservableCollection<FullList>();
                var testSet = new FullList("Test");
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
                FullLists.Add(testSet);
                var testSet2 = new FullList("Test2");
                testSet2.Items.Add(new Item("One 2"));
                testSet2.Items.Add(new Item("Two 2"));
                testSet2.Items.Add(new Item("Three 2"));
                FullLists.Add(testSet2);
                currentFullList = FullLists.First();
                currentItem = FullLists.First().Items.First();
                currentGroup = currentFullList.Groups.First();
                currentGroupItem = currentGroup.Items.First();
                resultString = new ObservableCollection<string>();
                TimesFromList = 1;
                TimesFromGroup = 1;
            }
        }
        public void PickFromFullList()
        {
            var currentItems = new List<Item>();
            currentItems = CurrentFullList.Items.ToList();
            if (TimesFromList > 0)
            {
                var picker = new PickRequest(currentItems, TimesFromList);
                ChoosingService chooser = new ChoosingService();
                var resultList = new List<string>();
                resultList = chooser.Random(picker);
                ResultString = new ObservableCollection<string>(resultList);
            }

        }

        internal void AddItemToList()
        {
            if (CurrentFullList != null)
            {
                var newItem = new Item("New Item");
                CurrentFullList.Items.Add(newItem);
                CurrentItem = newItem;
            }
        }
        internal void DeleteItemFromList()
        {
            if (CurrentItem != null)
            {
                foreach (var group in currentFullList.Groups)
                {
                    var itemInGroup = group.Items.FirstOrDefault(item => item.Name == CurrentItem.Name);
                    if (itemInGroup != null)
                    {
                        group.Items.Remove(itemInGroup);
                    }

                }
                currentFullList.Items.Remove(CurrentItem);
            }
        }

        internal void AddFullList()
        {
            var newList = new FullList("New List");
            var newItem = new Item("New Item");
            newList.Items.Add(newItem);
            FullLists.Add(newList);
            CurrentFullList = newList;
        }

        internal void DeleteList()
        {
            if (CurrentFullList != null)
            {
                FullLists.Remove(CurrentFullList);
            }
        }

        internal void PickFromGroup()
        {
            var currentItems = new List<Item>();
            currentItems = CurrentGroup.Items.ToList();
            if (TimesFromGroup > 0)
            {
                var picker = new PickRequest(currentItems, TimesFromGroup);
                ChoosingService chooser = new ChoosingService();
                var resultList = new List<string>();
                resultList = chooser.Random(picker);
                ResultString = new ObservableCollection<string>(resultList);
            }
        }

        internal void AddItemToGroup()
        {
            if (CurrentItem != null && CurrentGroup!= null)
            {
                CurrentGroup.Items.Add(CurrentItem);
            }
        }

        internal void DeleteItemFromGroup()
        {
            if (CurrentGroupItem != null && CurrentGroup != null)
            {
                CurrentGroup.Items.Remove(CurrentGroupItem);
            }
        }
        internal void AddGroup()
        {
            if (CurrentFullList != null)
            {
                var newGroup = new Group("New Group");
                CurrentFullList.Groups.Add(newGroup);
                CurrentGroup = newGroup;
            }
        }
        internal void DeleteGroup()
        {
            if (CurrentFullList != null)
            {
                CurrentFullList.Groups.Remove(CurrentGroup);
            }
        }

        internal void SaveToFile()
        {
            string fileName ="Sets.json";
            string jsonString = JsonSerializer.Serialize(FullLists);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
