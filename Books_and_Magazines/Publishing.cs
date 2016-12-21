using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_and_Magazines
{
    [Serializable]
    class Publishing
    {
        private string mName;
        private string mLocation;   
        private int mFoundation;
        private string mInfo;
        private List<Newspaper> mNewspapersList;
        private List<Book> mBooksList;

        public bool Compare(string text)
        {
            if (Name.Contains(text) || Location.Contains(text) || Foundation.ToString().Contains(text))
                return true;
            return false;
        }

        public string Name
        {
            get
            {
                return this.mName;
            }
            set
            {
                this.mName = value;
            }
        }
        public string Info
        {
            get
            {
                return this.mInfo;
            }
            set
            {
                this.mInfo = value;
            }
        }
        public string Location
        {
            get
            {
                return this.mLocation;
            }
            set
            {
                string prs = value;
                this.mLocation = value;
            }
        }
        public int Age
        {
            get
            {
               return DateTime.Now.Year - Foundation;
            }
                
        }
        public int Foundation
        {
            get
            {
                return this.mFoundation;
            }
            set
            {
                this.mFoundation = value;
            }
        }
        public string this[string data]
        {
            get
            {
                try
                {
                    int number = Int32.Parse(data);
                    if (data == String.Empty)
                        return "This field can't be empty!";
                    if (number > 0 && number < DateTime.Now.Year)
                        return null;
                    else
                        return "The foundation year can't be negative and higher than today's date";
                }
                catch (FormatException)
                {
                    return "Uncorrect format of year";
                }
                catch (OverflowException)
                {
                    return "The foundation year can't be negative and higher than today's date";
                }
            }
        }
        //public Book  this[int index]
        //{
        //    get
        //    {
        //        try
        //        {
        //            return this.mBooksList.ElementAt(index);
        //        }
        //        catch(IndexOutOfRangeException)
        //        {
        //            return null;
        //        }
        //    }
        //}
        //public Newspaper this[int index, int a]
        //{
        //    get
        //    {
        //        try
        //        {
        //            return this.mNewspapersList.ElementAt(index);
        //        }
        //        catch (IndexOutOfRangeException)
        //        {
        //            return null;
        //        }
        //    }
        //}
        public List<Book> BooksList
        {
            get
            {
                return this.mBooksList;
            }
        }
        public List<Newspaper> NewspapersList
        {
            get
            {
                return this.mNewspapersList;
            }
        }
        public Publishing()
        {
            this.Name = null; ;
            this.Foundation = 0;
            this.mInfo = null;
            this.mLocation = null;
            this.mNewspapersList = new List<Newspaper>();
            this.mBooksList = new List<Book>();
        }
        public Publishing(string Name, string Location, int Foundation, string Info )
        {
            this.Name = Name;
            this.Foundation = Foundation;
            this.mInfo = Info;
            this.mLocation = Location;
            this.mNewspapersList = new List<Newspaper>();
            this.mBooksList = new List<Book>();
        }
        public void Add_Book(Book bk)
        {
            this.mBooksList.Add(bk);
        }
        public void Add_Newspaper(Newspaper art)
        {
            this.mNewspapersList.Add(art);
        }
    }
}
