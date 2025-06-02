using System.Linq;
using Telerik.WinControls.UI;

namespace SIMRS25.Class
{
    public static class RadGridHelper
    {
        public static string GetCellText(RadGridView grid, string columnName)
        {
            if (grid?.CurrentRow is GridViewDataRowInfo dataRow)
            {
                if (dataRow.Cells[columnName] != null)
                {
                    var value = dataRow.Cells[columnName].Value;
                    return value?.ToString()?.Trim() ?? string.Empty;
                }
            }

            return string.Empty;
        }
        public static void SafeRemoveCurrentRow(RadGridView grid)
        {
            var row = grid?.CurrentRow;

            // Cek null + pastikan itu data row asli
            if (row != null &&
                row is GridViewDataRowInfo dataRow &&
                row is not GridViewNewRowInfo)
            {
                grid?.Rows.Remove(dataRow);
            }
        }
    }
}
