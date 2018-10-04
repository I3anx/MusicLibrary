using System;
using System.Collections.Generic;
using System.Diagnostics;
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


namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string text = "Stop";
        
       
        public MainWindow()
        {
            InitializeComponent();
            // Aufruf diverse APIDemo Methoden
            APIDemo.DemoBCreate();
            APIDemo.DemoACreate();
            APIDemo.DemoARead();
            APIDemo.DemoBRead();
            APIDemo.DemoAUpdate();
            APIDemo.DemoARead();
            APIDemo.DemoBRead();
            //APIDemo.DemoADelete();
            APIDemo.DemoBRead();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(text);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PL_Einzelansicht PL = new PL_Einzelansicht();
            PL.Show();
            this.Close();

            //Lied_Listenansicht lied = new Lied_Listenansicht();
            //lied.Show();
            //this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Möchten sie wirklich abbrechen?");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }
    }
}
