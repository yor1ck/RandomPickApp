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
        public Group(string name)
        {
            this.Name = name;
            this.Items = new ObservableCollection<Item>();
        }
        public string Name { get; set; }
        public ObservableCollection<Item> Items { get; set; }


    }
}
