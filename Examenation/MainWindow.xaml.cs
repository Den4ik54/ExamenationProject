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

namespace Examenation
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        
        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            Fuel fuel = new Fuel();
            fuel.Rasschet(Convert.ToDouble(txbObiem.Text), Convert.ToDouble(txbPlotnost.Text));
        }

        private void btnContinueStorage_Click(object sender, RoutedEventArgs e)
        {
            Storage storage = new Storage();
            storage.Dostupno(Convert.ToDouble(txbVsegoObiem.Text), Convert.ToDouble(txbTekZapas.Text));
        }

        private void btnContinueAzs_Click(object sender, RoutedEventArgs e)
        {
            GasFuel gas = new GasFuel();
            if (cmbFunction.SelectedItem != null)
            {
                if (cmbFunction.Text == "Добавление") { gas.Add(Convert.ToDouble(txbOpredObiem.Text)); }
                if (cmbFunction.Text == "Извлечение") { gas.Del(Convert.ToDouble(txbOpredObiem.Text)); }
            }else { MessageBox.Show("Выпадающий списк не должен быть пустым!"); }
            }
    }

    public class Fuel
    {
        public void Rasschet(double l, double p)
        {
            double m = l * p;
            MessageBox.Show($"Масса топлива - {m}");
        }
        
    }
    
    public class Storage
    {
        public void Dostupno(double ob, double zap)
        {
            double d = ob - zap;
            MessageBox.Show($"Доступный объем хранилища: {d}");
        }
    }
    
    public class GasFuel
    {
        public double gaz;
        public void Add(double litr)
        {
            gaz += litr;
            MessageBox.Show($"В хранилище было добавлено {litr} литр(ов), Доступный объем: {gaz}");
        }

        public void Del(double litr)
        {
            if (gaz > litr)
            {
                gaz -= litr;
                MessageBox.Show($"Вы были заправлены на {litr} литр(ов)");
            }
            else { MessageBox.Show($"На данной станции недостаточно топлива! Доступный объем: {gaz} литр(ов)!"); }
        }
    }
}
