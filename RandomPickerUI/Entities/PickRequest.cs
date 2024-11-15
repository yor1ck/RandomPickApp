using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomPickerUI.Model;

namespace RandomPickerUI.Entities
{
    public class PickRequest
    {
        public PickRequest(List<Item> items, int times)
        {
            TimesToChoose =times;
            Things = items.Select(x => new Thing(x.Name)).ToList();

        }
        public PickRequest(List<Thing> things, int times)
        {
            Things = things;
            TimesToChoose = times;
        }
        public List<Thing> Things { get; set; }
        public int TimesToChoose { get; set; }

    }
}
