using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;

namespace ToolComProjet
{
    public class GoogleSheetsManager : IGoogleSheetsManager
    {
        private readonly UserCredential credential;

        public GoogleSheetsManager(UserCredential _credential)
        {
            credential = _credential;
        }

        public Spreadsheet CreateNew(string _documentName)
        {
            if (string.IsNullOrEmpty(_documentName))
                throw new ArgumentNullException(nameof(_documentName));

            using (var _sheetsService = new SheetsService(new BaseClientService.Initializer() { HttpClientInitializer = credential }))
            {
                var _documentCreationRequest = _sheetsService.Spreadsheets.Create(new Spreadsheet()
                {
                    Sheets = new List<Sheet>()
                    {
                        new Sheet()
                        {
                            Properties = new SheetProperties()
                            {
                                Title = _documentName
                            }
                        }
                    },

                    Properties = new SpreadsheetProperties()
                    {
                        Title = _documentName
                    }
                }); ;

                return _documentCreationRequest.Execute();
            }
        }

        public Spreadsheet GetSpreadSheet(string _googleSpreadsheetIdentifier)
        {
            if (string.IsNullOrEmpty(_googleSpreadsheetIdentifier))
                throw new ArgumentNullException(nameof(_googleSpreadsheetIdentifier));

            using (var _sheetService = new SheetsService(new BaseClientService.Initializer() { HttpClientInitializer = credential }))
                return _sheetService.Spreadsheets.Get(_googleSpreadsheetIdentifier).Execute();
        }

        public ValueRange GetSingleValue(string _googleSpreadsheetIdentifier, string _valueRange)
        {
            if (string.IsNullOrEmpty(_googleSpreadsheetIdentifier))
                throw new ArgumentNullException(nameof(_googleSpreadsheetIdentifier));
            if (string.IsNullOrEmpty(_valueRange))
                throw new ArgumentNullException(nameof(_valueRange));

            using (var _sheetService = new SheetsService(new BaseClientService.Initializer() { HttpClientInitializer = credential }))
            {
                var _getValueRequest = _sheetService.Spreadsheets.Values.Get(_googleSpreadsheetIdentifier, _valueRange);
                return _getValueRequest.Execute();
            }
        }

        public void RemoveSingleValue(string _googleSpreadsheetIdentifier, string _valueRange)
        {
            if (string.IsNullOrEmpty(_googleSpreadsheetIdentifier))
                throw new ArgumentNullException(nameof(_googleSpreadsheetIdentifier));
            if (string.IsNullOrEmpty(_valueRange))
                throw new ArgumentNullException(nameof(_valueRange));

            using (var _sheetService = new SheetsService(new BaseClientService.Initializer() { HttpClientInitializer = credential }))
            {
                var _removeValueRequest = _sheetService.Spreadsheets.Values.Clear(new ClearValuesRequest(), _googleSpreadsheetIdentifier, _valueRange);
                _removeValueRequest.Execute();
            }
        }

        public BatchGetValuesResponse GetMultipleValues(string _googleSpreadsheetIdentifier, string[] _ranges)
        {
            if (string.IsNullOrEmpty(_googleSpreadsheetIdentifier))
                throw new ArgumentNullException(nameof(_googleSpreadsheetIdentifier));
            if (_ranges == null || _ranges.Length == 0)
                throw new ArgumentNullException(nameof(_ranges));

            using (var _sheetService = new SheetsService(new BaseClientService.Initializer() { HttpClientInitializer = credential }))
            {
                var _getValueRequest = _sheetService.Spreadsheets.Values.BatchGet(_googleSpreadsheetIdentifier);
                _getValueRequest.Ranges = _ranges;
                return _getValueRequest.Execute();
            }
        }

        public void ClearMultipleValues(string _googleSpreadsheetIdentifier, string[] _ranges)
        {
            if (string.IsNullOrEmpty(_googleSpreadsheetIdentifier))
                throw new ArgumentNullException(nameof(_googleSpreadsheetIdentifier));
            if (_ranges == null || _ranges.Length == 0)
                throw new ArgumentNullException(nameof(_ranges));

            using (var _sheetService = new SheetsService(new BaseClientService.Initializer() { HttpClientInitializer = credential }))
            {
                var _getValueRequest = _sheetService.Spreadsheets.Values.BatchClear(new BatchClearValuesRequest() { Ranges = _ranges }, _googleSpreadsheetIdentifier);
                _getValueRequest.Execute();
            }
        }
    }
}
