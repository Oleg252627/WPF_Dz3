using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DZ3zad1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> Persons { set; get; }
        public Person MyPerson { get; set; }
        private bool Flag_maxsimized = true;
        public MainWindow()
        {
            InitializeComponent();
            Persons = new ObservableCollection<Person>
            {
                new Person{ FirstName = "Николай", Surname="Никитин", Age = "30"},
                new Person{ FirstName = "Петр", Surname="Петров", Age = "40"},
                new Person{ FirstName = "Иван", Surname="Иванов", Age = "35"}
            };
            this.DataContext = Persons;
            list.ItemsSource = Persons;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void maxsimized_Click(object sender, RoutedEventArgs e)
        {
            if(Flag_maxsimized)
            {
                this.WindowState = WindowState.Maximized;
                Flag_maxsimized = false;
            }
            else
            {
                this.WindowState = WindowState.Normal;
                Flag_maxsimized = true;
            }
        }

        private void minimized_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(Imy.Text=="" || Familiy.Text=="" || Vozrost.Text=="")
            {
                MessageBox.Show("Введите все поля!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                int age = Convert.ToInt32(Vozrost.Text);
                Persons.Add(new Person { FirstName = Imy.Text, Surname = Familiy.Text, Age = Vozrost.Text });
            }
            catch (Exception)
            {
                MessageBox.Show("Не коректный ввод данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Clearrr_Click(object sender, RoutedEventArgs e)
        {
            Imy.Text = null;
            Familiy.Text = null;
            Vozrost.Text = null;
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(list.SelectedIndex!=-1)
            {
                this.Sotrudnik_panal.Visibility = Visibility.Visible;
                Person p = (Person)this.Resources["pers"];
                p.FirstName = Persons[list.SelectedIndex].FirstName;
                p.Surname = Persons[list.SelectedIndex].Surname;
                p.Age = Persons[list.SelectedIndex].Age;
            }
            else
            {
                this.Sotrudnik_panal.Visibility = Visibility.Collapsed;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(list.SelectedIndex!=-1)
            {
                Persons.RemoveAt(list.SelectedIndex);
                this.Del_first_name.Text = null;
                this.Del_surname.Text = null;
                this.Del_age.Text = null;
                this.Red_first_name.Text = null;
                this.Red_surname.Text = null;
                this.Red_age.Text = null;
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для удаления!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Rename_Click(object sender, RoutedEventArgs e)
        {
            if(list.SelectedIndex!=-1)
            {
                if(this.Red_first_name.Text=="" || this.Red_surname.Text=="" || this.Red_age.Text=="")
                {
                    MessageBox.Show("Введите все поля!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                try
                {
                    int Age = Convert.ToInt32(this.Red_age.Text);
                    Persons[list.SelectedIndex].FirstName = this.Red_first_name.Text;
                    Persons[list.SelectedIndex].Surname = this.Red_surname.Text;
                    Persons[list.SelectedIndex].Age = this.Red_age.Text;
                    Person p = (Person)this.Resources["pers"];
                    p.FirstName= this.Red_first_name.Text;
                    p.Surname= this.Red_surname.Text;
                    p.Age= this.Red_age.Text;

                }
                catch (Exception)
                {
                    MessageBox.Show("Не коректный ввод данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для изменения!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Red_first_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (list.SelectedIndex == -1)
            {
                this.Red_first_name.Text = null;
            }
        }

        private void Red_surname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (list.SelectedIndex == -1)
            {
                this.Red_surname.Text = null;
            }
        }

        private void Red_age_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (list.SelectedIndex == -1)
            {
                this.Red_age.Text = null;
            }
        }
    }
}
