using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Engine
{
    public class HealingPotion : Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }
        public int AmountToHeal { get; set; }
        public HealingPotion(int id, string name, string namePlural, int amountToHeal) : base(id, name, namePlural) {
            AmountToHeal = amountToHeal;

        }

    }
}
