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
        bool isLocationKnown = false;
        bool isMentionSomeone = false;
        bool todayJournalExist;
        string baseDir = System.AppDomain.CurrentDomain.BaseDirectory;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddInfo(string text)
        {
            InfoTextBox.Text += Environment.NewLine + "> " + text;
            Console.WriteLine(text);
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
                isMentionSomeone = true;
                MentionTextBox.Clear();
                MentionTextBox.Foreground = Brushes.White;
            }
        }

        private void LocationTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (LocationTextBox.Foreground != Brushes.White)
            {
                isLocationKnown = true;
                LocationTextBox.Clear();
                LocationTextBox.Foreground = Brushes.White;
            }
        }

        private void TitleTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (TitleTextBox.Foreground != Brushes.White)
            {
                TitleTextBox.Clear();
                TitleTextBox.Foreground = Brushes.White;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string fileName = (DateTime.Today.ToString()).Remove(10).Replace(' ','_').Replace('/','-') + ".txt";
            string filePath = baseDir + fileName;

            string journal = "[" + DateTime.Now.ToString() + "]" + Environment.NewLine;

            // Journal logical expression
            journal += Environment.NewLine;
            journal += TitleTextBox.Text;
            journal += Environment.NewLine;

            if (MentionTextBox.Text != "" && isMentionSomeone == true)
            {
                journal += Environment.NewLine;
                journal += "Mention: " + MentionTextBox.Text;
                journal += Environment.NewLine;
            }
            if(LocationTextBox.Text != "" && isLocationKnown == true)
            {
                journal += Environment.NewLine;
                journal += "Location: " + LocationTextBox.Text;
                journal += Environment.NewLine;
            }
            
            journal += Environment.NewLine; 
            journal += MainTextBox.Text;

            // Saving journal to current base directory
            if(File.Exists(filePath))
            {
                AddInfo("Replacing to: " + filePath);
                todayJournalExist = true;                
                File.WriteAllText(filePath, journal);
            }
            else
            {
                AddInfo("Saving to: " + filePath);
                StreamWriter file = new StreamWriter(filePath, true);

                foreach (object item in journal)
                {
                    file.Write(item.ToString());
                }
                file.Close();
            }
        }

        
    }
}
