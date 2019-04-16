using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP.WPF.DataAccess.Implementations
{
    class DialogService : IDialogServices
    {
        public string OpenFileDialog()
        {
            var dialog = new OpenFileDialog
            {
                DefaultExt = ".json",
                Filter = "JSON Files (*.json)|*.json|XML Files (*.xml)|*.xml"
            };
            bool? result = dialog.ShowDialog();
            return result == true ? dialog.FileName : null;

        }

        public string SaveFileDialog()
        {
            var dialog = new SaveFileDialog
            {
                DefaultExt = ".json",
                Filter = "JSON Files (*.json)|*.json|XML Files (*.xml)|*.xml"
            };
            bool? result = dialog.ShowDialog();
            return result == true ? dialog.FileName : null;
        }
    }
}
