using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP.WPF.Models
{
    public class Book : BindableBase, IDataErrorInfo
    {
        private int _inventoryNumber;
        private string _author;
        private string _title;
        private string _yearPublisher;
        private decimal _price;

        public int InventoryNumber
        {
            get { return _inventoryNumber; }
            set
            {
                _inventoryNumber = value;
                OnPropertyChanged();

            }
        }
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                OnPropertyChanged();
            }

        }
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
        public string YearPublisher
        {
            get { return _yearPublisher; }
            set
            {
                _yearPublisher = value;
                OnPropertyChanged();
            }
        }
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }


        private readonly BooksValidator _bookValidator;

        public bool IsValid
        {
            get {return _bookValidator.Validate(this).IsValid; }
        }
        public string Error
        {
          get
            {
                if (_bookValidator != null)
                {
                    var result = _bookValidator.Validate(this);
                    if (result != null && result.Errors.Any())
                    {
                        var error = string.Join(Environment.NewLine, result.Errors.Select(p=>p.ErrorMessage).ToArray());
                        return error;
                    }
                }
                return string.Empty;
            }
        }

        public string this[string columnName]
        {
            get
            {
                var firstOrDefault = _bookValidator.Validate(this).Errors.FirstOrDefault(p => p.PropertyName == columnName);

                if (firstOrDefault != null)
                {
                    return _bookValidator != null ? firstOrDefault.ErrorMessage : string.Empty;
                }
                return string.Empty;
            }
        }

        //public Book(int InventoryNumber, string Author, string Title, string YearPublisher, decimal Price)
        //{
        //    this.InventoryNumber = InventoryNumber;
        //    this.Author = Author;
        //    this.Title = Title;
        //    this.YearPublisher = YearPublisher;
        //    this.Price = Price;
        //}

        public Book(Book book) : this()
        {
            InventoryNumber = book.InventoryNumber;
            Author = book.Author;
            Title = book.Title;
            YearPublisher = book.YearPublisher;
            Price = book.Price;
        }

        public Book()
        {
            _bookValidator = new BooksValidator();
        }
    }

}