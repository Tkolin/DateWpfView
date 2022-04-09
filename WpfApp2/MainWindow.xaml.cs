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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        tranEntities context;

        public MainWindow()
        {
            InitializeComponent();
            context = new tranEntities();
            DataGridRegistration.ItemsSource = context.CourseRegistration.ToList();

        }

        public void ShowTable()
        {
            DataGridRegistration.ItemsSource = context.CourseRegistration.ToList();
        }

        private void BtnDelData_Click(object sender, RoutedEventArgs e)
        {
            var row = DataGridRegistration.SelectedItem as CourseRegistration;
            if (row == null)
            {
                MessageBox.Show("Выберите строку для удаления!");
                return;
            }
            MessageBoxResult messageBox = MessageBox.Show("Вы действительно хотите удалить регистрацию на курс" + 
            row.Course.Title + "тренера" + row.Trainer.NameTrainer + "?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (MessageBoxResult.Yes == messageBox)
            {
                context.CourseRegistration.Remove(row);
                context.SaveChanges();
                ShowTable();
            }
        }

        private void BtnAddData_Click(object sender, RoutedEventArgs e)
        {
            var NewRegistration = new CourseRegistration();
            context.CourseRegistration.Add(NewRegistration);
            var AddWindow = new Window1(context, NewRegistration);
            AddWindow.ShowDialog();
            ShowTable();


        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit= sender as Button;
            var CurrentRegistration = BtnEdit.DataContext as CourseRegistration;
            var EditWindow = new Window1(context, CurrentRegistration);
            EditWindow.ShowDialog();
            ShowTable();
        }
    }
}
