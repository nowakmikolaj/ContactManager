using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace ContactManager
{
    public enum Genders { Male, Female };
    
    public class Contact
    {

        public string Name { set; get; }
        public string Surname { set; get; }

        public string Email { set; get; }

        public string Phone { set; get; }

        public Genders Gender { set; get; }

        public Contact(string name = "", string surname = "", string email = "", string phone = "", Genders gender = default)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
            Gender = gender;
        }
    }

    public class ContactConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Contact contact = (Contact)value;
            return new StringBuilder()
                        .Append(contact.Name)
                        .Append(" ")
                        .Append(contact.Surname)
                        .ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Contact contact = (Contact)value;
            return contact.Gender == Genders.Male
                ? "pack://application:,,,/Resources/man.png"
                : "pack://application:,,,/Resources/woman.jpg";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
