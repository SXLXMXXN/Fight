using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight
{
    public class Fighter
    {
        public enum WarriorType { Infantry, Archer, Cavalry };
        public WarriorType _Type;
        public int Level { get; private set; }
        public int Ammunition { get; private set; }
        public int Speed { get; private set; }
        public int Health { get; private set; }
        public int ID;
        public bool HasMoved = false;


        public Fighter(WarriorType t, int l, int a, int s, int id) { _Type = t; Level = l; Ammunition = a; Speed = s; ID = id; InitHealth(); }

        public static int MinLevel => 1;
        public static int MaxLevel => 6;
        public static int MinAmmunition => 1;
        public static int MaxAmmunition => 6;
        public bool IsAlive => Health > 0;
        public void AddHealth(int health)
        {
            Health += health;
        }
        public static int GetMinSpeed(WarriorType t)
        {
            if (t == WarriorType.Cavalry)
            {
                return 4;
            }
            return 1;
        }
        public static int GetMaxSpeed(WarriorType t)
        {
            if (t == WarriorType.Cavalry)
            {
                return 8;
            }
            return 5;
        }
        public static int GetID(int id)
        {
            id++;
            return id;
        }

        public static string TypeInfantry => WarriorType.Infantry.ToString().ToLower();
        public static string TypeArcher => WarriorType.Archer.ToString().ToLower();
        public static string TypeCavalry => WarriorType.Cavalry.ToString().ToLower();
        //public static WarriorType FromString(string source)
        //{
        //    return Enum.Parse<WarriorType>(source, true);
        //}

        public void InitHealth()
        {
            Health = 10 + (Level * Ammunition);
        }

        public override string ToString()
        {
            return $"[{ID}] [{_Type}] lvl [{Level}] ammo [{Ammunition}] spd [{Speed}] health [{Health}]";
        }
    }
}
