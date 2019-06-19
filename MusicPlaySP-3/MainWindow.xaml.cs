using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace MusicPlaySP_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var thread = new Thread(PlaingMusic);
            thread.IsBackground = true;
            thread.Start();
            PlaingMusic();
        }

        public WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();

        public void PlaingMusic()
        {
            WMP.URL = @"Linkin_Park_-_New_Divide.mp3";
            WMP.controls.play();
            //WMP.close();
        }

        private void IfWindowsClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Thread myThread = new Thread(SaveRichBox);
            myThread.Start();
        }

        private void SaveRichBox()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("SavingText.txt", true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text);
                    sw.Close();
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
