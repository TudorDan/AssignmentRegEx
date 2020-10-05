using System.Text.RegularExpressions;
using System.Windows;

namespace AssignmentRegEx
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public bool ValidName(string text)
        {
            return Regex.IsMatch(text, @"^([A-Za-z]+\s*)+$");
        }

        public bool ValidPhone(string text)
        {
            return Regex.IsMatch(text, @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$");
        }

        public bool ValidEmail(string text)
        {
            return Regex.IsMatch(text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidName(txtName.Text))
                MessageBox.Show("The name is invalid (only alphabetical characters are allowed)");

            if (!ValidPhone(txtPhone.Text))
                MessageBox.Show("The phone is invalid: only (###) ###-#### digits format is allowed");

            if (!ValidEmail(txtEmail.Text))
                MessageBox.Show("The email is invalid!");
        }
    }
}
