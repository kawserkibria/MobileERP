using DocumentFormat.OpenXml.Spreadsheet;

namespace Mayhedi.Office.Excel.Writer.CellTypes
{
    public class TextCell : Cell
    {
        public TextCell(string header, string text, int index)
        {
            DataType = CellValues.InlineString;
            CellReference = header + index;
            InlineString = new InlineString { Text = new Text { Text = text } };
        }
    }
}
