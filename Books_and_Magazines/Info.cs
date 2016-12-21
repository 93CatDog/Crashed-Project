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

        public Writer GetWriterFromList(int index)
        {
            try
            {
                return this.mWriters.ElementAt<Writer>(index);
            }
            catch (IndexOutOfRangeException) { return null; }
        }
        public Publishing GetPublishingFromList(int index)
        {
            try
            {
                return this.mPublishings.ElementAt<Publishing>(index);
            }
            catch (IndexOutOfRangeException) { return null; }
        }
        public Book GetBookFromList(int index)
        {
            try
            {
                return this.mBooks.ElementAt<Book>(index);
            }
            catch (IndexOutOfRangeException) { return null; }
        }
        public Newspaper GetNewspaperFromList(int index)
        {
            try
            {
                return this.mNewspapers.ElementAt<Newspaper>(index);
            }
            catch (IndexOutOfRangeException) { return null; }
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

        public override string ToString()
        {
            string all_information = null;
            string info_writers = null, info_publishings = null;
            foreach (var item in mWriters)
            {
                info_writers += item.ToString();
            }
            foreach (var item in mPublishings)
            {
                info_publishings += item.ToString();
            }
            all_information = info_writers + info_publishings;
            return all_information;
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
