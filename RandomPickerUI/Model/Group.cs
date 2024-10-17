using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPickerUI.Model
{
    internal class Group
    {
        public Group(string name,Set set)
        {
            this.Name = name;
            this.ParentSet = set;
            this.Items = new ObservableCollection<Item>();
        }
        public string Name { get; set; }
        public Set ParentSet { get; set; }
        public ObservableCollection<Item> Items { get; set; }

        public void AddItem(Item item)
        {
            if (this.ParentSet.Items.Contains(item))
            {
                Items.Add(item);
            }
            else
            {
                this.ParentSet.Items.Add(item);
                Items.Add(item);
            }
        }
    }
}
