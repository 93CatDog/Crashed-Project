using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_and_Magazines
{
    //delegate void ForBook(int one);

    class BookComparerName : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
    class BookComparerDate : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Date.CompareTo(y.Date);
        }
    }
    class BookCompaperWriters : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.WritersList.Count - y.WritersList.Count;
        }
    }

    [Serializable]
    class Book
    {
        private string mName;
        private string mAnnotation;
        private string mDirection; //
        private int mDate;
        private List<Writer> mWritersList;
        private Publishing mPublishing;
        private string mImageSource = "pack://application:,,,/Books_and_Magazines;component/DefaultBook.png";
        private string mFileSource;                                     


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
        public string Annotation
        {
            get
            {
                return this.mAnnotation;
            }
            set
            {
                this.mAnnotation = value;
            }
        }
        public string Direction
        {
            get
            {
                return this.mDirection;
            }
            set
            {
                this.mDirection = value;
            }
        }
        public int Date
        {
            get
            {
                return this.mDate;
            }
            set
            {
                this.mDate = value;
            }
        }
        public string Type
        {
            get
            {
                return "Book";
            }
        }
        public string About
        {
            get
            {
                return ("Written by: " + this.NamesFromWritersList
                    + "\n" + "in " + this.Date);
            }
        }
        public Publishing Publishing
        {
            get
            {
                try
                {
                    return this.mPublishing;
                }
                catch (NullReferenceException)
                {
                    return null;
                }

            }
            set
            {
                this.mPublishing = value;
            }
        }
       
        public string ImageSource
        {
            get
            {
                return mImageSource;
            }
            set
            {
                this.mImageSource = "pack://application:,,,/Books_and_Magazines;component/" + value;
            }
        }
        public string FileSource
        {
            get
            {
                return this.mFileSource;
            }
            set
            {
                this.mFileSource = value;
            }
        }


        public bool Compare(string text)
        {
            if (Name.Contains(text) || Direction.Contains(text) || Date.ToString().Contains(text))
                return true;
            return false;
        }

        public List<Writer> WritersList
        {
            get
            {
                return this.mWritersList;
            }
        }
        public Writer GetWriterFromList(int index)
        {
            try
            {
                return this.mWritersList.ElementAt<Writer>(index);
            }
            catch (IndexOutOfRangeException) { return null; }
        }
        public string NamesFromWritersList
        {
            get
            {
                string str = null;
                if (this.WritersList.Count < 4)
                {
                    foreach (var item in WritersList)
                    {
                        str += item.Name + ", ";
                    }
                    str = str.Remove(str.Length - 2);
                }
                else
                {
                    for (var C = 0; C < 3; C++)
                    {
                        str += GetWriterFromList(C).Name + ", ";
                    }
                    str = str.Remove(str.Length - 2);
                    str = str + "...";
                }
                return str;
            }
        }

        public Book(string Name, string Direction, string Annotation, int Date)
        {
            this.Name = Name;
            this.Direction = Direction;
            this.Annotation = Annotation;
            this.Date = Date;
            this.mWritersList = new List<Writer>();
        }
        public Book()
        {
            this.Name = null;
            this.Direction = null;
            this.Date = 0;
            this.Publishing = null;
            this.mWritersList = new List<Writer>();
        }
        public override string ToString()
        {
            return (this.Name);//+ " " + this.Annotation + " " + this.Direction + " " + this.Date + " " + this.Publishing.Name + "\n");
        }

        public void Add_Writer(Writer wrt)
        {           
            this.mWritersList.Add(wrt);
            wrt.Add_Book(this);
        }

        public void Add_Publishing(Publishing pbl)
        {
            this.Publishing = pbl;
            pbl.Add_Book(this);
        }

        public string Print_Writers()
        {
            string result = null;
            foreach (var item in mWritersList)
            {
                result += item.ToString();
            }
            return result;
        }

    }
}
