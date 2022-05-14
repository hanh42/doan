using ConsoleApp91.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp91
{
    class Book
    {

        private static List<Book> _listOfBook;
        private static int _autoIncreatment = 0;
        private readonly string _nameOfAuthor;
        private readonly string _nameOfPublisher;

        private int _id;
        private string _nameOfBook;
        private double _price;
        private int _releaseYear;
        private int _numberOfPage;
        private DateTime _inputDay;
        private int _status;

        private readonly Author authorOfBook;
        private readonly Publisher publisherOfBook;



        public int Id { get => _id; }
        public string NameOfBook { get => _nameOfBook; set => _nameOfBook = value; }
        public double Price { get => _price; set => _price = value; }
        public int ReleaseYear { get => _releaseYear; }
        public int NumberOfPage { get => _numberOfPage; set => _numberOfPage = value; }
        public DateTime InputDay { get => _inputDay; set => _inputDay = value; }
        public int Status { get => _status; set => _status = value; }


        public static List<Book> ListOfBook { get => _listOfBook; }


        public string NameOfAuthor => _nameOfAuthor;

        public string NameOfPublisher => _nameOfPublisher;

        internal Author AuthorOfBook => authorOfBook;

        internal Publisher PublisherOfBook => publisherOfBook;

        public Book(string nameOfBook ="", double price = 0, int releaseYear = 0, int numOfPage = 0, DateTime inputday = new DateTime(), int status = 0, int idOfPublisherToFind =0, int idOfAuthorToFind = 0)
        {
            if (nameOfBook == "")
            {
                throw new Exception("loi khong ten");
            }
            var authorOfBook = Author.findAuThor(idOfAuthorToFind);
            if (authorOfBook == null)
            {
                throw new Exception("khong ton tai tac gia co id la:" + idOfAuthorToFind);

            }

            var publisherOfBook = Publisher.findPublisher(idOfPublisherToFind);
            if (publisherOfBook == null)
            {
                throw new Exception("khong tim thay nha san xuat co id:" + idOfPublisherToFind);
            }


            if (_listOfBook == null)
            {
                _listOfBook = new List<Book>();
            }
            this._id = ++_autoIncreatment;
            this._nameOfBook = nameOfBook;
            this._nameOfAuthor = authorOfBook.NamOfAuthor;
            this._nameOfPublisher = publisherOfBook.NameOfPublisher;
            this._price = price;
            this._releaseYear = releaseYear;
            this._numberOfPage = numOfPage;
            this._inputDay = inputday;
            this._status = status;
            this.authorOfBook = authorOfBook;

            this.publisherOfBook = publisherOfBook;


            authorOfBook.ListBookOfAuthor.Add(this);
            publisherOfBook.ListBookOfPublisher.Add(this);
            _listOfBook.Add(this);


        }

       public static Book findBook(int id)
        {
            if (_listOfBook != null)
            {
                for (int i = 0; i < _listOfBook.Count; i++)
                {
                    if(_listOfBook[i].Id == id)
                    {
                        return _listOfBook[i];
                    }
                }

            }
            return null;
        }
             
        public static string[] ToFile()
        {
            List<string> strs = new List<string>();
            strs.Add($"{_autoIncreatment}");
            foreach (var item in _listOfBook)
            {
                strs.Add(
                    $"{item.Id}-{item.NameOfBook}-{item.AuthorOfBook.Id}-{item.Price}-{item.publisherOfBook.Id}-{item.ReleaseYear}-{item.NumberOfPage}-{item.InputDay}-{item.Status}"
                    );
            }

            return strs.ToArray();
        }


        public override string ToString()
        {
            return $"id of book:{this.Id}\nname of book:{this.NameOfBook}\nprice of book:{this.Price}" +
                $"\nname of book :{this.NameOfBook}\nname of publisher:{this.NameOfPublisher}\nyearOfBorn:{this.ReleaseYear}" +
                $"\nnumber of page:{this.NumberOfPage}\ninput day :{this._inputDay}\nstatus:{this.Status}\n";
        }
    }
}
