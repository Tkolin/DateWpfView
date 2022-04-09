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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        tranEntities context;
        public Window1(tranEntities context,
            CourseRegistration courseRegistration) 
        {
            InitializeComponent();
            this.context = context;
            CmbCourse.ItemsSource = context.Course.ToList();
            CmbTrainer.ItemsSource = context.Trainer.ToList();
            this.DataContext = courseRegistration;
        }

        private void SaveData_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            this.Close();

        }
    }
}
