using System.Windows;

namespace UserInterface {
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow:Window {
        public AboutWindow() {
            InitializeComponent();
        }

        private void About_OK_Click(object sender,RoutedEventArgs e) {
            this.Close();
        }
    }
}
