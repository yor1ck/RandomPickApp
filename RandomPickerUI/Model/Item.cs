using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPickerUI.Model
{
    public class Item
    {
        public Item(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }
}