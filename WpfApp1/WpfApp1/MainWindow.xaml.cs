using System;
using System.Windows;
using System.IO;
using System.Windows.Media;
using System.Windows.Controls;
using Syncfusion.XlsIO;
using Spire.Xls;
using System.Text;
using Microsoft.Win32;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        int k = 2, count = 0;
        // создание массива 1 массив для данных(название), 2 массив для ячейки(в2)
        string[] name_array = new string[0];
        string[] surname_array = new string[0];
        string[] email_array = new string[0];
        string[] password_array = new string[0];

        string[] name_cellarray = new string[0];
        string[] surname_cellarray = new string[0];
        string[] email_cellarray = new string[0];
        string[] password_cellarray = new string[0];
        Brush Siren = (Brush)(new BrushConverter().ConvertFrom("#749dd2"));
        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            User user = new User();
            
        }

        private void AddNote(object sender, RoutedEventArgs e)
        {
            
            int NameMark = 1;
            int SurnameMark = 1;
            int EmailMark = 1;

            SurnameValidateMsg.Content = "";
            NameValidateMsg.Content = "";
            EmailValidateMsg.Content = "";
            
            if (SurnameField.Text.Length < 2 || SurnameField.Text.Length > 24 || String.IsNullOrEmpty(SurnameField.Text))
            {
                if (SurnameField.Text.Length < 2)
                {
                    SurnameValidateMsg.Content = "Фамилия должна содержать не менее 2 символов";
                    SurnameField.BorderBrush = Brushes.Red;
                    SurnameMark = 0;
                }
                if (SurnameField.Text.Length > 24)
                {
                    SurnameValidateMsg.Content = "Максимально допустимое количество символов - 24";
                    SurnameField.BorderBrush = Brushes.Red;
                    SurnameMark = 0;
                }
                if(String.IsNullOrEmpty(SurnameField.Text))
                {
                    SurnameValidateMsg.Content = "Данное поле не может быть пустым";
                    SurnameField.BorderBrush = Brushes.Red;
                    SurnameMark = 0;
                }
            }

            if (NameField.Text.Length < 2 || NameField.Text.Length > 24 || String.IsNullOrEmpty(NameField.Text))
            {
                if (NameField.Text.Length < 2)
                {
                    NameValidateMsg.Content = "Имя должно содержать не менее 2 символов";
                    NameField.BorderBrush = Brushes.Red;
                    NameMark = 0;
                }
                if (NameField.Text.Length > 24)
                {
                    NameValidateMsg.Content = "Максимально допустимое количество символов - 24";
                    NameField.BorderBrush = Brushes.Red;
                    NameMark = 0;
                }
                if (String.IsNullOrEmpty(NameField.Text))
                {
                    NameValidateMsg.Content = "Данное поле не может быть пустым";
                    NameField.BorderBrush = Brushes.Red;
                    NameMark = 0;
                }
            }

            if ((EmailField.Text.IndexOf("@") > -1) && (EmailField.Text.IndexOf(".") > -1))
            {

            }
            else
            {
                EmailField.BorderBrush = Brushes.Red;
                EmailMark = 0;
                EmailValidateMsg.Content = "Email-адрес должен соответствовать формату example@gmail.com";
            }

            if (EmailField.Text.Length < 5 || EmailField.Text.Length > 100 || String.IsNullOrEmpty(EmailField.Text))
            {
                if (EmailField.Text.Length < 5)
                {
                    EmailValidateMsg.Content = "Email должен содержать не менее 5 символов";
                    EmailField.BorderBrush = Brushes.Red;
                    EmailMark = 0;
                }
                if (NameField.Text.Length > 100)
                {
                    EmailValidateMsg.Content = "Максимально допустимое количество символов - 100";
                    EmailField.BorderBrush = Brushes.Red;
                    EmailMark = 0;
                }
                if (String.IsNullOrEmpty(EmailField.Text))
                {
                    EmailValidateMsg.Content = "Данное поле не может быть пустым";
                    EmailField.BorderBrush = Brushes.Red;
                    EmailMark = 0;
                }
            }
            
            if ((NameMark == 1) && (SurnameMark == 1) && (EmailMark == 1))
            {
                string K = Convert.ToString(k);
                string b = "B";
                string c = "C";
                string d = "D";
                string l = "L";
                User userA = new User();
                userA.Name = SurnameField.Text;
                userA.Surname = NameField.Text;
                userA.Email = EmailField.Text;
                userA.Password = PasswordField.Text;

                //расширение массива на 1 единицу
                Array.Resize(ref name_array, name_array.Length + 1);
                Array.Resize(ref surname_array, surname_array.Length + 1);
                Array.Resize(ref email_array, email_array.Length + 1);
                Array.Resize(ref password_array, password_array.Length + 1);
                Array.Resize(ref name_cellarray, name_cellarray.Length + 1);
                Array.Resize(ref surname_cellarray, surname_cellarray.Length + 1);
                Array.Resize(ref email_cellarray, email_cellarray.Length + 1);
                Array.Resize(ref password_cellarray, password_cellarray.Length + 1);

                name_array[count] = userA.Name;
                surname_array[count] = userA.Surname;
                email_array[count] = userA.Email;
                password_array[count] = userA.Password;
                name_cellarray[count] = c + K;
                surname_cellarray[count] = d + K;
                email_cellarray[count] = b + K;
                password_cellarray[count] = l + K;
                k++;
                count++;

                SurnameField.Clear();
                NameField.Clear();
                EmailField.Clear();
                SurnameValidateMsg.Content = "";
                NameValidateMsg.Content = "";
                EmailValidateMsg.Content = "";
                PasswordValidateMsg.Content = "";
                SurnameField.BorderBrush = Siren;
                NameField.BorderBrush = Siren;
                EmailField.BorderBrush = Siren;
                PasswordField.BorderBrush = Siren;
            }
            ////MessageBox.Show("Данные сохранены. Нажмите 'Ок', чтобы продолжить.");
        }

        public void SaveFile(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(PathField.Text))
            {
                PathSelectValidateMsg.Content = "Необходимо выбрать путь";
                PathField.BorderBrush = Brushes.Red;
            }
            else
            {
                string output = PathField.Text + ".xlsx";
                using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    IApplication application = excelEngine.Excel;
                    application.DefaultVersion = Syncfusion.XlsIO.ExcelVersion.Excel2016;
                    IWorkbook workbook = application.Workbooks.Create(1);
                    IWorksheet worksheet = workbook.Worksheets[0];
                    worksheet.Range["A1"].Text = "id";
                    worksheet.Range["B1"].Text = "email";
                    worksheet.Range["C1"].Text = "lname";
                    worksheet.Range["D1"].Text = "fname";
                    worksheet.Range["E1"].Text = "mname";
                    worksheet.Range["F1"].Text = "gender";
                    worksheet.Range["G1"].Text = "city";
                    worksheet.Range["H1"].Text = "phone";
                    worksheet.Range["I1"].Text = "position";
                    worksheet.Range["J1"].Text = "manager_";
                    worksheet.Range["K1"].Text = "login";
                    worksheet.Range["L1"].Text = "password";
                    worksheet.Range["M1"].Text = "my_field";

                    for (int i = 0; i < email_array.Length; i++)
                    {
                        worksheet.Range[email_cellarray[i]].Text = email_array[i];
                        worksheet.Range[name_cellarray[i]].Text = name_array[i];
                        worksheet.Range[surname_cellarray[i]].Text = surname_array[i];
                        worksheet.Range[password_cellarray[i]].Text = password_array[i];
                    }

                    workbook.SaveAs(@output);
                    PathField.BorderBrush = Siren;
                    PathSelectValidateMsg.Content = "";

                    string output2 = PathField.Text + ".csv";
                    Workbook workbook2 = new Workbook();
                    workbook2.LoadFromFile(output);

                    //Get the first worksheet
                    Worksheet sheet = workbook2.Worksheets[0];

                    //Save the worksheet as CSV
                    sheet.SaveToFile(output2, ";", Encoding.UTF8);
                    PopUp.Content = "Файл сохранен в формате .xlsx и .csv";
                }
                
                //MessageBox.Show("Файл сохранен");
                PathField.BorderBrush = Siren;
                PathField.Text = "";
                PathSelectValidateMsg.Content = "";
            }

        }

        private void EscClick(object sender, RoutedEventArgs e)
        {
            this.Close(); // закрытие окна
        }

        private void SelectDirectory_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                PathField.Text = saveFileDialog.FileName;
            }
                //File.WriteAllText(saveFileDialog.FileName, PathField.Text);
        }
    }
}
