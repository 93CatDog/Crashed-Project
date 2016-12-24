using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_and_Magazines
{
    [Serializable]
    class Issue
    {
        private Newspaper mNewspaper;
        private int mNumber;
        private string mFileSource;

        public Newspaper Newspaper
        {
            get
            {
                try
                {
                    return this.mNewspaper;
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
            set
            {
                this.mNewspaper = value;
            }
        }
          
        public void Add_Newspaper(Newspaper np)
        {
            this.Newspaper = np;
            np.Add_Issue(this);
        }

        public string Type
        {
            get
            {
                return "Issue";
            }
        }
        public int Number
        {
            get
            {
                return this.mNumber;
            }
            set
            {
                this.mNumber = value;
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

    }
}
