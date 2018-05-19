using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DZ3zad1
{
    public class Person: INotifyPropertyChanged
    {
        private string firstName;
        private string surname;
        private string age;
        public string FirstName
        {
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
            get
            {
                return firstName;
            }
        }
        public string Surname
        {
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
            get
            {
                return surname;
            }
        }

        public string Age
        {
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
            get
            {
                return age;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string name = "")
        {
            //if (PropertyChanged != null)
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs(name));
            //}
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }
    }
}
