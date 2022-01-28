using System;
using System.Collections.Generic;
using System.Windows.Controls;

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

        public double getWindAngle()
        {
            // Get degree value
            double value = Double.Parse(txtAngle.Text);

            // Get offset (wind measured against) from dropdown
            var selected = (string)dropdownAngle.SelectedItem;
            double offset = angles[selected];

            return (value + offset) % 360; // Mod 360 to restrict angle to [0, 360)
        }

        public double getWindVelocity()
        {
            return Double.Parse(txtVelocity.Text);
        }
    }
}
