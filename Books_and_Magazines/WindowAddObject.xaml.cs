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
        string filename = "TEXT.txt";
        private char[] separator = new char[] { '1', '2', '3', '4', '5', '5', '6', '7', '8', '9', '0', ',', '.', '!', '?' };
        Writer Writer_1 = new Writer();
        Info tmp_info = new Info();
        MAIN wn;
        List<TextBlock> TextBlockList = new List<TextBlock>();

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
            TextBlockList.Add(Book_1);
            TextBlockList.Add(Book_2);
            TextBlockList.Add(Book_3);
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
                //MessageBox.Show(TextForSearch);
                //MessageBox.Show(tmp_info.Books.Count.ToString());
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
                year= Convert.ToInt32(WrtBirthDate.Text);
                //year1 = Convert.ToInt32(WrtDeathDate.Text);               
                if (year > DateTime.Now.Year || year < 0 )//|| year>year1)
                    throw new DateException();                
            }
            catch(FormatException)
            {
                MessageBox.Show("Incorrect date format");
            }
            catch(DateException)
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
                foreach (Book item in Books_List.SelectedItems)
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

        /*private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BookWindow new_bk = new BookWindow(main);
            new_bk.Show();
        }*/

        private void Books_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach(var item in TextBlockList)
            {
                item.Text = String.Empty;
            }
            List<Book> BooksList = new List<Book>();
            foreach (Book item in Books_List.SelectedItems)
            {
                BooksList.Add(item);
            }        
            //MessageBox.Show(items.Count.ToString());
            int i = TextBlockList.Count;
            int j = BooksList.Count;
            for(int k=0;k<i&&k< j;k++)
            {
                TextBlockList.ElementAt(k).Text = (k+1)+") "+BooksList.ElementAt(k).Name;
            }            
        }
    }
}


