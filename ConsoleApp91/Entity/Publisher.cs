using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp91.Interface;

namespace ConsoleApp91.Entity
{
    class Publisher : IPublisher
    {
        private static List<Publisher> _listOfPublisher;
        private List<Book> _listBookOfPublisher;
        private static int _autoIncreatment = 0;
        private int id;
        private string nameOfPublisher;

        public string NameOfPublisher { get => nameOfPublisher; }
        public int Id { get => id; }
        public static List<Publisher> ListOfPublisher { get => _listOfPublisher; }
        public List<Book> ListBookOfPublisher { get => _listBookOfPublisher; }

        public Publisher(string name = "", int id = 0)
        {
            if (name == "")
            {
                throw new Exception("loi khong ten");
            }

            

            if (_listOfPublisher == null)
            {
                _listOfPublisher = new List<Publisher>();
            }
            this.id = ++_autoIncreatment;
            this.nameOfPublisher = name;
            _listBookOfPublisher = new List<Book>();
            _listOfPublisher.Add(this);
        }


        public static Publisher findPublisher(int id)
        {
           

            if (_listOfPublisher != null)
            {
                for (int i = 0; i < _listOfPublisher.Count; i++)
                {
                    if (_listOfPublisher[i].id == id)
                    {
                        return _listOfPublisher[i];
                    }
                }


            }

            return null;
        }


        public static string[] ToFile()
        {
            //1 nha xb co 5 san pham thi chay 5 lan luu!
            List<string> strs = new List<string>();
            strs.Add($"{_autoIncreatment}");
            foreach (var item in _listOfPublisher)
            {
                int x =-1;
                foreach (var item2 in item.ListBookOfPublisher)
                {
                    x = item2.Id;
                }
                strs.Add($"{item.id}-{item.nameOfPublisher}-{x}");
             }

            return strs.ToArray();
            
        }







        public override string ToString()
        {
            return $"id of publiser:{this.id}            name of publishera:{this.nameOfPublisher}";
        }
    }
}
