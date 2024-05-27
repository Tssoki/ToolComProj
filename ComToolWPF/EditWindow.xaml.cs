using System;
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
using System.Windows.Shapes;

namespace ComToolWPF
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        MainWindow mainWindow;
        GoogleSheetsManager manager;

        public EditWindow()
        {
            InitializeComponent();
            mainWindow = (MainWindow)Application.Current.MainWindow;
            manager = mainWindow.manager;

            if (mainWindow.CurrentSelectedEntry == null) return;

            questionTextBlock.Text = mainWindow.CurrentSelectedEntry.Question;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            manager.UpdateSingleCell(mainWindow.mySpreadSheetID, "E" + (mainWindow.CurrentSelectedEntry.Index + 3).ToString(), answerTextBox.Text);
            mainWindow.UpdateTab();
            Close();
        }
    }
}
