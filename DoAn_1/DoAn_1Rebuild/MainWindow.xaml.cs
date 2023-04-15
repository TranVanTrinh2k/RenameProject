using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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



namespace DoAn_1Rebuild
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
        List<IRule> activeRule = new List<IRule>();
        public static BindingList<object> listdata = new BindingList<object>();
        public static BindingList<object> listfolder = new BindingList<object>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var converter = (Converter)FindResource("converter");
            converter.Rules = activeRule;
        }
        private bool Check(string name)
        {
            if(name.Length > 255)
                return false; 
            return true;
        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            AddCouterRule.IsChecked = false;
            RemoveSpacialCharRule.IsChecked = false;
            AllLowerRule.IsChecked = false;
            PascalCaseRule.IsChecked = false;
            AddPrefixRule.IsChecked = false;
            AddSuffixRule.IsChecked = false;
            AddCouterRule.IsChecked = false;
            OneSpaceRule.IsChecked = false;
            ListViewFiles.Items.Clear();
            ListViewFolder.Items.Clear();
        }
        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            activeRule.Clear();
            
            if (RemoveSpacialCharRule.IsChecked == true)
            {
                //activeRule.Remove(new RemoveSpecialCharRule());
                activeRule.Add(new RemoveSpecialCharRule());
            }
            else
            {
                activeRule.Remove(new RemoveSpecialCharRule());
            }
            //2 Remove
            if (PascalCaseRule.IsChecked == true)
            {
                //activeRule.Remove(new PascalCase());
                activeRule.Add(new PascalCase());
            }
            else
            {
                activeRule.Remove(new PascalCase());
            }
            if (AllLowerRule.IsChecked == true)
            {
                //activeRule.Remove(new AllLower());
                activeRule.Add(new AllLower());
            }
            else
            {
                activeRule.Remove(new AllLower());
            }
            if (PascalCaseRule.IsChecked == true)
            {
                //activeRule.Remove(new PascalCase());
                activeRule.Add(new PascalCase());
            }
            else
            {
                activeRule.Remove(new PascalCase());
            }
            if (AddPrefixRule.IsChecked == true)
            {
                //activeRule.Remove(new PascalCase());
                activeRule.Add(new AddPrefixRule());
            }
            else
            {
                activeRule.Remove(new PascalCase());
            }
            if (AddSuffixRule.IsChecked == true)
            {
                //activeRule.Remove(new AddSuffix());
                activeRule.Add(new AddSuffix());
            }
            else
            {
                activeRule.Remove(new AddSuffix());
            }
            if (AddCouterRule.IsChecked == true)
            {
                /*activeRule.Remove(new AddCouterRule())*/;
                activeRule.Add(new AddCouterRule());
            }
            else
            {
                activeRule.Remove(new AddCouterRule());
            }
            if (OneSpaceRule.IsChecked == true)
            {
                //activeRule.Remove(new OneSpaceRule());
                activeRule.Add(new OneSpaceRule());
            }
            else
            {
                activeRule.Remove(new OneSpaceRule());
            }
            //1 OneSpace
            MessageBox.Show("Áp dụng quy tắc thành công");
        }

        private void OpenFolder(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderdialog = new System.Windows.Forms.FolderBrowserDialog();
            folderdialog.ShowNewFolderButton = false;
            folderdialog.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;
            System.Windows.Forms.DialogResult result = folderdialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string path = folderdialog.SelectedPath;
                DirectoryInfo folder = new DirectoryInfo(path);
                if (folder.Exists)
                {
                    if (Check(folder.Name) == false)
                    {
                        MessageBox.Show("Tập tin dài quá 255 kí tự");
                        
                    }   
                    else
                    {
                        var data = new
                        {
                            Filename = folder.Name,
                            FullPath = folder.FullName,
                        };
                        listfolder.Add(data);
                        ListViewFolder.Items.Add(data);

                    }
                }
            }
        }

        private void OpenFiles(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            //Lấy file txt hoặc tất cả các file
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            //Vào file MyPictures trên máy
            if (openFileDialog.ShowDialog() == true)
            {
                int count = 0;
                foreach (string filename in openFileDialog.FileNames) //Cho phép mở nhiều file cùng lúc
                {
                    var info = new FileInfo(filename);
                    var shortname = info.Name;
                    count++;
                    if(Check(shortname) == false)
                    {
                        
                        MessageBox.Show($"Tên của nhập tin {count} dài quá 255 kí tự");
                    }    
                    else
                    {
                        var data = new
                        {
                            FullPath = filename,
                            Filename = shortname,
                        };
                        listdata.Add(data);
                        ListViewFiles.Items.Add(data);
                    }
                }
            }
        }

        private void StartBatch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
