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
        private Info NewInfo;

        public BookWindow(MAIN w)
        {
            InitializeComponent();
            this.wn = w;

            if(w.listView1.SelectedItem != null && w.listView1.SelectedItem is Book )
            {
                this.book = (Book)w.listView1.SelectedItem;
            }
            else
            {
                this.book = (Book)w.listView3.SelectedItem;
            }
            this.image.Source = new BitmapImage(new Uri(this.book.ImageSource)); 

            

            if (this.book.FileSource != String.Empty || this.book.FileSource != null)
            {
                
            }
            else
            {
                this.OpenBtn.IsEnabled = false;
            }
            this.Source = this.Source.Remove(this.Source.LastIndexOf("Debug") - 5);
            this.Source = this.Source.Replace('\\', '/') + "/" + this.book.FileSource;

            //test();
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(this.Source);
            //MessageBox.Show(this.Source);
        }

        /*
        public void test()
        {
            Book b = new Book("Za", "rom", "da", 1900);
            NewInfo = new Info();
            NewInfo = NewInfo.LoadFromBinaryFile("TEXT.txt");
            this.NewInfo.Add_Books(b);
            NewInfo.LoadToBinaryFile("TEXT.txt");
            this.wn.listView1.Items.Clear();
            this.wn.listView3.Items.Clear();
            this.wn.View();
        }
        */
    }
}
