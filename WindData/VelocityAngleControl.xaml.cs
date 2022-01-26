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

namespace WindData
{
    /* A custom control for retrieving Wind velocity and Wind Angle from the 
     * 
     * txtVelocity = Text box for user to type velocity (in knots) into
     * dropdownAngle = Combobox to select angle from using predefined angle values 
     * 
     */
    public partial class VelocityAngleControl : UserControl
    { 
        public double WindAngle;
        public double WindVelocity;

        private static string[] angleLabels = new string[] { "bow", "starboard", "stern", "port side" };
        private static Dictionary<string, double> angles = new Dictionary<string, double>()
            {
                { angleLabels[0], 0 },
                { angleLabels[1], 90 },
                { angleLabels[2], 180 },
                { angleLabels[3], 270 },
            };


        public VelocityAngleControl()
        {
            InitializeComponent();

            dropdownAngle.ItemsSource = angleLabels;

            // Default dropdown to "bow"
            dropdownAngle.SelectedIndex = 0;
            var selected = (string)dropdownAngle.SelectedItem;
            WindAngle = angles[selected];

            // Default Wind Velocity
            WindVelocity = 0;
        }

        private void dropdownAngle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = (string)dropdownAngle.SelectedItem;
            WindAngle = angles[selected];
        }

        private void txtVelocity_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                WindVelocity = double.Parse(txtVelocity.Text);
            }
            catch (Exception)
            {
                txtVelocity.Text = "";
            }
        }
    }
}
