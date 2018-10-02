using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Distribuidora
{
    public class TxtHandler
    {
        public bool TxtProductos(List<Importado> importados, List<Fabricado> fabricados)
        {
            bool result = false;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\Productos.txt"))
            {
                if ((importados == null || importados.Count() == 0) && (fabricados == null || fabricados.Count() == 0))
                {
                    file.WriteLine("*");
                }
                else
                {
                    file.WriteLine($"## PRODUCTOS IMPORTADOS ##");
                    if (importados == null || importados.Count() == 0)
                    {
                        file.WriteLine($"No hay productos Importados.");
                    }
                    else
                    {
                        int i = 0;
                        foreach (Importado imp in importados)
                        {
                            i += 1;
                            file.WriteLine();
                            file.WriteLine($"{i} - Código identificador: {imp.Id} | Nombre: {imp.Nombre} | Descripcion: {imp.Desc} | Costo: {imp.Costo} | Precio Sugerido: {imp.PrecioSugerido} | Origen: {imp.Origen} | Cantidad minima de importacion: {imp.CantImportacion}");
                            file.WriteLine($"## Fin del producto ##");
                            file.WriteLine();
                        }                        
                    }
                    file.WriteLine($"## PRODUCTOS FABRICADOS ##");
                    if (fabricados == null || fabricados.Count() == 0)
                    {
                        file.WriteLine($"No hay productos Fabricados.");
                    }
                    else
                    {
                        int i = 0;
                        foreach (Fabricado fab in fabricados)
                        {
                            i += 1;
                            file.WriteLine();
                            //TODO: CONFIRMAR SI HAY QUE AGREGAR LOS TECNICOS DE CADA PRODUCTO FABRICADO TAMBIEN.
                            file.WriteLine($"{i} - Código identificador: {fab.Id} | Nombre: {fab.Nombre} | Descripcion: {fab.Desc} | Costo: {fab.Costo} | Precio Sugerido: {fab.PrecioSugerido} | Tiempo previsto de fabricación: {fab.TiempoFab}");
                            file.WriteLine($"## Fin del producto ##");
                            file.WriteLine();
                        }
                    }
                    result = true;
                }
            }
            return result;
        }
    }
}