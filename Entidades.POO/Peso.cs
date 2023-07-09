using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.POO
{
    public class Peso
    {
        static double cotizacionRespectoDolar;
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
        public double GetCantidad()
        {
            return cantidad;
        }
        static Peso()
        {
            cotizacionRespectoDolar = 102.65;
        }
        public Peso(double cant, double cotizacion)
        {
            this.cantidad = cant;
            cotizacionRespectoDolar = cotizacion;
        }
        public Peso(double cant)
        {
            this.cantidad = cant;
        }

        public static implicit operator double(Peso peso)
        {
            return peso.cantidad;
        }

        public static implicit operator Peso(double d)
        {
            return new Peso(d);

        }
        
        /*---- SI SOBRECARGO EL OPERADOR EXPLICIT CON Dolar(Peso) VOY A TENER UN ERROR DE AMBIGUEDAD, 
            PORQUE EN LA CLASE Dolar YA EXISTE ESTE MÉTODO 
            (lo pide el item .g. sólo sobrecargo el operador implicit) ----*/

        //public static explicit operator Dolar(Peso p)
        //{
        //    double cantidadDolares = p.cantidad / Dolar.CotizacionRespectoDolar;
        //    return new Dolar(cantidadDolares);
        //}

        public static explicit operator Peso(Dolar d)
        {
            double cantidadEnPesos = d.Cantidad * CotizacionRespectoDolar;
            return new Peso(cantidadEnPesos);
        }
        public static explicit operator Peso(Euro e)
        {
            Dolar dolar = (Dolar)e;
            Euro cantidadEnPesos = (Euro)dolar;
            return new Peso(cantidadEnPesos);
        }
        public static bool operator ==(Peso peso1, Peso peso2)
        {
            return peso1.cantidad == peso2.cantidad;
        }
        public static bool operator !=(Peso peso1, Peso peso2)
        {
            return !(peso1 == peso2);
        }
        /*----LA COMPARACION Peso-Dolar YA ESTÁ EN LA CLASE Dolar----*/
        //public static bool operator ==(Peso peso, Dolar dolar)
        //{
        //    return peso.cantidad == dolar.Cantidad;
        //}

        //public static bool operator !=(Peso peso, Dolar dolar)
        //{
        //    return !(peso == dolar);
        //}

        /*----LA COMPARACION Peso-Euro YA ESTÁ EN LA CLASE Euro----*/
        //public static bool operator ==(Peso peso, Euro euro)
        //{
        //    return peso.cantidad == euro.Cantidad;
        //}
        //public static bool operator !=(Peso peso, Euro euro)
        //{
        //    return !(peso == euro);
        //}

        public static Peso operator +(Peso p1, Peso p2)
        {
            double suma = p1.cantidad + p2.cantidad;
            return new Peso(suma);
        }
        public static Peso operator -(Peso p1, Peso p2)
        {
            double resta = p1.cantidad - p2.cantidad;
            return new Peso(resta);
        }
        public static Peso operator *(Peso p1, Peso p2)
        {
            double producto = p1.cantidad * p2.cantidad;
            return new Peso(producto);
        }

        public static Peso operator /(Peso p1, Peso p2)
        {
            double division = p1.cantidad / p2.cantidad;
            return new Peso(division);
        }
        public static bool operator <(Peso p1, Peso p2)
        {
            return p1.cantidad < p2.cantidad;
        }

        public static bool operator >(Peso p1, Peso p2)
        {
            return p1.cantidad > p2.cantidad;
        }

        public static bool operator <=(Peso p1, Peso p2)
        {
            return p1.cantidad <= p2.cantidad;
        }

        public static bool operator >=(Peso p1, Peso p2)
        {
            return p1.cantidad >= p2.cantidad;
        }



    }
}
