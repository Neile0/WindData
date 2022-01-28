using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WindData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string ImportedFileName;
        private Dictionary<string, string> ImportedData = new Dictionary<string, string>();
        private double Displacement;
        private double AwL; // Longitudinal Windage Area
        private double AwT; // Transverse Windage Area
        private double zL; // Centre of Longitudinal Windage Area
        private double zT; // Centre of Transverse Windage Area
        private int N;
        private List<VelocityAngleControl> velocityAngleControls = new List<VelocityAngleControl>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Print()
        {
            txtDisplay.Text = String.Format("Filepath: {0}\n\nDisplacement: {1}\nAwL: {2}\nAwT:{3}\nzL: {4}\nzT: {5}\nN: {6}", ImportedFileName, Displacement, AwL, AwT, zL, zT, N);
        }

        private void ParseResultsFile(String filePath)
        {
            foreach (string line in File.ReadAllLines(filePath))
            {
                var keyValue = line.Split(':');
                ImportedData.Add(keyValue[0], keyValue[1].Trim());
            }

            Displacement = double.Parse(ImportedData["Displacement"]);
            AwL = double.Parse(ImportedData["AwL"]);
            AwT = double.Parse(ImportedData["AwT"]);
            zL = double.Parse(ImportedData["zL"]);
            zT = double.Parse(ImportedData["zT"]);
            N = int.Parse(ImportedData["N"]);
        }

        private void btnFileOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImportedFileName = openFileDialog.FileName;
            }
            ParseResultsFile(ImportedFileName);
            txtFileLocation.Text = ImportedFileName;
            Print();
            GenerateUserInputControls();
        }

        private void GenerateUserInputControls()
        {
            // Create N rows for user input

            int rows = N;
            for (int i = 0; i < rows; i++)
            {
                InputGrid.RowDefinitions.Add(new RowDefinition());
                var velocityAngleControl = new VelocityAngleControl();
                velocityAngleControls.Add(velocityAngleControl);
                Grid.SetRow(velocityAngleControl, i);
                InputGrid.Children.Add(velocityAngleControl);
            }
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text += '\n';
            foreach (VelocityAngleControl velocityAngleControl in velocityAngleControls)
            {
                txtDisplay.Text += String.Format("\nVw: {0}, Angle: {1}", velocityAngleControl.getWindVelocity(), velocityAngleControl.getWindAngle());
            }
        }
    }
}
