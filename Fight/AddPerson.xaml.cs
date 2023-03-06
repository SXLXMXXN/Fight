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
        private MainWindow _main;
        private Controller _controller;
        private string _btnName;

        public AddPerson(MainWindow mainWindow, string buttonName, Controller controller)
        {
            _main = mainWindow;
            _btnName = buttonName;
            _controller = controller;
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
                if (_btnName == "leftAdd")
                {
                    Fighter fighter = new Fighter(Fighter.FromString(type), level, ammo, speed, _controller.GetID("left"));
                    _main.leftlist.Items.Add(new ListViewItem() { Content = fighter });
                }
                else
                {
                    Fighter fighter = new Fighter(Fighter.FromString(type), level, ammo, speed, _controller.GetID("right"));
                    _main.rightlist.Items.Add(new ListViewItem() { Content = fighter});
                }
                Level.Text = null;
            }        
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _main.IsEnabled = true;
        }
    }
}
