using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for AddContactWindow.xaml
    /// </summary>
    public partial class AddContactWindow : Window
    {
        private ObservableCollection<Contact> contacts;

        public AddContactWindow(ObservableCollection<Contact> contacts)
        {
            InitializeComponent();
            this.contacts = contacts;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            contacts.Add(new Contact(
                                    nameBox.Text,
                                    surnameBox.Text,
                                    emailBox.Text,
                                    phoneBox.Text,
                                    (Genders)genderBox.SelectedValue ));
            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
