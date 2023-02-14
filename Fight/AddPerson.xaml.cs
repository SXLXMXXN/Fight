using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fight
{
    /// <summary>
    /// Interaction logic for AddPerson.xaml
    /// </summary>
    public partial class AddPerson : Window
    {
        private Random _rnd = new Random();
        MainWindow main;

        public AddPerson(MainWindow mainWindow)
        {
            main = mainWindow;
            InitializeComponent();
        }

        private int InputCheck(string input, int min, int max)
        {
            int result;
            if (string.IsNullOrEmpty(input) || char.IsLetter(input[0]))
            {
                return result = _rnd.Next(min, max);
            }
            else
            {
                int temp = Convert.ToInt32(input);
                if (temp >= max)
                {
                    return max - 1;
                }
                else if (temp < min)
                {
                    return min;
                }
                return temp;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int amount;
            bool amountresult = true;
            string type;
            int level;
            int ammo;
            int speed;
            for(int i = 0; i < Amount.Text.Length; i++)
            {
                if (char.IsLetter(Amount.Text[i]))
                {
                    amountresult = false;
                    break;
                }
            }
            if (string.IsNullOrEmpty(Amount.Text) || !amountresult)
            {
                amount = 1;
            }
            else
            {
                amount = Convert.ToInt32(Amount.Text);
            }
            for (int i = 0; i < amount ; i++)
            {
                if (Random.IsSelected)
                {
                    string[] types = new string[3] { Fighter.TypeInfantry, Fighter.TypeArcher, Fighter.TypeCavalry };
                    int rtype = _rnd.Next(0, 3);
                    type = types[rtype];
                }
                else
                {
                    type = Type.Text;
                    
                }
                level = InputCheck(Level.Text, Fighter.MinLevel, Fighter.MaxLevel);
                ammo = InputCheck(Ammo.Text, Fighter.MinAmmunition, Fighter.MaxAmmunition);
                speed = InputCheck(Speed.Text, Fighter.GetMinSpeed(Fighter.FromString(type)), Fighter.GetMaxSpeed(Fighter.FromString(type)));
                Fighter fighter = new Fighter(Fighter.FromString(type), level, ammo, speed);
                main.leftlist.Items.Add(fighter);
                Level.Text = null;
            }    

            

            
                
        }
    }
}
