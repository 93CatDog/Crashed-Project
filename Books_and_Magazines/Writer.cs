using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_and_Magazines
{
    [Serializable]
    class Writer
    {
        private string mName;
        private string mSurname;
        private string mBiography;
        private int mBirthDate;
        private int mDeathDate;
        private string mImageSource = "pack://application:,,,/Books_and_Magazines;component/DefaultWriter.png";
        private List<Book> mBooksList;

        public string Name
        {
            get
            {
                return this.mName + " " + this.Surname;
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
        public string Biography
        {
            get
            {
                return this.mBiography;
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
        public string Type
        {
            get
            {
                return "Writer";
            }
        }
        public string About
        {
            get
            {
                return ("Wrote : " + this.NamesFromBooksList);
            }
        }
        public string AboutItem
        {
            get
            {
                return Years + "\n" + About;
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
                this.mImageSource = "pack://application:,,,/Books_and_Magazines;component/" + value;
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
                string str = null;
                if (this.BooksList.Count < 5)
                {
                    foreach (var item in BooksList)
                    {
                        str += "“" + item.Name + "”, ";
                    }
                    str = str.Remove(str.Length - 2);
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
            this.mBooksList = new List<Book>();
           
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

        public string Print_Books()
        {
            string result = null;
            foreach (var item in mBooksList)
            {
                result += item.Name + item.Date;
            }
            return result;
        }
   
    }
}
