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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace Books_and_Magazines
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
  //          this.Change_File();
  //          info = LoadFromBinaryFile("TEXT.txt");
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MAIN wn = new MAIN();
            wn.Show();
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
