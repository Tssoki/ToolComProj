using Google.Apis.Sheets.v4.Data;
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
    /// Interaction logic for EntryCreationWindow.xaml
    /// </summary>
    public partial class EntryCreationWindow : Window
    {
        MainWindow mainWindow;
        GoogleSheetsManager manager;

        public EntryCreationWindow()
        { 
            InitializeComponent();
            InitComboBox();
            mainWindow = (MainWindow)Application.Current.MainWindow;
            manager = mainWindow.manager;
            mainWindow.WindowList.Add(this);

        }

        private void InitComboBox()
        {
            comboBoxPriority.ItemsSource = System.Enum.GetValues(typeof(EPriority));
            comboBoxPriority.SelectedIndex = 0;

            comboBoxPole.ItemsSource = System.Enum.GetValues(typeof(EPole));
            comboBoxPole.SelectedIndex = 0;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            manager.UpdateSingleCell(mainWindow.mySpreadSheetID, "B" + (mainWindow.ValueCount + 3).ToString(), comboBoxPriority.Text);
            manager.UpdateSingleCell(mainWindow.mySpreadSheetID, "C" + (mainWindow.ValueCount + 3).ToString(), comboBoxPole.Text);
            manager.UpdateSingleCell(mainWindow.mySpreadSheetID, "D" + (mainWindow.ValueCount + 3).ToString(), textBoxQuestion.Text);
            mainWindow.ReadMultipleValue();
            mainWindow.SetListItemsSource();
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
