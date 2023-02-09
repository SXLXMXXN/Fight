using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight
{
    public class Controller
    {
        public static string FileInput(string name, int count)
        {
            string input = "";
            string path = $"C:\\Users\\SOLOMOON\\Documents\\Lessons\\{name}.txt";

            if (File.Exists(path))
            {
                string[] Fighters = File.ReadAllLines(path);
                input = Fighters[count];
            }
            else
            {
                return "manual input";
            }
            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length == 4)
            {
                input = $"add " + input;
            }
            return input;
        }
        //public static bool TryParseAmount(string word, int low, int high, out int output)
        //{
        //    bool result = Int32.TryParse(word, out output);
        //    if (word == "*")
        //    {
        //        Random rnd = new Random();
        //        output = rnd.Next(low, high);
        //        result = true;
        //    }
        //    else if (result == false)
        //    {
        //        output = 0;
        //        return false;
        //    }
        //    output = Math.Clamp(output, low, high - 1);
        //    return true;
        //}
        public static List<Fighter> BubbleSortBySpeed(List<Fighter> army)
        {
            var len = army.Count;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (army[j].Speed < army[j + 1].Speed)
                    {
                        var temp = army[j];
                        army[j] = army[j + 1];
                        army[j + 1] = temp;
                    }
                }
            }
            return army;
        }
        public static void Casting(Army army, Army army1, Action<string, string> callback)
        {
            Random rnd = new Random();
            int r = rnd.Next(0, 10);
            if (r < 5)
            {
                callback(army.Name, army1.Name);
                army.IsFirst = true;
                army1.IsFirst = false;
            }
            else
            {
                callback(army1.Name, army.Name);
                army1.IsFirst = true;
                army.IsFirst = false;
            }
        }
        
        public static int Atack(Army army1, Army army2, float percent, Action<Fighter, Fighter, int> callbacksuccess, Action<Fighter> callbackmiss)
        {
            var fastest = army1.GetListOfFastest(percent);
            var alive = army2.GetListOfAlive();
            Console.WriteLine($"====> Attack {army1.Name} count is {fastest.Count} on {army2.Name } count is {alive.Count}");
            int totalDamage = 0;
            for (int i = 0; i < fastest.Count; i++)
            {
                int miss = 20 - (fastest[i].Level * 2);
                Random rnd = new Random();
                int r = rnd.Next(0, 100);
                if (r > miss)
                {
                    if (alive.Count != 0)
                    {
                        int d = CalcDamage(fastest[i]);
                        int choosenfighter = rnd.Next(0, alive.Count);
                        alive[choosenfighter].AddHealth(-d);
                        fastest[i].HasMoved = true;
                        callbacksuccess(fastest[i], alive[choosenfighter], d);
                        totalDamage += d;
                        if (!alive[choosenfighter].IsAlive)
                        {
                            alive.RemoveAt(choosenfighter);
                        }
                    }
                    else
                    {
                        army2.IsAlive = false;
                        break;
                    }
                }
                else
                {
                    callbackmiss(fastest[i]);
                }
            }
            return totalDamage;
        }
        public static int CalcDamage(Fighter fighter)
        {
            int Damage = (int)Math.Ceiling(5f + (((float)fighter.Level / 2f) * (float)fighter.Ammunition));
            return Damage;
        }
        public static void ReturnHasMoved(Army army)
        {
            for (int i = 0; i < army.Fighters.Count; i++)
            {
                army.Fighters[i].HasMoved = false;
            }
            army.HasMoved = false;
        }
        public static void RoundArmyResult(Army army1, Action<string, int, int, int> callback)
        {
            int alive1 = army1.GetListOfAlive().Count;
            int deadman1 = army1.Fighters.Count - alive1;
            callback(army1.Name, alive1, deadman1, army1.TotalDamage);
        }
        public static void RoundTotalResult(Army army1, Army army2, Action<int, int, int> callback)
        {
            int alive = army1.GetListOfAlive().Count + army2.GetListOfAlive().Count;
            int deadman = (army1.Fighters.Count + army2.Fighters.Count) - alive;
            int totalDamage = army1.TotalDamage + army2.TotalDamage;
            callback(alive, deadman, totalDamage);
            ReturnHasMoved(army1);
            ReturnHasMoved(army2);
        }
    }
}
