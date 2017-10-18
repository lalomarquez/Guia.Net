using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Drawing;
using System.IO;
using C.BO;
using System.Data;
using System.Collections;

namespace C.Helpers
{
    public class HelperExcel
    {
        public bool GenerarExcel(DataTable dt, ArchivoExcel bo)
        {
            bool result = false;
            try
            {
                if (!string.IsNullOrEmpty(bo.ToString()))
                {
                    Print.WriteSalida(bo.ToString());
                    var newFile = new FileInfo(bo.ToString());
                    using (var package = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(bo.encabezadoArchivo);
                        //Add the headers                                                
                        worksheet.Cells[2, 2].Value = bo.encabezadoArchivo;
                        worksheet.Cells[2, 2].Style.Font.Size = 16;
                        worksheet.Cells[3, 2].Value = "Fecha de Creación: " + DateTime.Now;
                        worksheet.Cells[4, 2].Value = "Total de Registros: " + dt.Rows.Count;
                        worksheet.Cells["B2:B4"].Style.Font.Bold = true;
                        //Add columns name
                        if (ImprimirNombreColumnas(worksheet, dt, bo.inicioColumna, bo.inicioFila))
                        {                            
                            ImprimirRegistros(worksheet, dt, bo.inicioColumna, bo.inicioFila + 1);
                            package.Save();
                            result = true;
                        }
                        else
                        Console.WriteLine("Ha sucediso algo extraño :S");
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
            }
            return result;
        }

        public bool ImprimirNombreColumnas(ExcelWorksheet worksheet, DataTable dt, int inicioColumna, int inicioFila)
        {
            bool result = false;
            Color backgroundColor = ColorTranslator.FromHtml("#7dc3d5");
            Color fontColor = ColorTranslator.FromHtml("#000000");
            try
            {
                for (int columna = 0; columna <= dt.Columns.Count - 1; columna++)
                {
                    worksheet.Cells[inicioFila, columna + inicioColumna].Value = dt.Columns[columna].ColumnName.ToString();
                    worksheet.Cells[inicioFila, columna + inicioColumna].Style.Font.Bold = true;
                    worksheet.Cells[inicioFila, columna + inicioColumna].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[inicioFila, columna + inicioColumna].AutoFitColumns();                    
                    worksheet.Cells[inicioFila, columna + inicioColumna].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[inicioFila, columna + inicioColumna].Style.Fill.BackgroundColor.SetColor(backgroundColor);
                    worksheet.Cells[inicioFila, columna + inicioColumna].Style.Font.Color.SetColor(fontColor);                   
                    //Print.WriteSalida(dt.Columns[columna].ColumnName.ToString());
                }
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw;
            }
            return result;
        }

        public bool ImprimirRegistros(ExcelWorksheet worksheet, DataTable dt, int inicioColumna, int inicioFila)
        {
            bool result = false;            
            try
            {
                for (int xFila = 0; xFila <= dt.Rows.Count - 1; xFila++)
                {
                    for (int yColumna = 0; yColumna <= dt.Columns.Count - 1; yColumna++)
                    {                        
                        object datos = dt.Rows[xFila].ItemArray[yColumna];                                                
                        FormatearDatos(datos, worksheet, xFila, yColumna, inicioColumna, inicioFila);
                    }
                }
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw;
            }
            return result;
        }
        
        public bool FormatearDatos(object datos, ExcelWorksheet worksheet, int xFila, int yColumna, int inicioColumna, int inicioFila)
        {
            bool result = false;
            try
            {
                if (datos.GetType() == typeof(DateTime))
                {                                        
                    worksheet.Cells[xFila + inicioFila, yColumna + inicioColumna].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";
                }
                worksheet.Cells[xFila + inicioFila, yColumna + inicioColumna].Value = datos;
                worksheet.Cells[xFila + inicioFila, yColumna + inicioColumna].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                worksheet.Cells[xFila + inicioFila, yColumna + inicioColumna].AutoFitColumns();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
            }
            return result;
        }
    }
}
