using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_and_Magazines
{
    [Serializable]
    class Newspaper
    {
        private string mName;
        private int mStart_year;
        private string mHyperLink;
        private string mImageSource = "pack://application:,,,/Books_and_Magazines;component/DefaultNewspaper.jpg";
        private bool mAccess;

        private Publishing mPublishing;
        

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
        public string Type
        {
            get
            {
                return "Newspaper";
            }
        }
        public int Start_year
        {
            get
            {
                return this.mStart_year;
            }
            set
            {
                this.mStart_year = value;                       
            }
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
        public string About
        {
            get
            {
                return "since " + Start_year + "\n" + HyperLink; 
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
        public bool Access
        {
            get
            {
                return this.mAccess;
            }
            set
            {
                this.mAccess = value;
            }
        }

        public bool Compare(string text)
        {
            if (Name.Contains(text) || Start_year.ToString().Contains(text))
                return true;
            return false;
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
                    if (number > 700 && number < DateTime.Now.Year)
                        return null;
                    else
                        return "The start year can't be lower than XIII century and higher than today's date";
                }
                catch (FormatException)
                {
                    return "Uncorrect format of year";
                }
                catch (OverflowException)
                {
                    return "The start year can't be lower than XIII century and higher than today's date";
                }
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
                catch(NullReferenceException)
                {
                    return null;
                }
            }
            set
            {
                this.mPublishing = value;       
            }
        }
        public void Add_Publishing(Publishing pb)
        {
            this.Publishing = pb;
            pb.Add_Newspaper(this);
        }
        public Newspaper(string Name, int Start_year)
        {
            this.mName = Name;
            this.Publishing = null;
            this.Start_year = Start_year;
        }
        public Newspaper()
        {
            this.mName = null;
            this.mPublishing = null;
            this.mStart_year = 0;
        }
        public override string ToString()
        {
            return (this.Name + " " + " " + this.Publishing.ToString() + " " + this.Start_year);
        }
    } 
}
