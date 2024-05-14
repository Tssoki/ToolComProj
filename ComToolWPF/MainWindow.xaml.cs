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
        UserCredential credential;
        GoogleSheetsManager manager;
        string mySpreadSheetID;
        Spreadsheet spreadSheet;

        int index = 3;
        string startingRange = "B3";
        string currentRange;
        string finalRange;

        System.Timers.Timer timer;

    public MainWindow()
        {
            InitializeComponent();
            InitGoogleAuth();
            ReadMultipleValue();
            SetTimer();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReadMultipleValue();
        }

        private void InitGoogleAuth()
        {
            googleClientID = "783201556069-qvrac98c53djpeede70t42pvopjqvs3f.apps.googleusercontent.com";
            googleClientSecret = "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";

            scopes = new[] { Google.Apis.Sheets.v4.SheetsService.Scope.Spreadsheets };
                                         
            credential = GoogleAuthentification.Login(googleClientID, googleClientSecret, scopes);
            manager = new GoogleSheetsManager(credential);

            mySpreadSheetID = "199FDAfzCOxDYywfilvP5fopvGnp7_YrUv4VAlGVCXqA";
            spreadSheet = manager.GetSpreadSheet(mySpreadSheetID);

            currentRange = "B" + index.ToString();
        }

        private void ReadMultipleValue()
        {
            List<Entry> _entries = new List<Entry>();
            string _range = "B3:E100";

            string[] _valueRange = new[] { _range };
            BatchGetValuesResponse _multipleResponse = manager.GetMultipleValues(mySpreadSheetID, _valueRange);

            var _response = _multipleResponse.ValueRanges.ElementAt(0);

            for (int i = 0; i < _response.Values.Count; i++)
            {
                var _item = _response.Values[i];

                if (_item.Count >= 3)
                {
                    Entry _entry = new Entry(_item[0].ToString(), _item[1].ToString(), _item[2].ToString());
                    if (_item.Count >= 4)
                        _entry.Answer = _item[3].ToString();
                    _entries.Add(_entry);
                }
            }
            this.Dispatcher.Invoke((Action)(() =>
            {
                entryList.ItemsSource = _entries;
            }));
        }

        private void SetTimer()
        {
            timer = new System.Timers.Timer(60000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("SHEET Updated");
            ReadMultipleValue();
        }
    }
}
