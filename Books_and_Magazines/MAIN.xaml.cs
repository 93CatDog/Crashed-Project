using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
    /// Interaction logic for MAIN.xaml
    /// </summary>
    public partial class MAIN : Window
    {
        private Info minfo = new Info();
        private Info mbookmarks = new Info();
        private string fileName = "TEXT.txt";
        private string fileName2 = "Bookmarks.txt";
        private WindowAddObject wn;

        public MAIN()
        {
            InitializeComponent();

            //Change_File();

            View();

            ViewBookmarks();
        }

        public void Search_View()
        {
            minfo = minfo.LoadFromBinaryFile(fileName);
            foreach (var item in minfo.Writers)
            {
                listView1.Items.Add(item);
            }
            foreach (var item in minfo.Newspapers)
            {
                listView1.Items.Add(item);
            }
            foreach (var item in minfo.Books)
            {
                listView1.Items.Add(item);
            }
        }

        public void View()
        {
            minfo = minfo.LoadFromBinaryFile(fileName);
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();
            listView4.Items.Clear();
            foreach (var item in minfo.Writers)
            {
                listView1.Items.Add(item);
            }
            foreach (var item in minfo.Newspapers)
            {
                listView1.Items.Add(item);
            }
            foreach (var item in minfo.Books)
            {
                listView1.Items.Add(item);
            }

            foreach (var item in minfo.Writers)
            {
                listView2.Items.Add(item);
            }
            foreach (var item in minfo.Books)
            {
                listView3.Items.Add(item);
            }
            foreach (var item in minfo.Newspapers)
            {
                listView4.Items.Add(item);
            }
        }

        public void ViewBookmarks()
        {
            listView5.Items.Clear();
            mbookmarks = mbookmarks.LoadFromBinaryFile(fileName2);
            foreach (var item in mbookmarks.Writers)
            {
                listView5.Items.Add(item);
            }
            foreach (var item in mbookmarks.Newspapers)
            {
                listView5.Items.Add(item);
            }
            foreach (var item in mbookmarks.Books)
            {
                listView5.Items.Add(item);
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string str = "";
            if (this.Search.IsSelected == true)
            { 
                str = (listView1.SelectedItem.GetType().Name);
            }            
            if (this.Writers.IsSelected == true)
            {
                str = (listView2.SelectedItem.GetType().Name);
            }                
            if (this.Books.IsSelected == true)
            {
                str = (listView3.SelectedItem.GetType().Name);
            }       
            if (this.Newspapers.IsSelected == true)
            {
                str = (listView4.SelectedItem.GetType().Name);
            }  
            if(this.Bookmarks.IsSelected == true)
            {
                str = (listView5.SelectedItem.GetType().Name);
            }
                switch (str)
                {
                    case "Book":
                        BookWindow wn = new BookWindow(this);
                        wn.Show();
                        this.WindowState = WindowState.Minimized;
                        break;
                    case "Newspaper":
                    //NewspaperWindow wn1 = new NewspaperWindow(this);
                    //wn1.Show();
                    Newspaper newspaper = new Newspaper();
                    if (this.Newspapers.IsSelected == true)
                    {
                        newspaper = listView4.SelectedItem as Newspaper;
                    }
                    if (this.Search.IsSelected == true)
                    {
                        newspaper = listView1.SelectedItem as Newspaper;
                    }

                    if (this.Bookmarks.IsSelected == true)
                    {
                        newspaper = listView5.SelectedItem as Newspaper;
                    }

                    if (newspaper.HyperLink != String.Empty || newspaper.HyperLink != null)
                    {
                        Process.Start(newspaper.HyperLink);
                    }                  

                    this.WindowState = WindowState.Minimized;
                        break;
                    case "Writer":
                        WriterWindow wn2 = new WriterWindow(this);
                        wn2.Show();
                        this.WindowState = WindowState.Minimized;
                        break;
                    default:
                        MessageBox.Show("Please, restart programme");
                        break;
                }
        }

        private void Change_File()
        {
            Book War = new Book();
            Book Peace = new Book();
            Book Master = new Book();
            Newspaper Vesti = new Newspaper();
            Newspaper Segodnya = new Newspaper();
            Newspaper Vecherniy_Kiev = new Newspaper();
            Publishing Info_Press = new Publishing();

            Writer Ivan_Ivanov = new Writer("IVAN", "TRASH", 1895, 1960);
            Writer Bulgakov = new Writer("Mihail", "Bulgakov", 1891, 1940);


            Writer Petr_Petrov = new Writer("Petr", "Petrov", 1978, 2058);

            Info_Press.Name = "Инфо_пресс";
            Info_Press.Location = "Киев";
            Info_Press.Info = "Издательство-лидер в сфере информации";
            Info_Press.Foundation = 2001;

            War.Annotation = "Книга для врослых";
            War.Date = 1939;
            War.Genre = "Тематика Войны";
            War.Name = "Начало 1-й Мировой войны";
            War.Add_Publishing(Info_Press);
            War.Add_Writer(Ivan_Ivanov);
            War.Add_Writer(Petr_Petrov);
            

            Peace.Annotation = "Книга для всех";
            Peace.Date = 1967;
            Peace.Genre = "Про мир";
            Peace.Name = "Мир для всех!";
            Peace.Add_Publishing(Info_Press);
            Peace.Add_Writer(Ivan_Ivanov);

            Master.Annotation = "От и до..";
            Master.Date = 1966;
            Master.Genre = "Фантастика";
            Master.Name = "Мастер и Маргарита";
            Master.FileSource = "Bulgakov-Master and Margarita.pdf";
            Master.Add_Publishing(Info_Press);
            Master.Add_Writer(Bulgakov);


            Segodnya.Name = "Газета Сегодня";
            Segodnya.Add_Publishing(Info_Press);
            Segodnya.Start_year = 1998;

            Vesti.Name = "Газета Вести";
            Vesti.Add_Publishing(Info_Press);
            Vesti.Start_year = 2003;

            Vecherniy_Kiev.Name = "Вечірній Київ";
            Vecherniy_Kiev.HyperLink = "www.vechirniykiev.com.ua";
            Vecherniy_Kiev.ImageSource = "Kiev_Vecherniy.jpg";
            Vecherniy_Kiev.Add_Publishing(Info_Press);
            Vecherniy_Kiev.Start_year = 1906;

            minfo = new Info();
            minfo.Add_Publishings(Info_Press);
            minfo.Add_Writers(Ivan_Ivanov);
            minfo.Add_Writers(Petr_Petrov);
            minfo.Add_Books(War);
            minfo.Add_Books(Peace);
            minfo.Add_Newspapers(Segodnya);
            minfo.Add_Newspapers(Vesti);
            minfo.Add_Newspapers(Vecherniy_Kiev);

            minfo.Add_Books(Master);
            minfo.Add_Writers(Bulgakov);

            minfo.LoadToBinaryFile(fileName);
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchBox.Text == String.Empty)
            {
                listView1.Items.Clear();
                Search_View();
            }
            else
            {
                listView1.Items.Clear();
                List<string> text = SearchBox.Text.Split(new char[] { ' ', ',', '.', ';', '!', '?', }).ToList();
                string TextForSearch = text.ElementAt(0);
                List<Writer> newlist = minfo.Writers.FindAll(item => item.Compare(TextForSearch));
                List<Book> newlist2 = minfo.Books.FindAll(item => item.Compare(TextForSearch));
                List<Newspaper> newlist4 = minfo.Newspapers.FindAll(item => item.Compare(TextForSearch));
                foreach (var item in newlist)
                    listView1.Items.Add(item);
                foreach (var item in newlist2)
                    listView1.Items.Add(item);
                foreach (var item in newlist4)
                    listView1.Items.Add(item);
            }
        }

        private void Add1_Click(object sender, RoutedEventArgs e)
        {
            this.wn = new WindowAddObject(this, "Writer");
            View();
            wn.Show();
        }

        private void Add2_Click(object sender, RoutedEventArgs e)
        {
            this.wn = new WindowAddObject(this, "Book");
            View();
            wn.Show();          
        }

        private void Add3_Click(object sender, RoutedEventArgs e)
        {
            this.wn = new WindowAddObject(this, "Newspaper");
            View();
            wn.Show();
        }

        private void AddToBookmarks_Click(object sender, RoutedEventArgs e)
        {
            ListView SelectedListView = null;
            if (Search.IsSelected == true)
            {
                SelectedListView = listView1;
            }
            if (Writers.IsSelected == true)
            {
                SelectedListView = listView2;
            }
            if (Books.IsSelected == true)
            {
                SelectedListView = listView3;
            }
            if (Newspapers.IsSelected == true)
            {
                SelectedListView = listView4;
            }

            if (SelectedListView.SelectedItem != null)
            {
                object wrt = SelectedListView.SelectedItem;
                switch (SelectedListView.SelectedItem.GetType().Name)
                {
                    case "Writer":
                        Writer wrt2 = mbookmarks.Writers.Find(item => item.Name.Contains((wrt as Writer).Name));
                        Writer wrt3 = mbookmarks.Writers.Find(item => item.Surname.Contains((wrt as Writer).Surname));
                        if (wrt2 == wrt3)
                        {
                            mbookmarks.Writers.Add(wrt as Writer);
                            mbookmarks.LoadToBinaryFile(fileName2);
                            ViewBookmarks();
                        }
                        break;
                    case "Book":
                        Book bk = mbookmarks.Books.Find(item => item.Name.Contains((wrt as Book).Name));
                        if (bk == null)
                        {
                            mbookmarks.Books.Add(wrt as Book);
                            mbookmarks.LoadToBinaryFile(fileName2);
                            ViewBookmarks();
                        }
                        break;
                    case "Newspaper":
                        Newspaper nwsp = mbookmarks.Newspapers.Find(item => item.Name.Contains((wrt as Newspaper).Name));
                        if (nwsp == null)
                        {
                            mbookmarks.Newspapers.Add(wrt as Newspaper);
                            mbookmarks.LoadToBinaryFile(fileName2);
                            ViewBookmarks();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            
            //ListView SelectedListView = null;

            //if (Search.IsSelected == true)
            //{
            //    SelectedListView = listView1;
            //}

            //if (Writers.IsSelected == true)
            //{
            //    SelectedListView = listView2;
            //}
            //if (Books.IsSelected == true)
            //{
            //    SelectedListView = listView3;
            //}
            //if (Newspapers.IsSelected == true)
            //{
            //    SelectedListView = listView4;
            //}
            //if (Bookmarks.IsSelected == true)
            //    SelectedListView = listView5;

            //if (SelectedListView.SelectedItem != null)
            //{
            //    object wrt = SelectedListView.SelectedItem;
            //    switch (SelectedListView.SelectedItem.GetType().Name)
            //    {
            //        case "Writer":
            //            Writer wrt2 = minfo.Writers.Find(item => item.Name.Contains((wrt as Writer).Name));
            //            Writer wrt3 = minfo.Writers.Find(item => item.Surname.Contains((wrt as Writer).Surname));
            //            if (wrt2 == wrt3)
            //            {

            //                /*foreach (var item1 in wrt2.BooksList)
            //                {
            //                    Writer wrt4 = item1.WritersList.Find(item => item.Name.Contains((wrt2 as Writer).Name));
            //                    Writer wrt5 = item1.WritersList.Find(item => item.Surname.Contains((wrt2 as Writer).Surname));
            //                    if (wrt4 == wrt5)
            //                    {
            //                        item1.WritersList.Remove(wrt4);
            //                    }
            //                    else
            //                    {
            //                        if (wrt4 != null)
            //                        {
            //                            item1.WritersList.Remove(wrt4);
            //                        }
            //                        else
            //                        {
            //                            if (wrt5 != null)
            //                            {
            //                                item1.WritersList.Remove(wrt4);
            //                            }
            //                        }
            //                    }

            //                }*/
            //                minfo.Writers.Remove(wrt2);
            //            }
            //            minfo.LoadToBinaryFile(fileName);
            //            View();
            //            break;
            //        case "Book":
            //            Book bk = minfo.Books.Find(item => item.Name.Contains((wrt as Book).Name));
            //            minfo.Books.Remove(bk);
            //            minfo.LoadToBinaryFile(fileName);
            //            View();
            //            break;
            //        case "Newspaper":
            //            Newspaper nwsp = minfo.Newspapers.Find(item => item.Name.Contains((wrt as Newspaper).Name));
            //            mbookmarks.Newspapers.Remove(nwsp);
            //            mbookmarks.LoadToBinaryFile(fileName);
            //            View();
            //            break;
            //    }
            //}
            //RemoveFromBookmarks_Click(sender, e);
        }


        private void RemoveFromBookmarks_Click(object sender, RoutedEventArgs e)
        {
            ListView SelectedListView = null;

            if (Search.IsSelected == true)
            {
                SelectedListView = listView1;
            }

            if (Writers.IsSelected == true)
            {
                SelectedListView = listView2;
            }
            if (Books.IsSelected == true)
            {
                SelectedListView = listView3;
            }
            if (Newspapers.IsSelected == true)
            {
                SelectedListView = listView4;
            }
            if (Bookmarks.IsSelected == true)
                SelectedListView = listView5;

            if (SelectedListView.SelectedItem != null)
            {
                object wrt = SelectedListView.SelectedItem;
                switch (SelectedListView.SelectedItem.GetType().Name)
                {
                    case "Writer":
                        Writer wrt2 = mbookmarks.Writers.Find(item => item.Name.Contains((wrt as Writer).Name));
                        Writer wrt3 = mbookmarks.Writers.Find(item => item.Surname.Contains((wrt as Writer).Surname));
                        if (wrt2 == wrt3)
                            mbookmarks.Writers.Remove(wrt2);
                        mbookmarks.LoadToBinaryFile(fileName2);
                        ViewBookmarks();
                        break;
                    case "Book":
                        Book bk = mbookmarks.Books.Find(item => item.Name.Contains((wrt as Book).Name));
                        mbookmarks.Books.Remove(bk);
                        mbookmarks.LoadToBinaryFile(fileName2);
                        ViewBookmarks();
                        break;
                    case "Newspaper":
                        Newspaper nwsp = mbookmarks.Newspapers.Find(item => item.Name.Contains((wrt as Newspaper).Name));
                        mbookmarks.Newspapers.Remove(nwsp);
                        mbookmarks.LoadToBinaryFile(fileName2);
                        ViewBookmarks();
                        break;
                }
            }
            //MessageBox.Show(SelectedListView.SelectedItem.ToString());
        }



        

        private void BookNameSortRadio_Click(object sender, RoutedEventArgs e)
        {
            listView3.Items.Clear();
            List<Book> books = minfo.Books;
            books.Sort(new BookComparerName());
            foreach(var item in books)
            {
                listView3.Items.Add(item);
            }
        }

        private void BookDateSortRadio_Click(object sender, RoutedEventArgs e)
        {
            listView3.Items.Clear();
            List<Book> books = minfo.Books;
            books.Sort(new BookComparerDate());
            foreach (var item in books)
            {
                listView3.Items.Add(item);
            }
        }

        private void WriterNameSortRadio_Click(object sender, RoutedEventArgs e)
        {
            listView2.Items.Clear();
            List<Writer> writers = minfo.Writers;
            writers.Sort(new WriterComparerName());
            foreach (var item in writers)
            {
                listView2.Items.Add(item);
            }
        }

        private void WriterSurnameSortRadio_Click(object sender, RoutedEventArgs e)
        {
            listView2.Items.Clear();
            List<Writer> writers = minfo.Writers;
            writers.Sort(new WriterComparerSurname());
            foreach (var item in writers)
            {
                listView2.Items.Add(item);
            }
        }

        private void NewspaperNameSortRadio_Click(object sender, RoutedEventArgs e)
        {
            listView4.Items.Clear();
            List<Newspaper> newspapers = minfo.Newspapers;
            newspapers.Sort(new NewspaperComparerName());
            foreach(var item in newspapers)
            {
                listView4.Items.Add(item);
            }
        }

        private void SearchBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchBox2.Text == String.Empty)
            {
                listView2.Items.Clear();
                foreach (Writer item in minfo.Writers)
                    listView2.Items.Add(item);
            }
            else
            {
                listView2.Items.Clear();
                List<string> text = SearchBox2.Text.Split(new char[] { ' ', ',', '.', ';', '!', '?', }).ToList();
                string TextForSearch = text.ElementAt(0);
                List<Writer> newlist = minfo.Writers.FindAll(item => item.Compare(TextForSearch));
                foreach (var item in newlist)
                    listView2.Items.Add(item);
            }
        }

        private void SearchBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchBox3.Text == String.Empty)
            {
                listView3.Items.Clear();
                foreach (Book item in minfo.Books)
                    listView3.Items.Add(item);
            }
            else
            {
                listView3.Items.Clear();
                List<string> text = SearchBox3.Text.Split(new char[] { ' ', ',', '.', ';', '!', '?', }).ToList();
                string TextForSearch = text.ElementAt(0);
                List<Book> newlist = minfo.Books.FindAll(item => item.Compare(TextForSearch));
                foreach (var item in newlist)
                    listView3.Items.Add(item);
            }
        }

        private void SearchBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchBox4.Text == String.Empty)
            {
                listView4.Items.Clear();
                foreach (Newspaper item in minfo.Newspapers)
                    listView4.Items.Add(item);
            }
            else
            {
                listView4.Items.Clear();
                List<string> text = SearchBox4.Text.Split(new char[] { ' ', ',', '.', ';', '!', '?', }).ToList();
                string TextForSearch = text.ElementAt(0);
                List<Newspaper> newlist = minfo.Newspapers.FindAll(item => item.Compare(TextForSearch));
                foreach (var item in newlist)
                    listView4.Items.Add(item);
            }
        }
        private void ContexMMenu1_Opened(object sender, RoutedEventArgs e)
        {
            AddToBookmarks1.IsEnabled = false;
        }
    }
}
