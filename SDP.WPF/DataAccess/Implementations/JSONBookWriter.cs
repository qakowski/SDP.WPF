using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDP.WPF.Models;
using Newtonsoft.Json;
using System.IO;

namespace SDP.WPF.DataAccess.Implementations
{
    class JSONBookWriter : ISourceWriter
    {
        public void WriteBooks(string filePath, List<Book> books)
        {
           File.WriteAllText(filePath, JsonConvert.SerializeObject(books));
        }
    }
}
