using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Controller;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace UserInterface {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow:INotifyPropertyChanged {
        private int _SelectedFrom;
        private int _SelectedTo;
        private string _InfoText;
        private string _EnteredNum;
        private string _Result;

        public string InfoText {
            get { return _InfoText; }
            set {
                if(_InfoText != value) {
                    _InfoText = value;
                    OnPropertyChanged();
                }
            }
        }
        public string EnteredNum {
            get { return _EnteredNum; }
            set {
                if(_EnteredNum != value) {
                    _EnteredNum = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Result {
            get { return _Result; }
            set {
                if(_Result != value) {
                    _Result = value;
                    OnPropertyChanged();

                }
            }
        }      

        public MainWindow() {
          
            DataContext = this;
            InitializeComponent();
            UpdateFrom();
            UpdateTo();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }

        private void ConvertClicked(object sender,RoutedEventArgs e) {           
            Result = Program.Convert(_SelectedFrom,_SelectedTo,_EnteredNum);               
        }

        private void FromComboxSelected(object sender,SelectionChangedEventArgs e) {            
            UpdateFrom(ComboBoxFrom.SelectedIndex);
            InfoText = Program.InfoDisplay(_SelectedFrom);
        }

        private void ToComboxSelected(object sender,SelectionChangedEventArgs e) {
            UpdateTo(ComboBoxTo.SelectedIndex);      
            InfoText = Program.InfoDisplay(_SelectedTo);
        }
        private void UpdateFrom(int index = 0) {
            _SelectedFrom = index;
        }
        private void UpdateTo(int index = 0) {
            _SelectedTo = index;
        }

        private void EnterBox(object sender,TextCompositionEventArgs e) {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text,"[^0-9.abcdef]+");
        }

        private static bool IsTextAllowed(string text) {
            Regex regex = new Regex("[^0-9.abcdef]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }
        // Use the DataObject.Pasting Handler 
        private void TextBoxPasting(object sender,DataObjectPastingEventArgs e) {
            if(e.DataObject.GetDataPresent(typeof(String))) {
                String text = (String)e.DataObject.GetData(typeof(String));
                if(!IsTextAllowed(text)) {
                    e.CancelCommand();
                }
            }
            else {
                e.CancelCommand();
            }
        }
        private void Reset_Click(object sender,RoutedEventArgs e) {
            ComboBoxFrom.SelectedIndex = 0;
            ComboBoxTo.SelectedIndex = 0;
            EnteredNum = "";
            Result = "";
        }

        private void Exit_menuItem(object sender,RoutedEventArgs e) {
            Application.Current.Shutdown();
        }        

        private void About_Click(object sender,RoutedEventArgs e) {
            AboutWindow AboutWin = new AboutWindow();
            AboutWin.ShowDialog();
        }
    }
}
