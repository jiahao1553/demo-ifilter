using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace iFIlterText
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

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            string[] filenames = { };
            Stream[] streams = { };
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|Office files (*.doc;*.docx;*.xls;*.xlsx;*.ppt;*.pptx)|*.doc;*.docx;*.xls;*.xlsx;*.ppt;*.pptx|Text files (*.txt;*.rtf)|*.txt;*.rtf|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                filenames = openFileDialog.FileNames;
                streams = openFileDialog.OpenFiles();
            }
            if (streams.Length > 0)
            {
                TextReader textReader = new IFilterTextReader.FilterReader(filenames[0]);
                using (textReader)
                {
                    readerTextbox.Text = textReader.ReadToEnd();
                }
            }
        }
    }
}
