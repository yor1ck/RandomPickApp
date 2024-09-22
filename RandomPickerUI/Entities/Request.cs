using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPickerUI.Entities
{
    internal class Request
    {
        public Request(List<Item> items, int times)
        {
            Items = items;
            TimesToChoose =times;
        }
        public List<Item> Items { get; set; }
        public int TimesToChoose { get; set; }
    }
}
