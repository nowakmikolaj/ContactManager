using System;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Collections.ObjectModel;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();
            contacts = new ObservableCollection<Contact>();
            contacts.Add(new Contact("Rachel", "Green", "rachel@example.com", "765434", Genders.Female));
            contacts.Add(new Contact("Chandler", "Bing", "chandler@example.com", "123", Genders.Male));
            contacts.Add(new Contact());
            DataContext = contacts;
        }

        private void Menu_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Menu_About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is simple contact manager");
        }
    }
}