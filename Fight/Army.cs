using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight
{
    public class Army
    {
        public string Name;
        public bool IsFirst;
        public bool HasMoved = false;
        public bool IsAlive = true;
        public int TotalDamage = 0;

        public Army(string name) { Name = name; }

        public List<Fighter> Fighters = new List<Fighter>();
        public List<Fighter> GetListOfFastest(float procent)
        {
            Controller.BubbleSortBySpeed(Fighters);
            List<Fighter> fastest = new List<Fighter>();
            var to = (int)Math.Ceiling((float)Fighters.Count / 100f) * procent;
            for (int i = 0; i < Fighters.Count; i++)
            {
                if (!Fighters[i].HasMoved && Fighters[i].IsAlive)
                {
                    fastest.Add(Fighters[i]);
                    if (fastest.Count == to)
                    {
                        break;
                    }
                }
            }
            if (fastest.Count == 0)
            {
                HasMoved = true;
            }
            return fastest;
        }
        public List<Fighter> GetListOfAlive()
        {
            List<Fighter> alive = new List<Fighter>();
            for (int i = 0; i < Fighters.Count; i++)
            {
                if (Fighters[i].IsAlive)
                {
                    alive.Add(Fighters[i]);
                }
            }
            return alive;
        }
        
    }
}
