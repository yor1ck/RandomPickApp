using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPickerUI.Entities
{
    internal class Item
    {
        public Item(string name)
        {
              Name = name;
        }
        public string Name { get; set; }
    }
}
