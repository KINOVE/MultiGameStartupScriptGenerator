using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
using System.Xml.Linq;

namespace GameLauncher
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void DeleteTarget(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            if (button != null)
            {
                // 获取父级
                DependencyObject parent = VisualTreeHelper.GetParent(this);
                // 获取itemsControl
                ItemsControl itemsControl = ItemsControl.ItemsControlFromItemContainer(parent);
                // 获取index
                var index = itemsControl.ItemContainerGenerator.IndexFromContainer(parent);

                //MessageBox.Show(index.ToString());

                MainWindow mainWindow = (MainWindow)Window.GetWindow(this);

                //mainWindow.ShowTargets();
                mainWindow.DeleteTargetByIndex(index);

            }
        }

        private void Rename(object sender, RoutedEventArgs e)
        {
            this.textBlockParent.Visibility = Visibility.Collapsed;
            this.textBoxParent.Visibility = Visibility.Visible;
        }

        private void Rename_Check(object sender, RoutedEventArgs e)
        {
            this.textBlockParent.Visibility = Visibility.Visible;
            this.textBoxParent.Visibility = Visibility.Collapsed;
        }
    }
}
