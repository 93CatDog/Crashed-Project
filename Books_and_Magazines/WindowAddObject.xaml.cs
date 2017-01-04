using Microsoft.Win32;
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
using System.Collections;

namespace Books_and_Magazines
{
    /// <summary>
    /// Interaction logic for WindowAddObject.xaml
    /// </summary>
    public partial class WindowAddObject : Window
    {
        MAIN wn;
        Info tmp_info = new Info();
        string filename = "TEXT.txt";
        private char[] separator = new char[] { '1', '2', '3', '4', '5', '5', '6', '7', '8', '9', '0', ',', '.', '!', '?' };
        Writer Writer_1 = new Writer();
        Book Book_1 = new Book();
        Newspaper Newspaper_1 = new Newspaper();
        Publishing pbl_1 = new Publishing();
        List<Book> FinalBooksList = new List<Book>();
        List<Writer> FinalWritersList = new List<Writer>();
        string text = "";

        public WindowAddObject(MAIN w, string type)
        {
            InitializeComponent();
            this.wn = w;
            switch (type)
            {
                case "Writer":
                    Item1.IsSelected = true;
                    break;
                case "Book":
                    Item2.IsSelected = true;
                    break;
                case "Newspaper":
                    Item3.IsSelected = true;
                    break;
            }
            tmp_info = tmp_info.LoadFromBinaryFile(filename);           
        }

        private void AddWrtPhoto_Click(object sender, RoutedEventArgs e)
        {
            string filename;
            OpenFileDialog image = new OpenFileDialog();
            image.InitialDirectory = "C:\\";
            image.Filter = "Картинки(*.jpg;*.jpeg;*.png;*.gif) |*.jpg;*.jpeg;*.png;*gif";
            if (image.ShowDialog() == true)
            {
                WrtPhoto.Source = new BitmapImage(new Uri(image.FileName));
                filename = image.FileName;
            }
            Writer_1.ImageSource = WrtPhoto.Source.ToString();
        }

