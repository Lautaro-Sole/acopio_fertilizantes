using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public partial class Transporte
    {
        public override string ToString()
        {
            return _tipo_matricula + ": " + _nro_matricula.ToString();
        }
    }
}
