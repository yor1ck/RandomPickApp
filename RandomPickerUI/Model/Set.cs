using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPickerUI.Model
{
    internal class Set
    {
        public Set(string name)
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