        private void Books_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Books.Text == String.Empty)
            {
                Books_List.Items.Clear();
                Books_List.Visibility = Visibility.Hidden;
            }
            else
            {
                Books_List.Visibility = Visibility.Visible;
                Books_List.Items.Clear();
                List<string> text = Books.Text.Split(new char[] { ' ', ',', '.', ';', '!', '?', }).ToList();
                string TextForSearch = text.ElementAt(0);
                List<Book> newlist = tmp_info.Books.FindAll(item => item.Name.Contains(TextForSearch));
                //MessageBox.Show(newlist.Count.ToString());
                foreach (var item in newlist)
                    Books_List.Items.Add(item);
            }
        }

        private void Save_Wrt_btn_Click(object sender, RoutedEventArgs e)
        {
            
            string[] tmp1 = WrtName.Text.Split(separator);
            string[] tmp2 = WrtSurname.Text.Split(separator);
            try
            {
                if (tmp_info.Writers.Find(item => item.Name.Equals(tmp1[0])) != null && tmp_info.Writers.Find(item => item.Name.Equals(tmp2[0])) != null)
                    throw new SimilarObjectException();
                else
                {
                    int year = 0;
                    int year1 = 0;
                    MessageBox.Show(WrtName.Text.Length.ToString());
                    MessageBox.Show(tmp1.GetLength(0).ToString());
                    try
                    {
                        if (tmp1.GetLength(0) != 1 || tmp2.GetLength(0) != 1 || WrtName.Text.Length == 0 || WrtSurname.Text.Length == 0)
                            throw new IncorrectStringException();
                    }
                    catch (IncorrectStringException)
                    {
                        MessageBox.Show("Fields 'Name' and 'Surname' can't be empty and must only consist of letters");
                    }
                    try
                    {
                        year = Convert.ToInt32(WrtBirthDate.Text);
                        //year1 = Convert.ToInt32(WrtDeathDate.Text);               
                        if (year > DateTime.Now.Year || year < 0)//|| year>year1)
                            throw new DateException();
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Incorrect date format");
                    }
                    catch (DateException)
                    {
                        MessageBox.Show("Incorrect Birthdate");
                    }
                    if (tmp1.GetLength(0) == 1 && tmp2.GetLength(0) == 1 && year != 0 && WrtName.Text.Length != 0 && WrtSurname.Text.Length != 0)
                    {
                        Writer_1.Name = WrtName.Text;
                        Writer_1.Surname = WrtSurname.Text;
                        Writer_1.BirthDate = Convert.ToInt32(WrtBirthDate.Text);
                        //Writer_1.DeathDate = Convert.ToInt32(WrtDeathDate.Text);
                        Writer_1.Biography = Biography.Text;
                        //MessageBox.Show(WrtPhoto.Source.ToString());
                        Writer_1.ImageSource = WrtPhoto.Source.ToString();
                        foreach (Book item in FinalBooksList)
                        {
                            this.Writer_1.Add_Book(item);
                        }
                        tmp_info.Add_Writers(Writer_1);
                        tmp_info.LoadToBinaryFile(filename);
                        this.Close();
                        this.wn.View();
                        this.wn.Show();
                    }
                }
            }
            catch(SimilarObjectException)
            {
                MessageBox.Show("Database has already contains object with this Name!");
            }         
        }

        private void Books_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FinalBooksList.Count == 0)
            {
                Choose_books_Copy.Visibility = Visibility.Visible;
                Books_List_Copy.Visibility = Visibility.Visible;
            }
            foreach (var item in Books_List.SelectedItems)
            {
                if (!Books_List_Copy.Items.Contains(item))
                {
                    Books_List_Copy.Items.Add(item);
                    FinalBooksList.Add(item as Book);
                }
            }  
        }

        private void Books_List_Copy_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                List<Book> tmp = new List<Book>();
                foreach (Book item in Books_List_Copy.SelectedItems)
                    tmp.Add(item);
                foreach (Book item in tmp)
                    FinalBooksList.Remove(item);
                Books_List_Copy.Items.Clear();
                foreach (Book item in FinalBooksList)
                    Books_List_Copy.Items.Add(item);
                if (FinalBooksList.Count == 0)
                {
                    Choose_books_Copy.Visibility = Visibility.Hidden;
                    Books_List_Copy.Visibility = Visibility.Hidden;
                }
                Books_List.UnselectAll();
            }

        }

        

        

        private void Save_Book_btn_Copy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tmp_info.Books.Find(item => item.Name.Equals(BookName.Text)) != null)
                    throw new SimilarObjectException();
                else
                {
                    string tmp1 = BookName.Text;
                    string[] tmp2 = Genre.Text.Split(separator);
                    int year = 0;
                    //MessageBox.Show(WrtName.Text.Length.ToString());
                    //MessageBox.Show(tmp1.GetLength(0).ToString());
                    try
                    {
                        if (tmp2.GetLength(0) != 1 || BookName.Text.Length == 0 || Genre.Text.Length == 0 || FinalWritersList.Count == 0)
                            throw new IncorrectStringException();
                    }
                    catch (IncorrectStringException)
                    {
                        MessageBox.Show("Fields 'Name' , 'Genre' , 'Writers' can't be empty and must only consist of letters");
                    }
                    try
                    {
                        year = Convert.ToInt32(Date.Text);
                        //year1 = Convert.ToInt32(WrtDeathDate.Text);               
                        if (year > DateTime.Now.Year || year < 0)//|| year>year1)
                            throw new DateException();
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Incorrect date format");
                    }
                    catch (DateException)
                    {
                        MessageBox.Show("Incorrect Birthdate");
                    }
                    if (tmp2.GetLength(0) == 1 && Genre.Text.Length > 0 && BookName.Text.Length != 0 && FinalWritersList.Count > 0)
                    {
                        Book_1.Name = BookName.Text;
                        Book_1.Genre = Genre.Text;
                        Book_1.Date = year;
                        Book_1.Annotation = Annotation.Text;
                        foreach (Writer item in FinalWritersList)
                        {
                            Book_1.Add_Writer(item);
                        }
                        Book_1.Publishing = pbl_1;
                        tmp_info.Add_Books(Book_1);
                        tmp_info.LoadToBinaryFile(filename);
                        this.Close();
                        this.wn.View();
                        this.wn.Show();
                    }
                }
            }
            catch(SimilarObjectException)
            {
                MessageBox.Show("Database has already contains object with this Name!");
            }
            
           
            
        }

        private void Publishing_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Publishing.Text == String.Empty)
                Publishing_List.Visibility = Visibility.Hidden;
            else
            {
                Publishing_List.Visibility = Visibility.Visible;
                Publishing_List.Items.Clear();
                List<string> text = Publishing.Text.Split(new char[] { ' ', ',', '.', ';', '!', '?', }).ToList();
                string TextForSearch = text.ElementAt(0);
                List<Publishing> newlist = tmp_info.Publishings.FindAll(item => item.Compare(Publishing.Text));
                foreach (var item in newlist)
                    Publishing_List.Items.Add(item);
            }
        }

        private void Writers_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Writers.Text == String.Empty)
            {
                Writers_List.Items.Clear();
                Writers_List.Visibility = Visibility.Hidden;
            }
            else
            {
                Writers_List.Visibility = Visibility.Visible;
                Writers_List.Items.Clear();
                List<string> text = Writers.Text.Split(new char[] { ' ', ',', '.', ';', '!', '?', }).ToList();
                string TextForSearch = text.ElementAt(0);
                List<Writer> newlist = tmp_info.Writers.FindAll(item => item.Compare(TextForSearch));
                foreach (var item in newlist)
                    Writers_List.Items.Add(item);
            }
        }

        private void Writers_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FinalWritersList.Count == 0)
            {
                Choose_writers.Visibility = Visibility.Visible;
                Writers_List_Copy.Visibility = Visibility.Visible;
            }
            foreach (var item in Writers_List.SelectedItems)
            {
                if (!Writers_List_Copy.Items.Contains(item))
                {
                    Writers_List_Copy.Items.Add(item);
                    FinalWritersList.Add(item as Writer);
                }
            }
        }

        private void Writers_List_Copy_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                List<Writer> tmp = new List<Writer>();
                foreach (Writer item in Writers_List_Copy.SelectedItems)
                    tmp.Add(item);
                foreach (Writer item in tmp)
                    FinalWritersList.Remove(item);
                Writers_List_Copy.Items.Clear();
                foreach (Writer item in FinalWritersList)
                    Writers_List_Copy.Items.Add(item);
                if (FinalWritersList.Count == 0)
                {
                   Choose_writers.Visibility = Visibility.Hidden;
                   Writers_List_Copy.Visibility = Visibility.Hidden;
                }
                Writers_List.UnselectAll();
            }
            

        }

        private void Publishing_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Publishing_List.SelectedItem != null)
            {
                pbl_1 = Publishing_List.SelectedItem as Publishing;
                Publishing.Text = pbl_1.Name;
                Publishing_List.Visibility = Visibility.Hidden;
            }  
        }

        private void AddBookPhoto_btn_Click(object sender, RoutedEventArgs e)
        {
            string filename;
            OpenFileDialog image = new OpenFileDialog();
            image.InitialDirectory = "C:\\";
            image.Filter = "Картинки(*.jpg;*.jpeg;*.png;*.gif) |*.jpg;*.jpeg;*.png;*gif";
            if (image.ShowDialog() == true)
            {
                BookPhoto.Source = new BitmapImage(new Uri(image.FileName));
                filename = image.FileName;
            }
            Book_1.ImageSource = BookPhoto.Source.ToString();
        }

        private void AddBookFile_btn_Click(object sender, RoutedEventArgs e)
        {
            string filename;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "C:\\";
            dialog.Filter = "PDF(*.pdf) |*.pdf;";
            if (dialog.ShowDialog() == true)
            {
                filename = dialog.FileName;
                Book_1.FileSource = filename;
            }
        }

        private void AddBookAudio_btn_Click(object sender, RoutedEventArgs e)
        {
            string filename;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "C:\\";
            dialog.Filter = "MP#(*.mp3) |*.mp3;";
            if (dialog.ShowDialog() == true)
            {
                filename = dialog.FileName;
                Book_1.AudioSource = filename;
            }
        }

        private void Books_List_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Books.IsFocused == false)
            {
                Books.Text = "";
                Books_List.UnselectAll();
                Books_List.Visibility = Visibility.Hidden;
            }
        }

        private void Writers_List_LostFocus(object sender, RoutedEventArgs e)
        {

            if (Writers.IsFocused == false)
            {
                Writers.Text = "";
                Writers_List.UnselectAll();
                Writers_List.Visibility = Visibility.Hidden;
            }
        }
    }
}


