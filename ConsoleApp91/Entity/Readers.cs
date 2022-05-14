using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp91.Entity
{
    class Readers
    {
        private static int _autoIncreatment = 0;
        private int id;
        private string _name;
        private DateTime registrationDate;

        public int Id { get => id; }
        public string Name { get => _name; set => _name = value; }
        public DateTime RegistrationDate { get => registrationDate;}


        public Readers(string name="")
        {


            this.id
            this._name = name;

        }
    }
}
