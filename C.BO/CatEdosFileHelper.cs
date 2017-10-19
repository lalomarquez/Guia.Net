using FileHelpers;

namespace C.BO
{
    [IgnoreFirst(1)]
    [DelimitedRecord(",")]
    public class CatEdosFileHelper
    {
        public string ID_Estado { get; set; }
        public string ID_Municipio { get; set; }
        public string NombreEstado { get; set; }
        public string NombreMunicipio { get; set; }
    }
}
