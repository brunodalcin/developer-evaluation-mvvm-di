using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace developer_evaluation_btg.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        string title;
        public string Title
        {
            get => title;
            set {    
                if (title == value)
                    return;
                title = value;
                OnPropertyChanged();
            }
        }            
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
