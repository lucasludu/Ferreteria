using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ExcelDataReader;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Row = DocumentFormat.OpenXml.Spreadsheet.Row;

namespace Ferreteria.View.Utiles
{
    public static class ExcelUtil
    {

        #region Exportar a CSV

        // Método privado para realizar la exportación a .csv
        private static void ExportToCSV(DataGridView dataGridView, string filePath)
        {
            StringBuilder csvContent = new StringBuilder();

            // Añadir encabezados
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                csvContent.Append(dataGridView.Columns[i].HeaderText);
                if (i < dataGridView.Columns.Count - 1)
                    csvContent.Append(",");
            }
            csvContent.AppendLine();

            // Añadir filas
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    csvContent.Append(dataGridView.Rows[i].Cells[j].Value?.ToString().Replace(",", " "));
                    if (j < dataGridView.Columns.Count - 1)
                        csvContent.Append(",");
                }
                csvContent.AppendLine();
            }

            // Guardar el archivo CSV
            File.WriteAllText(filePath, csvContent.ToString(), Encoding.UTF8);
        }


        // Método público para exportar DataGridView a .csv
        public static void ExportDataGridViewToCSV(DataGridView dgv, string filePath)
        {
            if (dgv == null || string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("Parametros invalidos.");
            }

            ExportToCSV(dgv, filePath);
        }

        #endregion



        #region Exportar a Xlsx

        // Método privado para realizar la exportación a .xlsx
        private static void ExportToXlsx(DataGridView dataGridView, string filePath)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                SheetData sheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet(sheetData);

                // Añadir encabezados
                Row headerRow = new Row();
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    if (!string.IsNullOrEmpty(column.HeaderText))
                    {
                        Cell cell = new Cell
                        {
                            DataType = CellValues.String,
                            CellValue = new CellValue(column.HeaderText)
                        };
                        headerRow.AppendChild(cell);
                    }
                }
                sheetData.AppendChild(headerRow);

                // Añadir filas
                foreach (DataGridViewRow dgvRow in dataGridView.Rows)
                {
                    if (dgvRow.IsNewRow) continue; // Ignorar la fila de nuevo registro

                    Row newRow = new Row();
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        DataGridViewCell cell = dgvRow.Cells[j];

                        // Solo procesar celdas que no pertenecen a una columna sin encabezado
                        if (!string.IsNullOrEmpty(dataGridView.Columns[j].HeaderText))
                        {
                            // Verificar si la celda contiene un ícono y omitirla
                            if (cell.Value is System.Drawing.Icon || cell.Value is System.Drawing.Image)
                            {
                                continue;
                            }

                            Cell newCell = new Cell
                            {
                                DataType = CellValues.String,
                                CellValue = new CellValue(cell.Value?.ToString())
                            };
                            newRow.AppendChild(newCell);
                        }
                    }

                    // Agregar la fila al archivo Excel solo si tiene datos
                    if (newRow.ChildElements.Count > 0)
                    {
                        sheetData.AppendChild(newRow);
                    }
                }

                Sheets sheets = document.WorkbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet()
                {
                    Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Sheet1"
                };
                sheets.Append(sheet);

                workbookPart.Workbook.Save();
            }
        }

        // Método público para exportar DataGridView a .xlsx
        public static void ExportDataGridViewToXlsx(DataGridView dataGridView, string filePath)
        {
            if (dataGridView == null || string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("Parámetros inválidos.");
            }

            ExportToXlsx(dataGridView, filePath);
        }

        #endregion



        public static DataTable ReadExcelFile(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                    });
                    return result.Tables[0];
                }
            }
        }

    }
}
