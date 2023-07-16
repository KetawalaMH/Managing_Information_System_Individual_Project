using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Individual_Project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Individual_Project
{
    public  partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public  ObservableCollection<Student> students;
        [ObservableProperty]
        public Student selectedStudent=null;



        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }




        [RelayCommand]
        public void messeag()
        {

            MessageBox.Show($"{SelectedStudent.FirstName} GPA value must be between 0 and 4.", "Error");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddUserVM();
            vm.Title = "ADD STUDENT";
            AddUserWindow window = new AddUserWindow(vm);
            window.ShowDialog();

            if (vm.Student.FirstName != null)
            {
                Students.Add(vm.Student);
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (SelectedStudent != null)
            {
                string name = SelectedStudent.FirstName;
                Students.Remove(SelectedStudent);
                MessageBox.Show($"{name} is Deleted successfuly.", "DELETED \a ");
                
            }
            else
            {
                MessageBox.Show("Plese Select Student before Delete.", "Error");


            }
        }
        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (SelectedStudent != null)
            {
                var vm = new AddUserVM(SelectedStudent);
                vm.Title = "EDIT STUDENT";
                var window = new AddUserWindow(vm);

                window.ShowDialog();


                int index = Students.IndexOf(SelectedStudent);
                Students.RemoveAt(index);
                Students.Insert(index, vm.Student);



            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }

        public  MainWindowVM()
        {
            students = new ObservableCollection<Student>();
            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/1.png", UriKind.Relative));
            students.Add(new Student("Tom", "Black", "04/11/1998",image1,3.9));
            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/2.png", UriKind.Relative));
            students.Add(new Student("Jhone", "Carry", "26/12/1997",image2,2.5));
            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/3.png", UriKind.Relative));
            students.Add(new Student("Jerry", "Cater", "05/10/2000",image3,3.1));
            BitmapImage image4= new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
            students.Add(new Student("Grace", "Juliya", "12/1/2000", image4, 3.0));

        }
    }
}
