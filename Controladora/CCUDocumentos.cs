using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class CCUDocumentos
    {
        public List<Modelo_Entidades.Documento> ObtenerDocumentos()
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatDocumentos.ToList<Modelo_Entidades.Documento>();
        }

        public bool Agregar(Modelo_Entidades.Documento oDocumento)
        {

            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatDocumentos.AddObject(oDocumento);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;


        }
        public bool Eliminar(Modelo_Entidades.Documento oDocumento)
        {
            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatDocumentos.DeleteObject(oDocumento);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }
        public bool Modificar(Modelo_Entidades.Documento oDocumento)
        {
            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatDocumentos.ApplyCurrentValues(oDocumento);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }
    }
}
