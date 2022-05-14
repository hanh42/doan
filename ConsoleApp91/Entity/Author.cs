using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp91.Interface;
namespace ConsoleApp91.Entity
{
    class Author:IAuthor
    {
        private static int _autoIncreatment = 0;
        private int id;
        private string namOfAuthor;


        public int Id { get => id; }
        public string NamOfAuthor { get => namOfAuthor; set => namOfAuthor = value; }

        public Author(string name = "")
        {
            this.id = ++_autoIncreatment;
            this.NamOfAuthor = name;


        }
    }
}
