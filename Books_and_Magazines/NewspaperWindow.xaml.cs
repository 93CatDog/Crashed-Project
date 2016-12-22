using System;
using System.Diagnostics;
using System.ComponentModel;
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
    /// Interaction logic for NewspaperWindow.xaml
    /// </summary>
    public partial class NewspaperWindow : Window
    {
        private MAIN wn;
        private Newspaper newspaper;

        public NewspaperWindow(MAIN w)
        {
            InitializeComponent();
            this.wn = w;
            
            if (w.listView1.SelectedItem != null && w.listView1.SelectedItem is Newspaper)
            {
                newspaper = (Newspaper)w.listView1.SelectedItem;
            }
            else
            {
                newspaper = (Newspaper)w.listView4.SelectedItem;
            }

            
            if (newspaper.HyperLink != String.Empty || newspaper.HyperLink != null)
            {
                this.HyperlinkBlock.Text = newspaper.HyperLink;
            }
            else
            {
                this.OpenSource.IsEnabled = false;
            }
        }

        private void OpenSource_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(newspaper.HyperLink);
        }
    }
}
