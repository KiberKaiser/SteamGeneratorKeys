using System;
using System.IO;
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
using Microsoft.Win32;
using System.Diagnostics.SymbolStore;

namespace GeneratorKeys
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
            
        string GenerateKeyPart()
        {
            const string chars = "ABСDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            string keyPart = string.Empty;
            for(int i = 0; i < 5; i++)
            {
                keyPart += chars[random.Next(0, chars.Length)];
            }
            return keyPart;
        }
        private bool isFirstTypeSelected = false;
        private bool isSecondTypeSelected = false;

        private void button_Generate_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumericTextBox.Text, out int count))
            {
                if (count > 0)
                {
                   if (isFirstTypeSelected)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            textBox.Text += $"{GenerateKeyPart()}-{GenerateKeyPart()}-{GenerateKeyPart()}\r\n";
                        }
                    }
                    else if (isSecondTypeSelected)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            textBox.Text += $"{GenerateKeyPart()}-{GenerateKeyPart()}-{GenerateKeyPart()}-{GenerateKeyPart()}-{GenerateKeyPart()}\r\n";
                        }
                    }
                }
            }
        }

        private void checkBox_FirstType_Checked(object sender, RoutedEventArgs e)
        {
            isFirstTypeSelected = true;
            isSecondTypeSelected = false;
            checkBox_SecondType.IsChecked = false;
        }

        private void checkBox_SecondType_Checked(object sender, RoutedEventArgs e)
        {
            isFirstTypeSelected = false;
            isSecondTypeSelected = true;
            checkBox_FirstType.IsChecked = false;
        }

        private void checkBox_FirstType_Unchecked(object sender, RoutedEventArgs e)
        {
            isFirstTypeSelected = false;
        }

        private void checkBox_SecondType_Unchecked(object sender, RoutedEventArgs e)
        {
            isSecondTypeSelected = false;
        }
       
        private void button_Clear_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
        }
        private void СloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void button_SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }


        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumericTextBox.Text, out int value))
            {
                value++;
                NumericTextBox.Text = value.ToString();
            }
        }

        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumericTextBox.Text, out int value))
            {
                if (value > 0)
                {
                    value--;
                    NumericTextBox.Text = value.ToString();
                }
                else if(value < 1)
                {
                    NumericTextBox.Text = "0";
                }
            }
        }

        private void Form_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
   
}
