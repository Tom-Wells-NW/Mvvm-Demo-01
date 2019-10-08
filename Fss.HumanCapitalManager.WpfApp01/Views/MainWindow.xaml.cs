using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Printing;
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

namespace Fss.HumanCapitalManager.WpfApp01.Views
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

        private void UpdateAssociatesButton_Click(object sender, RoutedEventArgs e)
        {
            AssociatesWindow associatesView = new AssociatesWindow();
            associatesView.Show();
        }

        private void UpdateSkillsButton_Click(object sender, RoutedEventArgs e)
        {
            SkillsWindow skillsView = new SkillsWindow();
            skillsView.Show();
        }

    }
}
