using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public partial class Chofer
    {
        public override string ToString()
        {
            return _apellido + ", " + _nombre + " (" + _tipo_documento + ": " + _num_documento + ")";
        }
    }
}
