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

    public MainWindow()
        {
            InitializeComponent();
            InitGoogleAuth();
            ReadMultipleValue();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Update");
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
            List<object> values = new List<object>();
            string _range = "B3:B20";

            string[] _valueRange = new[] { _range };
            BatchGetValuesResponse _multipleResponse = manager.GetMultipleValues(mySpreadSheetID, _valueRange);

            var _response = _multipleResponse.ValueRanges.ElementAt(0);

            Console.WriteLine("GET VALUE");
            for (int i = 0; i < _response.Values.Count; i++)
            {
                var _test = _response.Values[i];

                for (int y = 0; y < _test.Count; y++)
                {
                    Console.WriteLine(_test[y]);
                    values.Add(_test[y]);
                }
            }
            entryList.ItemsSource = values;
        }
    }
}
