using System;
using C.BO;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace C.BLL.Demos
{
    public class MetodosGenericos
    {

        public string SerializarGenerico<T>(T bo)
        {
            string result = string.Empty;
            try
            {
                var obj = new XmlSerializer(typeof(T));
                using (var sw = new StringWriter())
                {
                    using (var escribir = XmlWriter.Create(sw))
                    {
                        obj.Serialize(escribir, bo);
                        return sw.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
                return ex.ToString();
            }
        }

        public string Serializar(CatEdos edos)
        {
            string result = string.Empty;
            try
            {
                var obj = new XmlSerializer(typeof(CatEdos), new XmlRootAttribute("Estados"));                
                using (var sw = new StringWriter())
                {
                    using (var escribir = XmlWriter.Create(sw))
                    {
                        obj.Serialize(escribir,edos);
                        return sw.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
                return ex.ToString();                
            }            
        }

        public string Serializar(CatFarmacias farm)
        {
            string result = string.Empty;
            try
            {
                var obj = new XmlSerializer(typeof(CatFarmacias), new XmlRootAttribute("Farmacias"));
                using (var sw = new StringWriter())
                {
                    using (var escribir = XmlWriter.Create(sw))
                    {
                        obj.Serialize(escribir, farm);
                        return sw.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
                return ex.ToString();
            }
        }
    }
}
