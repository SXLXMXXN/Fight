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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller _controller;
        public Army army1 = new Army("Attackers");
        public Army army2 = new Army("Defenders");
        private int _step = 0;

        public MainWindow()
        {
            InitializeComponent();
            _controller = new Controller(this);
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button; 
            AddPerson add = new AddPerson(this, btn.Name, _controller);
            add.Show();
            this.IsEnabled = false;
        }

        private void Reset_Btn_Click(object sender, RoutedEventArgs e)
        {
            _step = 0;
            StartBtn.IsEnabled = true;
            leftlist.Items.Clear();
            rightlist.Items.Clear();
            LogOutput.Items.Clear();
            army1.Fighters.Clear();
            army2.Fighters.Clear();
            army1.IsAlive = true;
            army2.IsAlive = true;
            StartBtn.Content = "Start";
            _controller.LeftID = 0;
            _controller.RightID = 0;
            leftAdd.Opacity = 1;
            rightAdd.Opacity = 1;

            ListView leftListView = leftlist as ListView;
            ListView rightListView = rightlist as ListView;
            GridView leftGridView = leftListView.View as GridView;
            GridView rightGridView = rightListView.View as GridView;
            listView_SizeChanged(leftListView, null);
            listView_SizeChanged(rightListView, null);
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var prnt = btn.DataContext as Fighter;
            for(int i = 0; i < leftlist.Items.Count; i++)
            {
                if (prnt == leftlist.Items[i])
                {
                    leftlist.Items.RemoveAt(i);
                }
            }
            for (int i = 0; i < rightlist.Items.Count; i++)
            {
                if (prnt == rightlist.Items[i])
                {
                    rightlist.Items.RemoveAt(i);
                }
            }
        }

        private void listView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            GridView gView = listView.View as GridView;
            var workingWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth;
            if (_step == 0)
            {
                var col1 = 0.10;
                var col2 = 0.20;
                var col3 = 0.15;
                var col4 = 0.15;
                var col5 = 0.15;
                var col6 = 0.10;
                var col7 = 0.15;

                gView.Columns[0].Width = workingWidth * col1;
                gView.Columns[1].Width = workingWidth * col2;
                gView.Columns[2].Width = workingWidth * col3;
                gView.Columns[3].Width = workingWidth * col4;
                gView.Columns[4].Width = workingWidth * col5;
                gView.Columns[5].Width = workingWidth * col6;
                gView.Columns[6].Width = workingWidth * col7;
            }
            else
            { 
                var col1 = 0.10;
                var col2 = 0.30;
                var col3 = 0.15;
                var col4 = 0.15;
                var col5 = 0.15;
                var col6 = 0.15;
                var col7 = 0;

                gView.Columns[0].Width = workingWidth * col1;
                gView.Columns[1].Width = workingWidth * col2;
                gView.Columns[2].Width = workingWidth * col3;
                gView.Columns[3].Width = workingWidth * col4;
                gView.Columns[4].Width = workingWidth * col5;
                gView.Columns[5].Width = workingWidth * col6;
                gView.Columns[6].Width = workingWidth * col7;
            }
            
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (_step == 0)
            {
                leftAdd.Opacity = 0;
                rightAdd.Opacity = 0;
                _step++;
                ListView leftListView = leftlist as ListView;
                ListView rightListView = rightlist as ListView;
                GridView leftGridView = leftListView.View as GridView;
                GridView rightGridView = rightListView.View as GridView;
                listView_SizeChanged(leftListView, null);
                listView_SizeChanged(rightListView, null);

                for (int i = 0; i < leftlist.Items.Count; i++)
                {
                    var prnt = leftlist.Items[i] as ListViewItem;
                    var res = prnt.Content as Fighter;
                    army1.Fighters.Add(res);
                }
                for (int i = 0; i < rightlist.Items.Count; i++)
                {
                    var prnt = rightlist.Items[i] as ListViewItem;
                    var res = prnt.Content as Fighter;
                    army2.Fighters.Add(res);
                }
                StartBtn.Content = "Next Round";
                
            }
            LogOutput.Items.Clear();
            if (army1.IsAlive && army2.IsAlive)
            {
                _controller.Round(army1, army2);
                CheckDead(rightlist);
                CheckDead(leftlist);
            }
            else
            {
                CheckDead(rightlist);
                CheckDead(leftlist);
                GameResult(army1, army2);
                StartBtn.IsEnabled = false;
            }
        }

        public void CheckDead(ListView listView)
        {
            int deadCount = 0;
            for (int i = 0; i < listView.Items.Count - deadCount; i++)
            {
                var item = listView.Items[i] as ListViewItem;
                var fighter = item.Content as Fighter;
                if (fighter.Health < 1)
                {
                    item.Background = Brushes.Red;
                        
                    listView.Items.MoveCurrentToLast();
                    i--;
                    deadCount++;
                }
                
                
            }
            

        }


        public void AttackResult(Fighter fighter1, Fighter fighter2, int damage)
        {
            LogOutput.Items.Add($"{fighter1._Type} #{fighter1.ID} caused {damage} to {fighter2._Type} #{fighter2.ID}: Fatal {!fighter2.IsAlive}");
        }

        public void MissResult(Fighter fighter)
        {
            LogOutput.Items.Add($"{fighter._Type} #{fighter.ID} has missed");
        }

        public void CastingResult(string army1, string army2)
        {
            LogOutput.Items.Add($"Casting lots");
            LogOutput.Items.Add($"{army1} goes first. {army2} goes second.");
        }

        public void ArmyResult(string name, int alive1, int deadman1, int totD1)
        {
            LogOutput.Items.Add($"{name} has a {alive1} alive and a {deadman1} were killed");
            LogOutput.Items.Add($"Total damage by {name} is {totD1}");
        }

        public void TotalResult(int alive, int deadman, int totD)
        {
            LogOutput.Items.Add($"Total damage for round is {totD}");
            LogOutput.Items.Add($"A total of {deadman} people were killed");
            LogOutput.Items.Add($"A total of {alive} people still alive");
        }

        public void GameResult(Army army1, Army army2)
        {
            if (army1.IsAlive)
            {
                LogOutput.Items.Add($"Game Over {army2.Name} is Dead");
                LogOutput.Items.Add($"{army1.Name} is Winner");
            }
            else
            {
                LogOutput.Items.Add($"Game Over {army1.Name} is Dead");
                LogOutput.Items.Add($"{army2.Name} is Winner");
            }
        }

        public void ConsoleProbel()
        {
            LogOutput.Items.Add("__________");
        }

        public void BolwoyProbel()
        {
            LogOutput.Items.Add("\r\noooooooooooooooooooooooooooooooooooooooooooooooooooooooooo\r\n");
        }
    }
}
