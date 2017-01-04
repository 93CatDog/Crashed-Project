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
        private Info mlocalbookmarks = new Info();
        private string fileName2 = "Bookmarks.txt";

        public WriterWindow(MAIN w)
        {
            InitializeComponent();
            this.wn = w;

            if (w.listView1.SelectedItem != null && w.listView1.SelectedItem is Writer)
            {
                this.writer = (Writer)w.listView1.SelectedItem;
            }
            if (w.listView5.SelectedItem != null && w.listView5.SelectedItem is Writer)
            {
                this.writer = (Writer)w.listView5.SelectedItem;
            }
            if (w.listView2.SelectedItem != null && w.listView2.SelectedItem is Writer)
            {
                this.writer = (Writer)w.listView2.SelectedItem;
            }
            if (this.image.Source != null)
                this.image.Source = new BitmapImage(new Uri(this.writer.ImageSource));
            else
                this.image.Source = new BitmapImage(new Uri("pack://application:,,,/Books_and_Magazines;component/DefaultWriter.png"));
            this.FullNameContent.Text = " " + writer.FullName;
            this.BirthDateContent.Text = " "+ this.writer.BirthDate.ToString() + "-";
            this.DeathDateContent.Text =  this.writer.DeathDate.ToString();
            this.BiographyContent.Text =  this.writer.Biography;
            this.BooksListContent.Text = this.writer.AllBooks;
        }
        private void AddToBookmarksBtn_Click(object sender, RoutedEventArgs e)
        {
            //if(wn.Bookmarks.IsSelected==false)
            //{
                //Writer tmp;
                //tmp = this.mlocalbookmarks.Writers.Find(item => item.Name.Equals(writer.Name));
                //if (tmp == null)
                //{
                //    mlocalbookmarks.Add_Writers(writer);
                //    mlocalbookmarks.LoadToBinaryFile(fileName2);
                //    this.wn.ViewBookmarks();
                //}
            //}           
        }

    }
}
