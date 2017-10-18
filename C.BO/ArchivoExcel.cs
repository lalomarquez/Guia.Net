using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C.BO
{
    public class ArchivoExcel
    {
        public string extencion { get; set; }
        public string nombreArchivo { get; set; }
        public string path { get; set; }        
        public string encabezadoArchivo { get; set; }
        public int inicioColumna { get; set; }
        public int inicioFila { get; set; }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}", path, nombreArchivo,extencion);
        }
    }
}
