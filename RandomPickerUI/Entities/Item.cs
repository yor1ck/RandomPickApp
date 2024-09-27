﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPickerUI.Entities
{
    internal class Item
    {
        public Item(Group group, string name)
        {
            CurrentGroup  = group;
            Name = name;
        }
        public Group CurrentGroup { get; set; }
        public string Name { get; set; }
    }
}
