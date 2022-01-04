﻿using Microsoft.Win32;
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
using System.Windows.Documents;

namespace Tsk7WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текcтовые файлы (*.txt)|*.txt|Все файлы (*.*)|(*.*)";
            if (openFileDialog.ShowDialog() == true)
            {
                TextRange doc = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
                using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    if (System.IO.Path.GetExtension(openFileDialog.FileName).ToLower() == ".txt")
                        doc.Load(fs, DataFormats.Text);
                    else
                        doc.Load(fs, DataFormats.Xaml);
                }
            }

        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текcтовые файлы (*.txt)|*.txt|Все файлы (*.*)|(*.*)";
            if (saveFileDialog.ShowDialog() == true)
            {
                TextRange doc = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
                using (FileStream fs = File.Create(saveFileDialog.FileName))
                {
                    if (System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);                    
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
            }
        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string fontSize = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (textBox != null)
            {
                textBox.FontSize = Convert.ToDouble(fontSize);
            }
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //RadioButton radioButton = RadioButton as sender;
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Black;
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Red;
            }
        }

    }
}
