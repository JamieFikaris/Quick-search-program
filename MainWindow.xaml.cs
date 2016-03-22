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

namespace Dads_Program
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Functions FunctionClass = new Functions();
            FunctionClass.Input = textBox.Text;
            FunctionClass.createFolder();
            FunctionClass.readAndSearch();
            
            List<string> foundLines = a.MyList; //set new list to foundStuff list from Class

            foreach (string text in foundLines)
            {
                listBox.Items.Add(text);
            }
        }
    }
}
