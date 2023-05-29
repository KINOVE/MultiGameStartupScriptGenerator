using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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

namespace GameLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Target> targets = new ObservableCollection<Target>();
        
        public MainWindow()
        {
            InitializeComponent();
            AllStartupItems.ItemsSource = targets;
        }


        // 对targets进行操作
        public void DeleteTargetByIndex(int index)
        {
            targets.RemoveAt(index);
        }

        private void CreateBatFile(object sender, RoutedEventArgs e)
        {
            string fileName = "StarRailLauncherBat" + ".bat";
            string fileContent = "";
            foreach (var target in targets)
            {
                if(target.Path != null)
                {
                    fileContent += "start \"\" " + target.Path + " " + target.StartUpParameters + "\n";
                }
            }
            MessageBox.Show(fileContent);
            File.WriteAllText(fileName, fileContent);
        }

        public void ShowTargets()
        {
            MessageBox.Show("1");
        }

        private void Add_Test(object sender, RoutedEventArgs e)
        {
            targets.Add(new Target() { Name = "待命名"});
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            // Begin dragging the window
            this.DragMove();
        }
    }
    public class Target
    { 
        public string? Name { get; set; }
        public string? Path { get; set; }
        public string? StartUpParameters { get; set; }
    }
}
