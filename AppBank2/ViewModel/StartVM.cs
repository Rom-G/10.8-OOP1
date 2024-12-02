using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AppBank2.ViewModel
{
    internal class StartVM : MainVM, INotifyPropertyChanged
    {
        private object selectedLevel;

        public object SelectedLevel
        {
            get { return selectedLevel; }
            set
            {
                selectedLevel = value;
                OnPropertyChanged("SelectedLevel");
            }
        }

        private RelayCommand showConsultantFormCommand;
        public RelayCommand ShowConsultantFormCommand
        {
            get
            {
                return showConsultantFormCommand ??
                    (showConsultantFormCommand = new RelayCommand(obj =>
                    {
                        string SelectedItem = obj as string;
                        if (SelectedItem == "Консультант")
                        {
                            ChildVM = new ConsultantVM();
                        }
                    }));
            }
        }

    }
}
