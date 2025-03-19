using RandomPickerUI.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPickerUI.Model
{
    public class FullList
    {
        public FullList(string name)
        {
            this.Name = name;
            this.Groups = new ObservableCollection<Group>();
            this.Items = new ObservableCollection<Item>();
        }
        public string Name { get; set; }
        public ObservableCollection<Group>Groups { get; set; }
        public ObservableCollection<Item> Items { get; set; }

    }

}
