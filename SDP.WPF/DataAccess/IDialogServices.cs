using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP.WPF.DataAccess
{
    public interface IDialogServices
    {
        string OpenFileDialog();
        string SaveFileDialog();
    }
}
