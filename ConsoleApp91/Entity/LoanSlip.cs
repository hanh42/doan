using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp91.Entity
{
    class LoanSlip
    {
        private static List<LoanSlip> _listOfLoanSlip;
        private static int _autoIncreatment = 0;
        private Readers readerOfLoanShip;
        private int id;
        private int idOfReader;
        private int idOfBook;
        private DateTime bookLoanDay;
        private DateTime bookReturnDate;
        private int status;
        private int numberOfLoanSlip;

     

        public int Id { get => id; }
        public int IdOfReader { get => idOfReader; set => idOfReader = value; }
        public int IdOfBook { get => idOfBook; set => idOfBook = value; }
        public DateTime BookLoanDay { get => bookLoanDay; }
        public DateTime BookReturnDate { get => bookReturnDate; }
        public int Status { get => status; set => status = value; }
        public int NumberOfLoanSlip { get => numberOfLoanSlip; }
        public Readers ReaderOfLoanShip { get => readerOfLoanShip; }
        public static List<LoanSlip> ListOfLoanSlip { get => _listOfLoanSlip; set => _listOfLoanSlip = value; }

        public LoanSlip(int authorId =0 ,int bookId =0,int status =0,int idOfReader=0,int? loanSlipId = null)
        {
            var readerOfLoanShip = Readers.findReaderByid(idOfReader);
            if (readerOfLoanShip == null)
            {
                throw new Exception("khong ton tai khach hang co id:" + IdOfReader);
            }

            var author = Author.findAuThor(authorId);
            if (author == null)
            {
                throw new Exception("khong ton tai tac gia co id:"+authorId);
            }

            var book = Book.findBook(bookId);

            if (book == null)
            {
                throw new Exception("khong ton tai sach co id:"+bookId);
            }


            if (ListOfLoanSlip == null)
            {
                ListOfLoanSlip = new List<LoanSlip>();
            }
            //so thu tu
            this.id = loanSlipId.HasValue?loanSlipId.Value:++_autoIncreatment;
            this.idOfReader = author.Id;
            this.idOfBook = book.Id;
            //ngay muonlay ngay hien tai!
            this.bookLoanDay = DateTime.Now;
            this.bookReturnDate = this.bookLoanDay.AddDays(7);
            this.status = status;
            this.numberOfLoanSlip = readerOfLoanShip.ListLoanSlipOfReader.Count;
            this.readerOfLoanShip = readerOfLoanShip;
            readerOfLoanShip.ListLoanSlipOfReader.Add(this);
            ListOfLoanSlip.Add(this);

        }



        public static string[] ToFile()
        {
            List<string> strs = new List<string>();
            strs.Add($"{_autoIncreatment}");
            foreach (var item in _listOfLoanSlip)
            {
                strs.Add($"{item.id}-{item.readerOfLoanShip.Id}-{item.idOfBook}-{item.bookLoanDay}-{item.bookReturnDate}-{item.status}-{item.numberOfLoanSlip}");
            }

            return strs.ToArray();
        }

        public override string ToString()
        {
            return $"id of loanSlip:{this.id}";
        }
    }
}