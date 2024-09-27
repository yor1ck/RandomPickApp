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
         public List<string> Random(Request CurrentRequest)
        {
            var randomList = CurrentRequest.Items;
            var groups = CurrentRequest.Items.Select(x => x.CurrentGroup).Distinct().ToList();
            var choosed = new List<string>();
            for (int i = 0; i < CurrentRequest.TimesToChoose; i++)
            {
                string itemName;
                int listLenght = randomList.Count;
                var randomArray = randomList.ToArray();
                var rand = new Random();
                int itemId = rand.Next(0, randomArray.Length);
                itemName = randomArray[itemId].Name;
                choosed.Add(itemName);
                randomList.Remove(randomList[itemId]);
            }
                       
            return choosed;
        }
    }
}
