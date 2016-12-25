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
        private string mHyperLink;
        private string mInfo;
        private List<Newspaper> mNewspapersList = new List<Newspaper>();
        private List<Book> mBooksList = new List<Book>();

        public bool Compare(string text)
        {
            if (Name.Contains(text) || Location.Contains(text) || Foundation.ToString().Contains(text))
                return true;
            return false;
        }

        public string HyperLink
        {
            get
            {
                return this.mHyperLink;
            }
            set
            {
                this.mHyperLink = value;
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

        }

        public override string ToString()
        {
            return this.Name;
        }

        /*
        public Publishing(string Name, string Location, int Foundation, string Info )
        {
            this.Name = Name;
            this.Foundation = Foundation;
            this.mInfo = Info;
            this.mLocation = Location;
            this.mNewspapersList = new List<Newspaper>();
            this.mBooksList = new List<Book>();
        }
        */

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
