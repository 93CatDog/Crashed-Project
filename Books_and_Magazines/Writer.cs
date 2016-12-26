using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_and_Magazines
{
    class WriterComparerName : IComparer<Writer>
    {
        public int Compare(Writer x, Writer y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

    class WriterComparerSurname : IComparer<Writer>
    {
        public int Compare(Writer x, Writer y)
        {
            return x.Surname.CompareTo(y.Surname);
        }
    }

    [Serializable]
    class Writer
    {
        private string mName;
        private string mSurname;
        private string mBiography;
        private int mBirthDate;
        private int mDeathDate;
        private string mImageSource = "pack://application:,,,/Books_and_Magazines;component/DefaultWriter.png";
        private List<Book> mBooksList = new List<Book>();
        public string Type
        {
            get
            {
                return this.GetType().Name;
            }
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
        public string Surname
        {
            get
            {
                return this.mSurname;
            }
            set
            {
                this.mSurname = value;
            }
        }
        public string FullName
        {
            get
            {
                return Name + Surname;
            }
        }
        public string Biography
        {
            get
            {
                return this.mBiography;
            }
            set
            {
                this.mBiography = value;
            }
        }
        public string Years
        {
            get
            {
                return BirthDate + "-" + DeathDate;
            }
        }
        public int BirthDate
        {
            get
            {
                return this.mBirthDate;
            }
            set
            {
                this.mBirthDate = value;
            }
        }
        public int DeathDate
        {
            get
            {
                return this.mDeathDate;
            }
            set
            {
                this.mDeathDate = value;
            }
        }
        public string AboutItem
        {
            get
            {
                return "Years :" + Years + "\n" + "Wrote : " + this.NamesFromBooksList;
            }
        }
        public string ImageSource
        {
            get
            {
                return this.mImageSource;
            }
            set
            {
                if (value.Contains('/'))
                {
                    this.mImageSource = value;
                }
                else
                {
                    this.mImageSource = "pack://application:,,,/Books_and_Magazines;component/" + value;
                }
            }
        }
        public List<Book> BooksList
        {
            get
            {
                return this.mBooksList;
            }
        }
        public string NamesFromBooksList
        {
            get
            {
                if(this.BooksList == null)
                {
                    return "";
                }
                string str = "";
                if (this.BooksList.Count < 5)
                {
                    foreach (var item in BooksList)
                    {
                        str += "“" + item.Name + "”, ";
                    }
                    //str = str.Remove(str.Length - 2);
                }
                else
                {
                    for (var C = 0; C < 4; C++)
                    {
                        str += BooksList.ElementAt(C).Name + ", ";
                    }
                    str = str.Remove(str.Length - 2);
                    str = str + "...";
                }
                return str;
            }
        }      

        
        public Writer(string name, string surname, int birthdate, int deathdate)
        {
            this.mName = name;
            this.mSurname = surname;
            this.mBiography = null;
            this.mBirthDate = birthdate;
            this.mDeathDate = deathdate;       
        }

        public Writer()
        {

        }
        

        public override string ToString()
        {
            return (this.Name + " " + this.Surname + " " + this.BirthDate + " " + this.DeathDate + "\n");
        }

        public bool Compare(string text)
        {
            if (Name.Contains(text) || Surname.Contains(text) || BirthDate.ToString().Contains(text) || DeathDate.ToString().Contains(text))
                return true;
            return false;
        }

        public void Add_Book(Book bk)
        {
            this.mBooksList.Add(bk);
        }

        /*
        public string Print_Books()
        {
            string result = null;
            foreach (var item in mBooksList)
            {
                result += item.Name + item.Date;
            }
            return result;
        }
        */
    }
}
