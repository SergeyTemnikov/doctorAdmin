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

namespace doctorAdmin.Pages
{
    /// <summary>
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {

       
        List<Person> _persons;

        public WorkWindow()
        {
            InitializeComponent();

            using (MedDbContext _db = new MedDbContext())
            {
                _persons = _db.People.ToList();
                dgPersons.ItemsSource = _persons;
                var person = _persons[7];
                MessageBox.Show(person.IdMedCardNavigation.Number);
            }             
        }
    }
}
