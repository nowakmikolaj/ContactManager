﻿using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.CompilerServices;

namespace ContactManager
{
    public enum Genders { Male, Female };
    
    public class Contact : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string name;
        private string surname;
        private string email;
        private string phone;
        private Genders gender;

        public string Name { 
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyRaised("Name");
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyRaised("Surname");
            }
        }

        [XmlElement(IsNullable = true)]
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyRaised("Email");
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                OnPropertyRaised("Phone");
            }
        }

        public Genders Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
                OnPropertyRaised("Gender");
            }
        }

        public Contact()
        {
        }

        public Contact(string name, string surname, string email, string phone, Genders gender)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
            Gender = gender;
        }

        private void OnPropertyRaised([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
