using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp91.Entity
{
    class Readers
    {
        private static List<Readers> _listOfReader;
        private List<LoanSlip> _listLoanSlipOfReader;
        private static int _autoIncreatment = 0;
        private int id;
        private string _name;
        private DateTime _registrationDate;

        public int Id { get => id; }
        public string Name { get => _name; set => _name = value; }
        public DateTime RegistrationDate { get => _registrationDate; }
        internal static List<Readers> ListOfReader { get => _listOfReader; }
        internal List<LoanSlip> ListLoanSlipOfReader { get => _listLoanSlipOfReader; }

        public Readers(string name = "", DateTime? registrationDate = null)
        {
            if (_listOfReader == null)
            {
                _listOfReader = new List<Readers>();
            }

            if (name == "")
            {
                throw new Exception("loi khong ten");
            }

            this._registrationDate = !registrationDate.HasValue ? DateTime.Now : registrationDate.Value;
            this.id = ++_autoIncreatment;
            this._name = name;
            this._listLoanSlipOfReader = new List<LoanSlip>();
            _listOfReader.Add(this);


        }


        public static Readers findReaderByid(int id)
        {
            if (_listOfReader != null)
            {

                for (int i = 0; i < _listOfReader.Count; i++)
                {
                    if (id == _listOfReader[i].id)
                    {
                        return _listOfReader[i];
                    }
                }



            }

            return null;


        }


        public override string ToString()
        {
            return $"id of reader:{this.id}     name of reader:{this.Name}";
        }
    }
}
