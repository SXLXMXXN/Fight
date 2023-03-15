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
        public string Type => _Type.ToString();
        public int Level { get;  set; }
        public int Ammunition { get;  set; }
        public int Speed { get;  set; }
        public int Health { get;  set; }
        public int ID { get; set; }
        public bool HasMoved = false;

        public Fighter(WarriorType t, int l, int a, int s, int id) { _Type = t; Level = l; Ammunition = a; Speed = s; InitHealth(); ID = id; }

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

        public static string TypeInfantry => WarriorType.Infantry.ToString().ToLower();
        public static string TypeArcher => WarriorType.Archer.ToString().ToLower();
        public static string TypeCavalry => WarriorType.Cavalry.ToString().ToLower();
        public static WarriorType FromString(string source)
        {
            bool result = Enum.TryParse(source, true, out WarriorType type);
            
            return type;
        }

        public void InitHealth()
        {
            Health = 10 + (Level * Ammunition);
        }

        public override string ToString()
        {
            return $"[{_Type}] lvl [{Level}] ammo [{Ammunition}] spd [{Speed}] health [{Health}]";
        }
    }
}
