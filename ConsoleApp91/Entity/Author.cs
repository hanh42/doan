using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp91.Interface;
namespace ConsoleApp91.Entity
{
    class Author:IAuthor
    {

        private static List<Author> _listOfAuthor;
        private List<Book> _listBookOfAuthor;
        private static int _autoIncreatment = 0;
        private int id;
        private string namOfAuthor;
        private Book bookOfAuthor;


        public int Id { get => id; }
        public string NamOfAuthor { get => namOfAuthor; set => namOfAuthor = value; }
        public static List<Author> ListOfAuthor { get => _listOfAuthor; }
        public Book BookOfAuthor { get => bookOfAuthor; set => bookOfAuthor = value; }
        public List<Book> ListBookOfAuthor { get => _listBookOfAuthor; }

        public Author(string name = "")
        {

            if (name == "")
            {
                throw new Exception("loi khong ten");
            }

            if (_listOfAuthor == null)
            {
                _listOfAuthor = new List<Author>();
            }
            this.id = ++_autoIncreatment;
            this.NamOfAuthor = name;
            _listBookOfAuthor = new List<Book>();
            _listOfAuthor.Add(this);



        }


        public static Author findAuThor(int id)
        {
            if (_listOfAuthor != null)
            {
                for (int i = 0; i < _listOfAuthor.Count; i++)
                {
                    if(_listOfAuthor[i].id == id)
                    {
                        return _listOfAuthor[i];

                    }
                }
            }
            return null;
        }

        public override string ToString()
        {
            return $"id of author:{this.id}          name of author:{this.namOfAuthor}";
        }
    }
}
