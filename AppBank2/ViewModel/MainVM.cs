using AppBank2.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppBank2.ViewModel
{
    internal class MainVM : INotifyPropertyChanged
    {
        private object childVM;

        public object ChildVM
        {
            get { return childVM; }
            set
            {
                if (Equals(childVM, value))
                {
                    return;
                }
                    
                childVM = value;
                OnPropertyChanged("ChildVM");
            }
        }

        public MainVM()
        {
            ChildVM = new StartVM();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
