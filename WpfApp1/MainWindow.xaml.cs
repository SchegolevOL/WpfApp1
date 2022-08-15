using System.Collections.ObjectModel;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> Persons { get; set; }
        
        public MainWindow()
        {
            var db = new DataBase();
            var persons = db.GetAllPersons();
            Persons = new ObservableCollection<Person>(persons);
            
            InitializeComponent();
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            var db = new DataBase();
            db.UpdateAllPersons(Persons);
        }
    }
}