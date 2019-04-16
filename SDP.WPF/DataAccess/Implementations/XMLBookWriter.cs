using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDP.WPF.Models;
using System.Xml.Serialization;
using System.IO;

namespace SDP.WPF.DataAccess.Implementations
{
    class XMLBookWriter : ISourceWriter
    {
       static XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Book>), new XmlRootAttribute("BookList"));
        public void WriteBooks(string filePath, List<Book> books)
        {
            using (var fileStream = File.OpenWrite(filePath))
            {
                xmlSerializer.Serialize(fileStream, books);
            }

        }
    }
}
