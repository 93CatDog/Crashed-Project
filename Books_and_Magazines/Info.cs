using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Books_and_Magazines
{
    [Serializable]
    class Info
    {
        private List<Writer> mWriters = new List<Writer>();
        private List<Publishing> mPublishings = new List<Publishing>();
        private List<Book> mBooks = new List<Book>();
        private List<Newspaper> mNewspapers = new List<Newspaper>();
        private List<Issue> mIssues = new List<Issue>();

        public List<Writer> Writers
        {
            get
            {
                return this.mWriters;
            }
        }
        public List<Publishing> Publishings
        {
            get
            {
                return this.mPublishings;
            }
        }
        public List<Book> Books
        {
            get
            {
                return this.mBooks;
            }
        }
        public List<Newspaper> Newspapers
        {
            get
            {
                return this.mNewspapers;
            }
        }
        public List<Issue> Issues
        {
            get
            {
                return this.mIssues;
            }
            set
            {
                this.mIssues = value;
            }
        }

        public void Add_Books(Book book)
        {
            this.mBooks.Add(book);
        }
        public void Add_Writers(Writer wrt)
        {
            this.mWriters.Add(wrt);
        }
        public void Add_Publishings(Publishing pbl)
        {
            this.mPublishings.Add(pbl);
        }
        public void Add_Newspapers(Newspaper nsp)
        {
            this.mNewspapers.Add(nsp);  
        }
        public void Add_Issues(Issue iss)
        {
            this.mIssues.Add(iss);
        }

        public void LoadToBinaryFile(string FileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, this);
            }
        }

        public Info LoadFromBinaryFile(string FileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();

            using (Stream fStream = File.OpenRead(FileName))
            {
                Info info = (Info)binFormat.Deserialize(fStream);
                return info;
            }
        }

    }
}
