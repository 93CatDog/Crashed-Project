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
        private Info mlocalbookmarks = new Info();
        private string fileName2 = "Bookmarks.txt";

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
            if(this.image.Source != null)
                this.image.Source = new BitmapImage(new Uri(this.book.ImageSource)); 
            else
                this.image.Source = new BitmapImage(new Uri("pack://application:,,,/Books_and_Magazines;component/DefaultBook.png"));
            
            this.BookName.Text = " " + book.FullName;
            this.Date.Text = " " + this.book.Date.ToString();
            this.Genre.Text = " " + this.book.Genre;
            this.Writers.Text = " " + this.book.AllBooks;
            this.Publishing.Text = " " + this.book.Publishing.Name;
            this.Annotation.Text = " " + this.book.Annotation;


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

        private void AddToBookmarksBtn_Click(object sender, RoutedEventArgs e)
        {
            //Book tmp;
            //tmp = this.mlocalbookmarks.Books.Find(item => item.Name.Equals(book.Name));
            //if (tmp == null)
            //{
            //    mlocalbookmarks.Add_Books(book);
            //    mlocalbookmarks.LoadToBinaryFile(fileName2);
            //    this.wn.ViewBookmarks();
            //}
        }
    }
}
