using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace WindData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string ImportedFileName;
        private Dictionary<string, string> ImportedData = new Dictionary<string, string>();
        private float Displacement;
        private float AwL; // Longitudinal Windage Area
        private float AwT; // Transverse Windage Area
        private float zL; // 
        private float zT;
        private int N;

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

            Displacement = float.Parse(ImportedData["Displacement"]);
            AwL = float.Parse(ImportedData["AwL"]);
            AwT = float.Parse(ImportedData["AwT"]);
            zL = float.Parse(ImportedData["zL"]);
            zT = float.Parse(ImportedData["zT"]);
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
        }
    }
}
