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

namespace HW
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



        private void PayBtnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(iinText.Text) ||
                string.IsNullOrEmpty(streetText.Text) ||
                string.IsNullOrEmpty(houseNumText.Text) ||
                string.IsNullOrEmpty(apartmentNumText.Text) ||
                string.IsNullOrEmpty(phoneNumText.Text) ||
                string.IsNullOrEmpty(sumText.Text))
            {
                MessageBox.Show("Не заполнены некоторые поля");
                return;
            }

            if (waterRB.IsChecked == false && lightRB.IsChecked == false)
            {
                MessageBox.Show("Не выбран тип оплаты");
                return;
            }

            if (!(int.TryParse(sumText.Text, out var sum)))
            {
                MessageBox.Show("Введите целое число!");
                return;
            }

            try
            {
                using (var context = new Context())
                {
                    context.Receipts.Add(new Receipt
                    {
                        IIN = iinText.Text,
                        FlatNum = apartmentNumText.Text,
                        HouseNum = houseNumText.Text,
                        PhoneNum = phoneNumText.Text,
                        Street = streetText.Text,
                        Sum = sum,
                        Type = waterRB.IsChecked == true ? waterRB.Name : lightRB.Name,
                    });
                    context.SaveChanges();
                    MessageBox.Show("Принято");
                    iinText.Text = string.Empty;
                    apartmentNumText.Text = string.Empty;
                    houseNumText.Text = string.Empty;
                    phoneNumText.Text = string.Empty;
                    streetText.Text = string.Empty;
                    iinText.Text = string.Empty;
                    sumText.Text = string.Empty;
                    waterRB.IsChecked = false;
                    lightRB.IsChecked = false;
                }
            }
            catch
            {
                MessageBox.Show("Отклонено");
            }
        }
    }
}
