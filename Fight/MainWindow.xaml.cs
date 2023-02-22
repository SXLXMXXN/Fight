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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button; 
            AddPerson add = new AddPerson(this, btn.Name);
            add.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            leftlist.Items.Clear();
            rightlist.Items.Clear();
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
            if (gView.Columns.Count == 6)
            {
                
                var col1 = 0.20;
                var col2 = 0.15;
                var col3 = 0.15;
                var col4 = 0.15;
                var col5 = 0.15;
                var col6 = 0.20;

                gView.Columns[0].Width = workingWidth * col1;
                gView.Columns[1].Width = workingWidth * col2;
                gView.Columns[2].Width = workingWidth * col3;
                gView.Columns[3].Width = workingWidth * col4;
                gView.Columns[4].Width = workingWidth * col5;
                gView.Columns[5].Width = workingWidth * col6;
            }
            else
            { 
                var col1 = 0.30;
                var col2 = 0.20;
                var col3 = 0.20;
                var col4 = 0.15;
                var col5 = 0.15;

                gView.Columns[0].Width = workingWidth * col1;
                gView.Columns[1].Width = workingWidth * col2;
                gView.Columns[2].Width = workingWidth * col3;
                gView.Columns[3].Width = workingWidth * col4;
                gView.Columns[4].Width = workingWidth * col5;
            }
            
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            ListView leftListView = leftlist as ListView;
            ListView rightListView = rightlist as ListView;
            GridView leftGridView = leftListView.View as GridView;
            GridView rightGridView = rightListView.View as GridView;

            leftGridView.Columns.RemoveAt(5);
            rightGridView.Columns.RemoveAt(5); 
        }
    }
}
