using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPickerUI.Model
{
    public class Group
    {
        public Group(string name,Set parentSet)
        {
            this.Name = name;
            this.ParentSet = parentSet;
            this.Items = new ObservableCollection<Item>();
        }
        public string Name { get; set; }
        public Set ParentSet { get; set; }
        public ObservableCollection<Item> Items { get; set; }


    }
}
