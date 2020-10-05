using System;
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

        public string ReformatPhone(int number)
        {
            return String.Format("{0:(###) ###-####}", number);
        } 

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool ok = true;

            if (!ValidName(txtName.Text))
            {
                MessageBox.Show("The name is invalid (only alphabetical characters are allowed)");
                ok = false;
            }   

            if (!ValidPhone(txtPhone.Text))
            {
                MessageBox.Show("The phone is invalid: only (###) ###-#### digits format is allowed");
                ok = false;
            }

            if (!ValidEmail(txtEmail.Text))
            {
                MessageBox.Show("The email is invalid!");
                ok = false;
            }
              
            if (ok)
            {
                int number = Int32.Parse(txtPhone.Text);
                txtPhone.Text = ReformatPhone(number);
            }
        }
    }
}
