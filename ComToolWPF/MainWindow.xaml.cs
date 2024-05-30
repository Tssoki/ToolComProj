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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using System.Timers;
using System.Runtime.CompilerServices;
using ExtensionMethods;
using System.IO.IsolatedStorage;

namespace ExtensionMethods
{
    public static class ListUpdate
    {
        public static void UpdateAll<T>(this List<T> _items, T _newValue)
        {
            for (var i = 0; i < _items.Count; i++)
            {
                _items[i] = _newValue;
            }
        }
    }
}

namespace ComToolWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string googleClientID;
        string googleClientSecret;
        string[] scopes;
        public string mySpreadSheetID { get; private set; }

        UserCredential credential;
        public GoogleSheetsManager manager { get; private set; }
        Spreadsheet spreadSheet;

        System.Timers.Timer updateTimer;
        System.Timers.Timer secondsTimer;

        private float timerUpdateValue = 60;
        private float timerValue = 0.0f;

        private Dictionary<string, EPole> stringToPole = new Dictionary<string, EPole>()
        {
            { "CCC", EPole.CCC },
            { "IA", EPole.IA },
            { "UI", EPole.UI },
            { "TOOL", EPole.TOOL },
            { "GD", EPole.GD }
        };

        private Dictionary<string, EPriority> stringToPriority = new Dictionary<string, EPriority>()
        {
            { "URGENT", EPriority.URGENT },
            { "TRANQUILLE", EPriority.TRANQUILLE },
            { "BLC", EPriority.BLC }
        };

        public int ValueCount { get; set; }

        public List<Entry> entries = new List<Entry>();

        bool isFiltered = false;

        List<Entry> currentList = new List<Entry>();

        public Entry CurrentSelectedEntry { get; private set; }

        bool isAnsweredFilter = false;

        public MainWindow()
        {
            InitializeComponent();
            InitGoogleAuth();
            InitFilterComboBox();
            ResetSecondsTimer();
            SetListItemsSource();
            SetTimer();
        }

        #region Event
        private void AddEntryButton(object sender, RoutedEventArgs e)
        {
            OpenEntryCreationWindow();
        }
        private void UpdateButtonClick(object sender, RoutedEventArgs e)
        {
            UpdateValidation();
        }
        private void ComboBoxFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (comboBoxFilter.SelectedItem == null) return;
            FilterEntries();
        }
        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            entriesDataGrid.ItemsSource = entries;
            //comboBoxFilter.SelectedItem = null;
            isFiltered = false;
        }
        private void entriesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Entry> _withAnswer = new List<Entry>();

            if (entriesDataGrid.SelectedItem != null)
                CurrentSelectedEntry = entriesDataGrid.SelectedItem as Entry;

            int _index = entriesDataGrid.SelectedIndex;
            Console.WriteLine(_index.ToString());

            if (_index < 0) return;
            if (!isFiltered)
            {
                if (entries[_index].Answer.Trim() == "")
                {
                    //editButton.Visibility = Visibility.Visible;
                }
                else
                {
                    //editButton.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                if (currentList[_index].Answer.Trim() == "")
                {
                    //editButton.Visibility = Visibility.Visible;
                }
                else
                {
                    //editButton.Visibility = Visibility.Hidden;
                }
            }
        }
        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            OpenEditWindow();
        }

        #endregion Event

        #region Init
        private void InitGoogleAuth()
        {
            googleClientID = "783201556069-qvrac98c53djpeede70t42pvopjqvs3f.apps.googleusercontent.com";
            googleClientSecret = "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";

            scopes = new[] { Google.Apis.Sheets.v4.SheetsService.Scope.Spreadsheets };
                                         
            credential = GoogleAuthentification.Login(googleClientID, googleClientSecret, scopes);
            manager = new GoogleSheetsManager(credential);

            mySpreadSheetID = "199FDAfzCOxDYywfilvP5fopvGnp7_YrUv4VAlGVCXqA";
            spreadSheet = manager.GetSpreadSheet(mySpreadSheetID);
        }
        private void InitFilterComboBox()
        {
            //comboBoxFilter.ItemsSource = System.Enum.GetValues(typeof(EPole));
            //comboBoxFilter.SelectedIndex = 0;
            //comboBoxFilter.SelectedItem = null;

            //comboBoxFilter.SelectionChanged += ComboBoxFilter_SelectionChanged;
        }
        #endregion Init

        private void SetListItemsSource()
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                if (isFiltered)
                {
                    ReadMultipleValue();
                    FilterEntries();
                    return;
                }

                entriesDataGrid.ItemsSource = ReadMultipleValue();
            }));
        }

        private List<Entry> ReadMultipleValue()
        {
            entries.Clear();
            List<Entry> _entries = new List<Entry>();
            string _range = "B3:E500";

            string[] _valueRange = new[] { _range };
            BatchGetValuesResponse _multipleResponse = manager.GetMultipleValues(mySpreadSheetID, _valueRange);

            var _response = _multipleResponse.ValueRanges.ElementAt(0);

            if (_response.Values == null) return new List<Entry>();
            for (int i = 0; i < _response.Values.Count; i++)
            {
                var _item = _response.Values[i];

                if (_item.Count >= 3)
                {
                    Entry _entry = new Entry(i ,stringToPriority[_item[0].ToString()], stringToPole[_item[1].ToString()], _item[2].ToString());
                    if (_item.Count >= 4)
                        _entry.Answer = _item[3].ToString();
                    _entries.Add(_entry);
                }
                ValueCount = _entries.Count;
            }
            entries = _entries;
            return _entries;
        }
        private void FilterEntries()
        {
            //editButton.Visibility = Visibility.Hidden;

            List<Entry> _temp = new List<Entry>();

            for (int i = 0; i < entries.Count; i++)
            {
                
                //if (stringToPole[comboBoxFilter.SelectedItem.ToString()] == entries[i].Pole)
                if (isAnsweredFilter)
                {
                    if (entries[i].Answer != "")
                        _temp.Add(entries[i]);
                }
                else
                {
                    if (entries[i].Answer == "")
                        _temp.Add(entries[i]);
                }
            }

            currentList = _temp;
            entriesDataGrid.ItemsSource = _temp;
            isFiltered = true;
        }
        void OpenEntryCreationWindow()
        {
            EntryCreationWindow _window = new EntryCreationWindow();
            _window.Show();
        }
        void OpenEditWindow()
        {
            if (CurrentSelectedEntry == null) return;
            EditWindow _window = new EditWindow();
            _window.Show();
        }


        #region Timer
        public void UpdateTab()
        {
            SetListItemsSource();
            ResetUpdateTimer();
            ResetSecondsTimer();
        }
        private void UpdateValidation()
        {
            string _message = "Pense à la limite de requête,\nC'est pour la planète !\nTu veux vraiment faire ça ?";
            string _caption = "Abuse pas frère !";
            MessageBoxButton _button = MessageBoxButton.YesNo;
            MessageBoxImage _icon = MessageBoxImage.Question;
            MessageBoxResult _result;

            _result = MessageBox.Show(_message, _caption, _button, _icon, MessageBoxResult.No);
            
            switch (_result)
            {
                case MessageBoxResult.Yes:
                    //is3C = false;
                    UpdateTab();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        private void UpdateTabValue(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("SHEET Updated");
            SetListItemsSource();
            ResetSecondsTimer();
        }
        private void UpdateSeconds(object sender, ElapsedEventArgs e)
        {
            if (timerValue >= 0)
                timerValue--;
            this.Dispatcher.Invoke(new Action(() =>
            {
                //timerLabel.Content = timerValue.ToString();
                //Console.WriteLine(is3C.ToString());
            }));
        }
        private void SetTimer()
        {
            updateTimer = new System.Timers.Timer(timerUpdateValue * 1000);
            updateTimer.Elapsed += UpdateTabValue;
            updateTimer.AutoReset = true;
            updateTimer.Enabled = true;

            secondsTimer = new System.Timers.Timer(1000);
            secondsTimer.Elapsed += UpdateSeconds;
            secondsTimer.AutoReset = true;
            secondsTimer.Enabled = true;
        }
        private void ResetUpdateTimer()
        {
            updateTimer.Stop();
            updateTimer.Start();
        }
        private void ResetSecondsTimer()
        {
            timerValue = timerUpdateValue;
        }
        #endregion Timer

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximized = true;
                }
            }
        }

        private void NoAnswerButtonClick(object sender, RoutedEventArgs e)
        {
            isAnsweredFilter = false;
            BrushConverter _converter = new BrushConverter();
            noAnswerFilterButton.BorderBrush = _converter.ConvertFromString("#784ff2") as Brush;

            answeredFilterButton.BorderBrush = null;
            FilterEntries();
        }

        private void AnsweredButtonClick(object sender, RoutedEventArgs e)
        {
            isAnsweredFilter = true;
            BrushConverter _converter = new BrushConverter();
            noAnswerFilterButton.BorderBrush = null;

            answeredFilterButton.BorderBrush = _converter.ConvertFromString("#784ff2") as Brush;
            FilterEntries();
        }

        //private void RemoveEntry(object sender, RoutedEventArgs e)
        //{
        //    manager.RemoveSingleValue(mySpreadSheetID, "B" + (3 + CurrentSelectedEntry.Index).ToString() + ":E" + (3 + CurrentSelectedEntry.Index).ToString());
        //    UpdateTab();
        //}
    }
}
