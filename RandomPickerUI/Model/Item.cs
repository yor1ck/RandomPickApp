using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPickerUI.Model
{
    internal class Item
    {
        public Item(string name)
        {
            this.Name = name;
            this.Id = Guid.NewGuid();
        }
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}