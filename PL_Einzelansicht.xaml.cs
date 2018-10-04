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

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für PL_Einzelansicht.xaml
    /// </summary>
    public partial class PL_Einzelansicht : Window
    {
        string empty = "";
        public PL_Einzelansicht()
        {
            InitializeComponent();
            
        }
        public void disableTextBox()
        {
            if (!string.IsNullOrWhiteSpace(txtNamePL.Text))
            {
                btnSpeichern.IsEnabled = true;
            }
            else
            {
                btnSpeichern.IsEnabled = false;
            }
            foreach (CheckBox c in P)
            {
                
            }
        }

        private void txtNamePL_TextChanged(object sender, TextChangedEventArgs e)
        {
            disableTextBox();
        }
        
    }
}
