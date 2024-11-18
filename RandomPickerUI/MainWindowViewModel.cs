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
        private int timesFromSet;

        public int TimesFromSet
        {
            get { return timesFromSet; }
            set
            {
                timesFromSet = value;
                RaisePropertyChanged(nameof(TimesFromSet));
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
            string fileName = "Sets.json";
            string jsonString = File.ReadAllText(fileName);
            List<Set> SetsFromJson  = JsonSerializer.Deserialize<List<Set>>(jsonString)!;
            Sets=  new ObservableCollection<Set>(SetsFromJson);
            currentSet = Sets.First();
            currentItem = Sets.First().Items.First();
            currentGroup = currentSet.Groups.First();
            TimesFromSet = 1;
            TimesFromGroup = 1;
        }
        public void PickFromSet()
        {
            var currentItems = new List<Item>();
            currentItems = CurrentSet.Items.ToList();
            if (TimesFromSet > 0)
            {
                var picker = new PickRequest(currentItems, TimesFromSet);
                ChoosingService chooser = new ChoosingService();
                var resultList = new List<string>();
                resultList = chooser.Random(picker);
                ResultString = new ObservableCollection<string>(resultList);
            }

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
            CurrentGroup.Items.Add(CurrentItem);
        }

        internal void DeleteItemFromGroup()
        {
            CurrentGroup.Items.Remove(CurrentGroupItem);            
        }
        internal void AddGroup()
        {
            var newGroup = new Group("New Group");
            CurrentSet.Groups.Add(newGroup);
            CurrentGroup = newGroup;
        }
        internal void DeleteGroup()
        {
            CurrentSet.Groups.Remove(CurrentGroup);
        }

        internal void SaveToFile()
        {
            string fileName ="Sets.json";
            string jsonString = JsonSerializer.Serialize(Sets);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
