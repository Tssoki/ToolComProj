using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;

namespace ComToolWPF
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
                _getValueRequest.MajorDimension = SpreadsheetsResource.ValuesResource.BatchGetRequest.MajorDimensionEnum.ROWS;
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

        public void UpdateSingleCell(string _googleSpreadsheetIdentifier, string _range, string _cellText)
        {
            if (string.IsNullOrEmpty(_googleSpreadsheetIdentifier))
                throw new ArgumentNullException(nameof(_googleSpreadsheetIdentifier));
            //if (_ranges == null || _ranges.Length == 0)
            //    throw new ArgumentNullException(nameof(_ranges));

            using (var _sheetService = new SheetsService(new BaseClientService.Initializer() { HttpClientInitializer = credential }))
            {
                ValueRange _valueRange = new ValueRange();
                //_valueRange.MajorDimension = "COLUMNS";

                var _obList = new List<object>() { _cellText };
                _valueRange.Values = new List<IList<object>> { _obList };

                SpreadsheetsResource.ValuesResource.UpdateRequest update = _sheetService.Spreadsheets.Values.Update(_valueRange, _googleSpreadsheetIdentifier, _range);
                update.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
                UpdateValuesResponse result2 = update.Execute();
            }
        }

        /// <summary>
        /// Update multiple cells values (NOT WORKING)
        /// </summary>
        /// <param name="_googleSpreadsheetIdentifier"></param>
        /// <param name="_range"></param>
        /// <param name="_cellText"></param>
        /// <exception cref="ArgumentNullException"></exception>
        //public void UpdateMultipleCells(string _googleSpreadsheetIdentifier, string[] _range, string _cellText)
        //{
        //    if (string.IsNullOrEmpty(_googleSpreadsheetIdentifier))
        //        throw new ArgumentNullException(nameof(_googleSpreadsheetIdentifier));
        //    //if (_ranges == null || _ranges.Length == 0)
        //    //    throw new ArgumentNullException(nameof(_ranges));

        //    using (SheetsService _sheetService = new SheetsService(new BaseClientService.Initializer() { HttpClientInitializer = credential }))
        //    {
        //        BatchUpdateValuesRequest _updateRequest = new BatchUpdateValuesRequest();
        //        //_updateRequest.Data = 

        //        ValueRange _valueRange = new ValueRange();
        //        _valueRange.MajorDimension = "RAW";

        //        var _obList = new List<object>() { _cellText, "test" };
        //        _valueRange.Values = new List<IList<object>> { _obList };

        //        SpreadsheetsResource.ValuesResource.BatchUpdateRequest _update = _sheetService.Spreadsheets.Values.BatchUpdate(_updateRequest, _googleSpreadsheetIdentifier);
        //        _update.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
        //        UpdateValuesResponse result2 = _update.Execute();
        //    }
        //}
    }
}
