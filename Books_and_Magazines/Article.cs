using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_and_Magazines
{
    [Serializable]
    class Article
    {
        private string mHeader;       
        //private string mContent;      
        private DateTime mWritingDate;
        private List<Writer> mWritersList;        
        private List<Newspaper> mNewspapersList;

        public string Header
        {
            get
            {
                return this.mHeader;
            }
            set
            {
                this.mHeader = value;
            }
        }
        public DateTime WritingDate
        {
            get
            {
                return this.mWritingDate;
            }
            set
            {
                this.mWritingDate = value;
            }
        }
        public List<Writer> WritersList
        {
            get
            {
                return this.mWritersList;
            }
        }
        public List<Newspaper> NewspapersList
        {
            get
            {
                return this.mNewspapersList;
            }
        }
        public Article()
        {
            this.Header = null;
            //this.Content = null;
            this.mWritersList = new List<Writer>();
            this.mNewspapersList = new List<Newspaper>();
            this.WritingDate = new DateTime();
        }
        public void Add_Writer(Writer wrt)
        {
            this.mWritersList.Add(wrt);
            wrt.Add_Article(this);
        }
        public void Add_Newspaper(Newspaper nwsp)
        {
            this.mNewspapersList.Add(nwsp);
            nwsp.Add_Article(this);
        }
    }
}
