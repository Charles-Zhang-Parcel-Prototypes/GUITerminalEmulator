using System.Diagnostics;
using System.IO;
using System.Windows;

namespace GUITerminalEmulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Configurations
        public const string SourceFolder = @"C:\Users\szinu\Desktop\Example";
        #endregion

        #region Construction
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Process process = Process.Start(new ProcessStartInfo()
            {
                FileName = "python",
                Arguments = "Type1.py",

                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = SourceFolder
            });
            process.Start();
            string outputs = process.StandardOutput.ReadToEnd();

            OutputTextBox.Text = outputs;
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Process process = Process.Start(new ProcessStartInfo()
            {
                FileName = "pure.exe",
                Arguments = "Type2.cs \"Charles Zhang\"",

                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = SourceFolder
            });
            process.Start();
            string outputs = process.StandardOutput.ReadToEnd();

            OutputTextBox.Text = outputs;
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Process process = Process.Start(new ProcessStartInfo()
            {
                FileName = "pure.exe",
                Arguments = "Type3.cs",

                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = SourceFolder
            });
            process.Start();

            StreamWriter myStreamWriter = process.StandardInput;
            myStreamWriter.WriteLine("Charles Zhang");
            myStreamWriter.WriteLine("65");

            string outputs = process.StandardOutput.ReadToEnd();

            // TODO: Can we assemble it somehow to format like terminal?
            OutputTextBox.Text = outputs;
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            // TODO
            // How do we do it?
            // How do we pass inputs?
            // How do we get outputs?
        }
        #endregion

        private void OutputTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Console.WriteLine();
        }
    }
}