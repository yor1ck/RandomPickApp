using RandomPickerUI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPickerUI.Logic
{
    internal class ChoosingService
    {
        public ChoosingService (Request request)
        {
            this.CurrentRequest = request;
        }
        public Request CurrentRequest { get; set; }
        public List<string> Random()
        {
            var choosed = new List<string>();
            for (int i = 0; i < CurrentRequest.TimesToChoose; i++)
            {
                string itemName;
                int listLenght = CurrentRequest.Items.Count;
                var rand = new Random();
                int itemId = rand.Next(1, listLenght +1);
                itemName = CurrentRequest.Items.Single( current => current.Id == itemId ).Name;
                choosed.Add(itemName);
            }
                       
            return choosed;
        }
    }
}
