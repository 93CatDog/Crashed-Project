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

namespace Books_and_Magazines
{
    /// <summary>
    /// Interaction logic for WriterWindow.xaml
    /// </summary>
    public partial class WriterWindow : Window
    {
        private MAIN wn;
        private Writer writer;

        public WriterWindow()
        {
            InitializeComponent();
        }       

        public WriterWindow(MAIN w)
        {
            this.wn = w;

            if (w.listView1.SelectedItem != null && w.listView1.SelectedItem is Writer)
            {
                writer = (Writer)w.listView1.SelectedItem;
            }
            else
            {
                writer = (Writer)w.listView2.SelectedItem;
            }

            InitializeComponent();
        }


    }
}
