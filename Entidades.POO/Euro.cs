using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.POO
{
    public class Euro
    {
        private static double cotizacionRespectoDolar;
        private double cantidad;
        public double Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public static double CotizacionRespectoDolar
        {
            get { return cotizacionRespectoDolar; }
            set { cotizacionRespectoDolar = value; }
        }

        public static double GetCotizacion()
        {
            return cotizacionRespectoDolar;
        }

        static Euro()
        {
            cotizacionRespectoDolar = 1.17;
        }
        public Euro(double cant)
        {
            this.cantidad = cant;
        }
        public Euro(double cant, double cotizacion) : this(cant)
        {
            cotizacionRespectoDolar = cotizacion;
        }

        public static implicit operator double(Euro euro)
        {
            return euro.cantidad;
        }
        public static implicit operator Euro(double cant)
        {
            return new Euro(cant);
        }
        public static explicit operator Euro(Dolar d)
        {
            double cantidadEnEuros = d.Cantidad / CotizacionRespectoDolar;
            return new Euro(cantidadEnEuros);
        }
        public static explicit operator Euro(Peso p)
        {
            Dolar dolar = (Dolar)p;
            Euro cantidadEnEuros = (Euro)dolar;
            return new Euro(cantidadEnEuros);           
        }

        public static bool operator ==(Euro euro1, Euro euro2)
        {
            return euro1.cantidad == euro2.cantidad;
        }
        public static bool operator !=(Euro euro1, Euro euro2)
        {
            return !(euro1 == euro2);
        }
        
        public static bool operator ==(Euro euro, Peso peso)
        {
            return euro.cantidad == peso.Cantidad;
        }
        public static bool operator !=(Euro euro, Peso peso)
        {
            return !(euro == peso);
        }

        /*----LA COMPARACION Euro-Dolar YA ESTÁ EN LA CLASE Dolar----*/

        //public static bool operator ==(Euro euro, Dolar dolar)
        //{
        //    return euro.cantidad == dolar.Cantidad;
        //}
        //public static bool operator !=(Euro euro, Dolar dolar)
        //{
        //    return !(euro == dolar);
        //}

        public static Euro operator +(Euro e1, Euro e2)
        {
            double suma = e1.cantidad + e2.cantidad;
            return new Euro(suma);
        }

        public static Euro operator -(Euro e1, Euro e2)
        {
            double resta = e1.cantidad - e2.cantidad;
            return new Euro(resta);
        }

        public static Euro operator *(Euro e1, Euro e2)
        {
            double producto = e1.cantidad * e2.cantidad;
            return new Euro(producto);
        }

        public static Euro operator /(Euro e1, Euro e2)
        {
            double division = e1.cantidad / e2.cantidad;
            return new Euro(division);
        }

        public static bool operator <(Euro e1, Euro e2)
        {
            return e1.cantidad < e2.cantidad;
        }

        public static bool operator >(Euro e1, Euro e2)
        {
            return e1.cantidad > e2.cantidad;
        }

        public static bool operator <=(Euro e1, Euro e2)
        {
            return e1.cantidad <= e2.cantidad;
        }

        public static bool operator >=(Euro e1, Euro e2)
        {
            return e1.cantidad >= e2.cantidad;
        }












    }
}
