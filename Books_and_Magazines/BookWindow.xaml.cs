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
using System.Reflection;

namespace Books_and_Magazines
{
    /// <summary>
    /// Interaction logic for BookWindow.xaml
    /// </summary>
    public partial class BookWindow : Window
    {
        private MAIN wn;
        private Book book;
        private string Source = Assembly.GetExecutingAssembly().Location.ToString();

        public BookWindow(MAIN w)
        {
            this.wn = w;
            this.book = (Book)w.listView1.SelectedItem;

            InitializeComponent();
            if (this.book.FileSource != String.Empty && this.book.FileSource != null)
            {
                this.FileSourceBlock.Text = this.book.FileSource;
            }
            else
            {
                this.OpenBtn.IsEnabled = false;
            }
            this.Source = this.Source.Remove(this.Source.LastIndexOf("Debug") - 5);
            this.Source = this.Source.Replace('\\', '/') + "/" + this.book.FileSource;
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(this.Source);
            //MessageBox.Show(this.Source);
        }
    }
}
