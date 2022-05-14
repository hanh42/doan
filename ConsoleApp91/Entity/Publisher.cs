using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp91.Interface;

namespace ConsoleApp91.Entity
{
    class Publisher:IPublisher
    {
        private static int _autoIncreatment = 0;
        private int id;
        private string nameOfPublisher;

        public string NameOfPublisher { get => nameOfPublisher; }
        public int Id { get => id; }

        public Publisher(string name="")
        {
            this.id = ++_autoIncreatment;
            this.nameOfPublisher = name;
        }
    }
}
