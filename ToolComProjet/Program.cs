using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Linq;
using System.Net;
using System.Windows.Controls;

namespace ToolComProjet
{
    internal class Program
    {
        static void Main()
        {
            string _googleClientID = "783201556069-qvrac98c53djpeede70t42pvopjqvs3f.apps.googleusercontent.com";
            string _googleClientSecret = "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";

            string[] _scopes = new[] { Google.Apis.Sheets.v4.SheetsService.Scope.Spreadsheets };

            UserCredential _credential = GoogleAuthentification.Login(_googleClientID, _googleClientSecret, _scopes);
            GoogleSheetsManager manager = new GoogleSheetsManager(_credential);

            var _mySpreadSheetID = "199FDAfzCOxDYywfilvP5fopvGnp7_YrUv4VAlGVCXqA";
            var _spreadSheet = manager.GetSpreadSheet(_mySpreadSheetID);

            //manager.UpdateCells(_mySpreadSheetID, "D3", "Il me casse les couilles avec son ultrakill l'autre à côté");


            ////////////// READ SINGLE VALUE //////////////

            //var _finalAmountOfMoney = manager.GetSingleValue(_spreadSheet.SpreadsheetId, "B2");
            //Console.WriteLine("Final amount of money: " + _finalAmountOfMoney.Values.First().First());

            ////////////// READ MULTIPLE VALUE //////////////

            string _1range = "B3:F3";

            string[] _valueRange = new[] { _1range };
            var _multipleResponse = manager.GetMultipleValues(_mySpreadSheetID, _valueRange);

            var _response = _multipleResponse.ValueRanges.ElementAt(0);

            Console.WriteLine("\nPrinting data:");
            for (int i = 0; i < _response.Values.Count; i++)
            {
                var _name = _response.Values[i];

                for (int y = 0; y < _name.Count; y++)
                {
                    Console.WriteLine(_name[y]);
                }

                
            }

            Console.ReadLine();
        }
    }
}
