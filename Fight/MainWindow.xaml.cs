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
        private Brush _infoColor = Brushes.LightGreen;
        private Brush _attackColor = Brushes.LightYellow;
        private Brush _deathColor = Brushes.Tomato;
        private ItemCollection _currentRoundLog => (LogOutput.Children[0] as ListBox).Items;


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
            LogOutput.Children.Clear();
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
            ListBox round = new ListBox();
            LogOutput.Children.Insert(0, round);
            if (_step == 0)
            {
                _step++;
                leftAdd.Opacity = 0;
                rightAdd.Opacity = 0;
                ListView leftListView = leftlist as ListView;
                ListView rightListView = rightlist as ListView;
                GridView leftGridView = leftListView.View as GridView;
                GridView rightGridView = rightListView.View as GridView;
                listView_SizeChanged(leftListView, null);
                listView_SizeChanged(rightListView, null);

                for (int i = 0; i < leftlist.Items.Count; i++)
                {
                    var fighter = leftlist.Items[i] as Fighter;
                    army1.Fighters.Add(fighter);
                }
                for (int i = 0; i < rightlist.Items.Count; i++)
                {
                    var fighter = rightlist.Items[i] as Fighter;
                    army2.Fighters.Add(fighter);
                }
                StartBtn.Content = "Next Round";
            }
            if (army1.IsAlive && army2.IsAlive)
            {
                _controller.Round(army1, army2, RoundOverLog);
                LogDelimiter();
                SortListView(rightlist);
                SortListView(leftlist);
                if (!army1.IsAlive || !army2.IsAlive)
                {
                    SortListView(rightlist);
                    SortListView(leftlist);
                    GameResult(army1, army2);
                    StartBtn.IsEnabled = false;
                }
            }
        }

        public void SortListView(ListView listView)
        {
            listView.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("IsAlive", System.ComponentModel.ListSortDirection.Descending));
        }

        public void AttackResult(Fighter fighter1, Fighter fighter2, int damage)
        {
            var content = $"{fighter1._Type} #{fighter1.ID} caused {damage} to {fighter2._Type} #{fighter2.ID}: Fatal {!fighter2.IsAlive} ({fighter2.Health + damage}/{fighter2.Health})";
            if (fighter2.IsAlive)
            {
                _currentRoundLog.Add(new ListBoxItem { Content = content, Background = _attackColor });
            }
            else
            {
                _currentRoundLog.Add(new ListBoxItem { Content = content, Background = _deathColor });
            }
        }

        public void MissResult(Fighter fighter)
        {
            var content = $"{fighter._Type} #{fighter.ID} has missed";
            _currentRoundLog.Add(new ListBoxItem { Content = content, Background = _infoColor });
        }

        public void CastingResult(string army1, string army2)
        {
            var content = $"Casting lots";
            var content1 = $"{army1} goes first. {army2} goes second.";
            _currentRoundLog.Add(new ListBoxItem { Content = content, Background = _infoColor });
            _currentRoundLog.Add(new ListBoxItem { Content = content1, Background = _infoColor });
        }

        public void ArmyResult(string name, int alive1, int deadman1, int totD1)
        {
            var content = $"{name} has a {alive1} alive and a {deadman1} were killed";
            var content1 = $"Total damage by {name} is {totD1}";
            _currentRoundLog.Add(new ListBoxItem { Content = content, Background = _infoColor });
            _currentRoundLog.Add(new ListBoxItem { Content = content1, Background = _infoColor });
        }
        public void TotalResult(int alive, int deadman, int totD)
        {
            var content = $"Total damage for round is {totD}";
            var content1 = $"A total of {deadman} people were killed";
            var content2 = $"A total of {alive} people still alive";
            _currentRoundLog.Add(new ListBoxItem { Content = content, Background = _infoColor });
            _currentRoundLog.Add(new ListBoxItem { Content = content1, Background = _infoColor });
            _currentRoundLog.Add(new ListBoxItem { Content = content2, Background = _infoColor });
        }

        public void GameResult(Army army1, Army army2)
        {
            if (army1.IsAlive)
            {
                var content = $"Game Over {army2.Name} is Dead";
                var content1 = $"{army1.Name} is Winner";
                _currentRoundLog.Add(new ListBoxItem { Content = content, Background = _infoColor });
                _currentRoundLog.Add(new ListBoxItem { Content = content1, Background = _infoColor });
            }
            else
            {
                var content = $"Game Over {army1.Name} is Dead";
                var content1 = $"{army2.Name} is Winner";
                _currentRoundLog.Add(new ListBoxItem { Content = content, Background = _infoColor });
                _currentRoundLog.Add(new ListBoxItem { Content = content1, Background = _infoColor });
            }
        }

        public void FastestTeamInfo(string name1, int count1, string name2, int count2)
        {
            var content = $"====> Attack {name1} count is {count1} on {name2} count is {count2}";
            _currentRoundLog.Add(new ListBoxItem { Content = content, Background = _infoColor });
        }

        public void RoundOverLog(string action)
        {
            var content = action;
            _currentRoundLog.Add(new ListBoxItem { Content = content, Background = _infoColor });
        }

        public void LogDelimiter()
        {
            var content = $"_-_-_-_-_-_-_-_-_-_-";
            _currentRoundLog.Add(new ListBoxItem { Content = content, Background = Brushes.LightGray });
        }
    }
}
