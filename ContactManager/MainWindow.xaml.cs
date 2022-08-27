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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string ErrorCaption = "An error occured!";

        private ObservableCollection<Contact> contacts;

        public MainWindow()
        {
            InitializeComponent();
            IsValidationLocked = true;
            contacts = new ObservableCollection<Contact>();
            DataContext = contacts;
        }

        private void Menu_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Menu_About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is simple contact manager", "Contact Manager", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Menu_Add_Click(object sender, RoutedEventArgs e)
        {
            new AddContactWindow(contacts).ShowDialog();
            ContactList.Items.Refresh();
        }

        private void Menu_Clear_Click(object sender, RoutedEventArgs e)
        {
            contacts.Clear();
            ContactList.Items.Refresh();
        }

        private void Menu_Import_Click(object sender, RoutedEventArgs e)
        {
            string InvalidFormatExceptionMessage = "Invalid format of XML file!";
            var dialog = new OpenFileDialog();
            dialog.Filter = "XML files (*.xml)|*.xml";
            if (dialog.ShowDialog() == true)
            {
                FileStream fs;
                try
                {
                    fs = new FileStream(dialog.FileName, FileMode.Open);
                }
                catch (IOException err)
                {
                    MessageBox.Show(err.Message);
                    return;
                }

                XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Contact>));
                
                try
                {
                    contacts = (ObservableCollection<Contact>)xs.Deserialize(fs);
                    DataContext = contacts;
                }
                catch
                {
                    MessageBox.Show(InvalidFormatExceptionMessage, ErrorCaption, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                finally
                {
                    fs.Close();
                }
            }
        }


        private void Menu_Export_Click(object sender, RoutedEventArgs e)
        {
            string CreateFileExceptionMessage = "Couldn't create file!";
            var dialog = new SaveFileDialog();
            dialog.Filter = "XML files (*.xml)|*.xml";
            if (dialog.ShowDialog() == true)
            {
                FileStream fs;
                try
                {
                    fs = new FileStream(dialog.FileName, FileMode.Create);
                }
                catch
                {
                    MessageBox.Show(CreateFileExceptionMessage, ErrorCaption, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Contact>));
                xmlSerializer.Serialize(fs, contacts);
                fs.Close();
            }
        }


        private void ContactList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox L = sender as ListBox;
            
            if (e.RemovedItems.Count > 0 &&
                e.RemovedItems[0] is Contact contact &&
                L.ItemContainerGenerator.ContainerFromItem(contact) is ListBoxItem unselectedItem)
            {
                unselectedItem.ContentTemplate = (DataTemplate)Resources["defaultContactTemplate"];
            }

            if (L.ItemContainerGenerator.ContainerFromItem(L.SelectedItem as Contact) is ListBoxItem selectedItem)
                selectedItem.ContentTemplate = (DataTemplate)Resources["selectedContactTemplate"];
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            contacts.Remove(ContactList.SelectedItem as Contact);
        }

        private void UnlockButton_Click(object sender, RoutedEventArgs e)
        {
            IsValidationLocked = false;
        }

        private void LockButton_Click(object sender, RoutedEventArgs e)
        {
            IsValidationLocked = true;
        }
    }
}