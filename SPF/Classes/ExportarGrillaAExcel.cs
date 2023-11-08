using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

namespace SPF.Classes
{
    public static class ExportarGrillaAExcel
    {
        public static string ExportarExcel(DataGridView grid, List<string> columnsToExclude = null)
        {
            ExcelPackage p = new ExcelPackage();
            p.Workbook.Worksheets.Add("DatosGrilla");
            ExcelWorksheet ws = p.Workbook.Worksheets[1];
            ws.Name = "DatosGrilla"; //Setting Sheet's name
            ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
            ws.Cells.Style.Font.Name = "Calibri";

            List<DataGridViewColumn> colList = GetColumnsToExport(grid, columnsToExclude).OrderBy(a => a.DisplayIndex).ToList();
            
            CrearCabeceraExcel(ws, colList);
            CargarDatosExcel(ws, colList, grid);

            Byte[] bin = p.GetAsByteArray();
            string path = VWGContext.Current.Server.MapPath(@"\Resources\UserData\" + VWGContext.Current.Session["WindowsUser"].ToString() + @"\");
            Berke.Libs.Base.Helpers.Files.CreateDirectory(@path);
            string fileName = @path + "Grilla-" + DateTime.Now.Ticks.ToString() + ".xlsx";
            Berke.Libs.Base.Helpers.Files.SaveBytesToFile(bin, @fileName);

            ws.Dispose();
            p.Dispose();

            GC.Collect();
            return @fileName;
        }

        public static string ExportarExcel(DataGridView grid, List<DataGridViewColumn> colList)
        {
            ExcelPackage p = new ExcelPackage();
            p.Workbook.Worksheets.Add("DatosGrilla");
            ExcelWorksheet ws = p.Workbook.Worksheets[1];
            ws.Name = "DatosGrilla"; //Setting Sheet's name
            ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
            ws.Cells.Style.Font.Name = "Calibri";

            //List<DataGridViewColumn> colList = GetColumnsToExport(grid, columnsToExclude).OrderBy(a => a.DisplayIndex).ToList();
            
            CrearCabeceraExcel(ws, colList);
            CargarDatosExcel(ws, colList, grid);

            Byte[] bin = p.GetAsByteArray();
            string path = VWGContext.Current.Server.MapPath(@"\Resources\UserData\" + VWGContext.Current.Session["WindowsUser"].ToString() + @"\");
            Berke.Libs.Base.Helpers.Files.CreateDirectory(@path);
            string fileName = @path + "Grilla-" + DateTime.Now.Ticks.ToString() + ".xlsx";
            Berke.Libs.Base.Helpers.Files.SaveBytesToFile(bin, @fileName);

            ws.Dispose();
            p.Dispose();

            GC.Collect();
            return @fileName;
        }

        private static List<DataGridViewColumn> GetColumnsToExport(DataGridView grid, List<string> columnsToExclude)
        {
            List<DataGridViewColumn> Result = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn col in grid.Columns)
            {
                if ((col.Visible) && (((columnsToExclude == null) || (!columnsToExclude.Contains(col.Name)))))
                {
                    if (col.GetType() != typeof(DataGridViewCheckBoxColumn))
                    {
                        //if ((columnsToExclude != null) || (!columnsToExclude.Contains(col.Name)))
                            Result.Add(col);
                    }
                    else
                    {
                        //if ((columnsToExclude != null) || (!columnsToExclude.Contains(col.Name)))
                        //{
                            DataGridViewTextBoxColumn txtCol = new DataGridViewTextBoxColumn();
                            txtCol.DataPropertyName = col.DataPropertyName;
                            txtCol.Name = col.Name;
                            txtCol.DisplayIndex = col.DisplayIndex;
                            txtCol.HeaderText = col.HeaderText;
                            txtCol.ValueType = col.ValueType;
                            Result.Add(txtCol);
                        //}
                    }
                }
            }
            return Result;
        }


        private static void CrearCabeceraExcel(ExcelWorksheet ws, List<DataGridViewColumn> vcl)
        {
            int colIndex = 0;
            foreach (DataGridViewColumn col in vcl)
            {
                colIndex++;
                var cell = ws.Cells[1, colIndex];

                //Setting the background color of header cells to Gray
                var fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                //Setting Top/left,right/bottom borders.
                var border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                //Setting Value in cell
                cell.Value = col.HeaderText;
            }

        }

        private static void CargarDatosExcel(ExcelWorksheet ws, List<DataGridViewColumn> vcl, DataGridView grid)
        {
            int colIndex = 0;
            //for (int i = 0; i <= this.dgvExportarExcel.RowCount - 1; i++)
            for (int i = 0; i < grid.RowCount; i++)
            {
                colIndex = 0;
                foreach (DataGridViewColumn col in vcl)
                {
                    colIndex++;
                    var cell = ws.Cells[i + 2, colIndex];
                    var border = cell.Style.Border;
                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                    if (col.ValueType.FullName.IndexOf(typeof(DateTime).FullName) > -1)
                    {
                        cell.Style.Numberformat.Format = "dd/mm/yyyy";
                        cell.Value = grid.Rows[i].Cells[col.Name].Value != null ?
                                grid.Rows[i].Cells[col.Name].Value :
                                null;
                    }
                    else if (col.ValueType.FullName.IndexOf(typeof(decimal).FullName) > -1)
                    {
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        cell.Style.Numberformat.Format = "#,##0.00";
                        cell.Value = grid.Rows[i].Cells[col.Name].Value != null ?
                            grid.Rows[i].Cells[col.Name].Value :
                            null;
                    }
                    else if (col.ValueType.FullName.IndexOf(typeof(Boolean).FullName) > -1)
                    {
                        if (grid.Rows[i].Cells[col.Name].Value != null)
                        {
                            string valStr = grid.Rows[i].Cells[col.Name].Value.ToString();
                            bool valBool = false;
                            if ((valStr == "1") || (valStr.ToUpper() == "TRUE"))
                                valBool = true;

                            cell.Value = valBool ? "Si" : "No";
                        }
                        else
                            cell.Value = "No";
                    }
                    else if (col.ValueType.FullName.IndexOf(typeof(int).FullName) > -1)
                    {
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        cell.Style.Numberformat.Format = "0";
                        cell.Value = grid.Rows[i].Cells[col.Name].Value != null ?
                            grid.Rows[i].Cells[col.Name].Value :
                            null;
                    }
                    else
                        cell.Value = grid.Rows[i].Cells[col.Name].Value != null ?
                            grid.Rows[i].Cells[col.Name].Value :
                            null;

                }
            }

            for (int j = 1; j <= colIndex; j++)
            {
                ws.Column(j).AutoFit();
            }
        }

    }
}