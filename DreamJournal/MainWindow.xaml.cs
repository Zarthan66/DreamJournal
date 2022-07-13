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

namespace DreamJournal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool todayJournalExist;
        string baseDir = System.AppDomain.CurrentDomain.BaseDirectory;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if(MainTextBox.Foreground != Brushes.White)
            {
                MainTextBox.Clear();
                MainTextBox.Foreground = Brushes.White;
            }
        }

        private void MentionTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (MentionTextBox.Foreground != Brushes.White)
            {
                MentionTextBox.Clear();
                MentionTextBox.Foreground = Brushes.White;
            }
        }

        private void LocationTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (LocationTextBox.Foreground != Brushes.White)
            {
                LocationTextBox.Clear();
                LocationTextBox.Foreground = Brushes.White;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string fileName = (DateTime.Today.ToString()).Remove(10).Replace(' ','_').Replace('/','-') + ".txt";
            string filePath = baseDir + fileName;

            if(File.Exists(filePath))
            {
                Console.WriteLine("Replacing to: " + filePath);
                todayJournalExist = true;                
                File.WriteAllText(filePath, MainTextBox.Text);
            }
            else
            {
                Console.WriteLine("Saving to: " + filePath);
                StreamWriter file = new StreamWriter(filePath, true);

                foreach (object item in MainTextBox.Text)
                {
                    file.Write(item.ToString());
                }
                file.Close();
            }


            

            

            
            
        }
    }
}
