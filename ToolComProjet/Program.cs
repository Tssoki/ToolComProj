using Google.Apis.Auth.OAuth2;
using System;
using System.Linq;

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

            //var _finalAmountOfMoney = manager.GetSingleValue(_spreadSheet.SpreadsheetId, "B2");        // SINGLE VALUE
            //Console.WriteLine("Final amount of money: " + _finalAmountOfMoney.Values.First().First());

            string _nameRange = "A2:A7";
            string _nbrRange = "B2:B7";

            string[] _valueRange = new[] { _nameRange, _nbrRange };
            var _multipleResponse = manager.GetMultipleValues(_mySpreadSheetID, _valueRange);

            var _nameResponse = _multipleResponse.ValueRanges.ElementAt(0);
            var _nbrResponse = _multipleResponse.ValueRanges.ElementAt(1);

            Console.WriteLine("\nPrinting data:");
            for (int i = 0; i < _nameResponse.Values.Count; i++)
            {
                var _name = _nameResponse.Values[i].First();
                var _nbr = _nbrResponse.Values[i].First();

                Console.WriteLine("Name: " + _name + "\tNBR: " + _nbr);
            }
            Console.ReadLine();
        }
    }
}
