using System;
using System.Windows;
using RentalHousingLibrary;

namespace RentalHousingApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string address = AddressTextBox.Text;
                int rooms = int.Parse(RoomsTextBox.Text);
                int beds = int.Parse(BedsTextBox.Text);
                decimal rentPerDay = decimal.Parse(RentTextBox.Text);
                decimal insurance = decimal.Parse(InsuranceTextBox.Text);
                int days = int.Parse(DaysTextBox.Text);

                decimal totalRent = rentPerDay * days;
                decimal totalCost = totalRent + insurance;

                string result = $"Адрес: {address}\n" +
                                $"Число комнат: {rooms}\n" +
                                $"Число спальных мест: {beds}\n" +
                                $"Стоимость аренды за {days} дней: {totalRent:C}\n" +
                                $"Страховой взнос: {insurance:C}\n" +
                                $"Общая стоимость: {totalCost:C}";

                ResultLabel.Content = result;
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, убедитесь, что все поля заполнены корректно.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
