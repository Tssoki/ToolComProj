using Google.Apis.Sheets.v4.Data;

namespace ComToolWPF
{
    internal interface IGoogleSheetsManager
    {
        Spreadsheet CreateNew(string _documentName);
        /// <summary>
        /// Retrieves a spreadsheet given its identifier
        /// </summary>
        /// <param name="_googleSpreadsheetIdentifier"></param>
        /// <returns></returns>
        Spreadsheet GetSpreadSheet(string _googleSpreadsheetIdentifier);
        /// <summary>
        /// Retrieves a value from a cell given its coordinates
        /// </summary>
        /// <param name="_googleSpreadsheetIdentifier"></param>
        /// <param name="_valueRange"></param>
        /// <returns></returns>
        ValueRange GetSingleValue(string _googleSpreadsheetIdentifier, string _valueRange);
        /// <summary>
        /// Clears a spreadsheet cell given its coordinates
        /// </summary>
        /// <param name="_googleSpreadsheetIdentifier"></param>
        /// <param name="_valueRange"></param>
        void RemoveSingleValue(string _googleSpreadsheetIdentifier, string _valueRange);
        /// <summary>
        /// Retrieves a value from a set of values (columns or entire tables)
        /// </summary>
        /// <param name="_googleSpreadsheetIdentifier"></param>
        /// <param name="_ranges"></param>
        /// <returns></returns>
        BatchGetValuesResponse GetMultipleValues(string _googleSpreadsheetIdentifier, string[] _ranges);
        /// <summary>
        /// Clear a spreadsheet set of values (columns or entire tables)
        /// </summary>
        /// <param name="_googleSpreadsheetIdentifier"></param>
        /// <param name="_ranges"></param>
        void ClearMultipleValues(string _googleSpreadsheetIdentifier, string[] _ranges);

        void UpdateSingleCell(string _googleSpreadsheetIdentifier, string _range, string _cellText);
        //void UpdateMultipleCells(string _googleSpreadsheetIdentifier, string _range, string _cellText);
    }
}
