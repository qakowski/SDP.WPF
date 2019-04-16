using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP.WPF.DataAccess.Implementations
{
    class SourceOperationStrategy : ISourceOperationStrategy
    {
        private static Dictionary<string, ISourceReader> _readers;
        private static Dictionary<string, ISourceWriter> _writers;
        static SourceOperationStrategy()
        {
            _readers = new Dictionary<string, ISourceReader>();
            _readers.Add(".json", new JSONBookReader());
            _readers.Add(".xml", new XMLBookReader());

            _writers = new Dictionary<string, ISourceWriter>();
            _writers.Add(".json", new JSONBookWriter());
            _writers.Add(".xml", new XMLBookWriter());
        }
        public ISourceReader getReader(string filePath)
        {
            var extension = Path.GetExtension(filePath);
            ISourceReader reader;
            if(_readers.TryGetValue(extension, out reader))
            {
                return reader;
            }
            return null;
        }

        public ISourceWriter getWriter(string filePath)
        {
            var extension = Path.GetExtension(filePath);
            ISourceWriter writer;
            if(_writers.TryGetValue(extension, out writer))
            {
                return writer;
            }
            return null;
        }


       
    }
}
