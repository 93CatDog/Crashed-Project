using System;
using System.Collections.Generic;
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

            for (int C = 0; C < minfo.Writers.Count; C++)
            {
                listView2.Items.Add(minfo.Writers.ElementAt(C));
            }
            for (int C = 0; C < minfo.Books.Count; C++)
            {
                listView3.Items.Add(minfo.Books.ElementAt(C));
            }
            for (int C = 0; C < minfo.Newspapers.Count; C++)
            {
                listView4.Items.Add(minfo.Newspapers.ElementAt(C));
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
                        NewspaperWindow wn1 = new NewspaperWindow(this);
                        wn1.Show();
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
            wn.Show();
        }

        private void Add2_Click(object sender, RoutedEventArgs e)
        {
            this.wn = new WindowAddObject(this, "Book");
            wn.Show();
        }

        private void Add3_Click(object sender, RoutedEventArgs e)
        {
            this.wn = new WindowAddObject(this, "Newspaper");
            wn.Show();
        }

        private void AddToBookmarks_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show(listView1.SelectedItem.GetType().Name.ToString());
            object obj = listView1.SelectedItem;
            MessageBox.Show(obj.Equals(minfo.Writers.Find(item => item.Name.Contains((obj as Writer).Name))).ToString());
            switch (listView1.SelectedItem.GetType().Name)
            {
                case "Writer":
                    mbookmarks.Add_Writers((Writer)obj);
                    mbookmarks.LoadToBinaryFile(fileName2);
                    ViewBookmarks();
                    break;
                case "Book":
                    mbookmarks.Add_Books((Book)obj);
                    mbookmarks.LoadToBinaryFile(fileName2);
                    ViewBookmarks();
                    break;
                case "Newspaper":
                    mbookmarks.Add_Newspapers((Newspaper)obj);
                    mbookmarks.LoadToBinaryFile(fileName2);
                    ViewBookmarks();
                    break;
            }

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(listView1.SelectedItem.GetType().Name.ToString());
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(listView1.SelectedItem.GetType().Name.ToString());

        }


        private void RemoveFromBookmarks_Click(object sender, RoutedEventArgs e)
        {
            object wrt = listView1.SelectedItem;          
            //MessageBox.Show(wrt.Equals(wrt2).ToString());
            //MessageBox.Show(wrt.Name + " " + wrt.About);
            //MessageBox.Show(wrt2.Name + " " + wrt2.About);
            //if (wrt == wrt2)
            // Console.WriteLine("Yes");
            //wrt = mbookmarks.Writers.Find(item => item.Name.Contains(wrt.Name));
            //MessageBox.Show(mbookmarks.Writers.Find(item=>item.Name.Contains(wrt.Name)).Name);
            switch (listView1.SelectedItem.GetType().Name)
            {
                case "Writer":
                    Writer wrt2 = mbookmarks.Writers.Find(item => item.Name.Contains((wrt as Writer).Name));
                    Writer wrt3 = mbookmarks.Writers.Find(item => item.Surname.Contains((wrt as Writer).Surname));
                    if(wrt2.Equals(wrt3))
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

     

        private void ContexMMenu_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            object obj = listView1.SelectedItem;
            switch (listView1.SelectedItem.GetType().Name)
            {
                case "Writer":
                    foreach (var item in mbookmarks.Writers)
                    {
                        if (obj as Writer == item)
                        {
                            this.AddToBookmarks.IsEnabled = false;
                            this.RemoveFromBookmarks.IsEnabled = true;
                            break;
                        }
                    }
                    break;
                case "Book":
                    foreach (var item in mbookmarks.Books)
                    {
                        if (obj as Book == item)
                        {
                            this.AddToBookmarks.IsEnabled = false;
                            this.RemoveFromBookmarks.IsEnabled = true;
                            break;
                        }
                    }
                    break;
                case "Newspaper":
                    foreach (var item in mbookmarks.Newspapers)
                    {
                        if (obj as Newspaper == item)
                        {
                            this.AddToBookmarks.IsEnabled = false;
                            this.RemoveFromBookmarks.IsEnabled = true;
                            break;
                        }
                    }
                    break;
            }
        }

        private void ContexMMenu_Opened(object sender, RoutedEventArgs e)
        {
            object obj = listView1.SelectedItem;
            switch (listView1.SelectedItem.GetType().Name)
            {
                case "Writer":
                    foreach (var item in mbookmarks.Writers)
                    {
                        if (obj as Writer == item)
                        {
                            this.AddToBookmarks.IsEnabled = false;
                            this.RemoveFromBookmarks.IsEnabled = true;
                            break;
                        }
                    }
                    break;
                case "Book":
                    foreach (var item in mbookmarks.Books)
                    {
                        if (obj as Book == item)
                        {
                            this.AddToBookmarks.IsEnabled = false;
                            this.RemoveFromBookmarks.IsEnabled = true;
                            break;
                        }
                    }
                    break;
                case "Newspaper":
                    foreach (var item in mbookmarks.Newspapers)
                    {
                        if (obj as Newspaper == item)
                        {
                            this.AddToBookmarks.IsEnabled = false;
                            this.RemoveFromBookmarks.IsEnabled = true;
                            break;
                        }
                    }
                    break;
            }
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
    }
}
