using SDP.WPF.Commands;
using SDP.WPF.DataAccess;
using SDP.WPF.DataAccess.Implementations;
using SDP.WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SDP.WPF.ViewModels
{
    class MainViewModel
    {
        public ObservableCollection<Book> Books { get; set; }
        //Book exampleBook = new Book(1, "Adam Mickiewicz", "Dziady", "1822", 35.20M);

        public Book NewBook
        {
            get;
            set;
        }
        public ICommand AddBook
        {
            get;
            set;
        }

        private void AddNewBook()
        {
            if (NewBook.IsValid)
            {
                Books.Add(new Book(NewBook));
            }
        }



        private readonly IDialogServices _dialogServices;
        
        private readonly ISourceOperationStrategy _sourceOperation;

        public ICommand OpenFile
        {
            get; private set;
        }

        public ICommand SaveFile
        {
            get; private set;
        }

        private void SaveDataToFile()
        {
            var fileName = _dialogServices.SaveFileDialog();
            if (fileName != null)
            {
                List<Book> bookList = Books.ToList();
                _sourceOperation.getWriter(fileName).WriteBooks(fileName, bookList);
                
            }
        }

        private void LoadDataFromFile()
        {
            var fileName = _dialogServices.OpenFileDialog();
            if (fileName != null)
            {
                List<Book> bookList = _sourceOperation.getReader(fileName).ReadBooks(fileName);
                Books.Clear();
                foreach(var book in bookList)
                {
                    Books.Add(book);
                }
            }
        }

        public MainViewModel(IDialogServices dialogServices, ISourceOperationStrategy sourceReader)
        {
            _dialogServices = dialogServices;
            _sourceOperation = sourceReader;
            Books = new ObservableCollection<Book>();
            NewBook = new Models.Book();
            AddBook = new RelayCommands(param => AddNewBook(), null);
            OpenFile = new RelayCommands(param => LoadDataFromFile(), null);
            SaveFile = new RelayCommands(param => SaveDataToFile(), null);
            //Books.Add(exampleBook);
        }
    }
}
