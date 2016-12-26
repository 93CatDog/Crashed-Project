using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_and_Magazines
{
    class NewspaperComparerName : IComparer<Newspaper>
    {
        public int Compare(Newspaper x, Newspaper y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

    [Serializable]
    class Newspaper
    {
        private string mName;
        private int mStart_year;
        private string mHyperLink;
        private string mImageSource = "pack://application:,,,/Books_and_Magazines;component/DefaultNewspaper.jpg";
        private List<Issue> mIssuesList;
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
        public string Type
        {
            get
            {
                return this.GetType().Name;
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

        public bool Compare(string text)
        {
            if (Name.Contains(text) || Start_year.ToString().Contains(text))
                return true;
            return false;
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

        public List<Issue> IssuesList
        {
            get
            {
                try
                {
                    return this.mIssuesList;
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
            set
            {
                this.mIssuesList = value;
            }
        }
        public void Add_Issue(Issue iss)
        {
            this.mIssuesList.Add(iss);
        }
 
        public override string ToString()
        {
            return (this.Name + " " + " " + this.Publishing.ToString() + " " + this.Start_year);
        }
    } 
}
