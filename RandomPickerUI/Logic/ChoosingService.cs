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
         public List<string> Random(PickRequest CurrentRequest)
        {
            var randomList = CurrentRequest.Things;            
            var choosed = new List<string>();
            for (int i = 0; i < CurrentRequest.TimesToChoose; i++)
            {
                if (randomList.Count == 0)
                {
                    break;
                }
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
