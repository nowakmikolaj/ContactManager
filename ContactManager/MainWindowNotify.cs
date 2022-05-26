using System;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using System.IO;
using System.Windows.Controls;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace ContactManager
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool isLocked;

        public bool IsValidationUnLocked
        {
            set
            {
                OnPropertyRaised();
            }
            get
            {
                return !isLocked;
            }

        }

        public bool IsValidationLocked
        {
            set
            {
                isLocked = value;
                OnPropertyRaised("IsValidationLocked");
                OnPropertyRaised("IsValidationUnLocked");
            }
            get
            {
                return isLocked;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
