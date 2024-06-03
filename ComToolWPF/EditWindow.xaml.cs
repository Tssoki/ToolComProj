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
            mainWindow.WindowList.Add(this);

            if (mainWindow.CurrentSelectedEntry == null) return;

            questionTextBlock.Text = mainWindow.CurrentSelectedEntry.Question;
            answerTextBox.Text = mainWindow.CurrentSelectedEntry.Answer;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            manager.UpdateSingleCell(mainWindow.mySpreadSheetID, "E" + (mainWindow.CurrentSelectedEntry.Index + 3).ToString(), answerTextBox.Text);
            mainWindow.UpdateTab();
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
