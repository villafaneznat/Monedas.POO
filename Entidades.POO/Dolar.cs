using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.POO
{
    public class Dolar
    {
        
        //a.Ambas clases tienen 2 atributos uno estático cotizacionRespectoDolar y otro cantidad.

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


        //b.Deberá tener un método que informe la cotización con respecto al dólar y otro para informar la cantidad.
        public static double GetCotizacion()
        {
            return cotizacionRespectoDolar;
        }
        public double GetCantidad()
        {
            return cantidad;
        }

        //c.Los constructores estáticos les darán a las clases una cotización por defecto respecto del dólar.
        static Dolar()
        {
            cotizacionRespectoDolar = 102.65;
        }

        //d. Deberá tener un constructor con la cantidad de cada moneda y otro que proporcione la cantidad y la cotización con respecto al dólar.
        public Dolar(double cant)
        {
            this.cantidad = cant;
        }
        public Dolar(double cant, double cotizacion):this(cant)
        {
            cotizacionRespectoDolar = cotizacion;
        }

        //e. Hacer la sobrecarga implícita entre double y las monedas.
        public static implicit operator double(Dolar dolar)
        {
            return dolar.cantidad;
        }

        //*f. Hacer la sobrecarga explícita entre las monedas.
        public static explicit operator Dolar(Peso p)
        {
            double cantidadEnDolares = p.Cantidad / Peso.CotizacionRespectoDolar;
            return new Dolar(cantidadEnDolares);
        }
        public static explicit operator Dolar(Euro e)
        {
            double cantidadEnDolares = e.Cantidad * Euro.CotizacionRespectoDolar;
            return new Dolar(cantidadEnDolares);
        }

        /* ----SI SOBRECARGO EL OPERADOR EXPLICIT CON Peso(Dolar) VOY A TENER UN ERROR DE AMBIGUEDAD, 
             PORQUE EN LA CLASE Peso YA EXISTE ESTE MÉTODO 
            (lo pide el item .g. sólo sobrecargo el operador implicit) ----*/

        //public static explicit operator Peso(Dolar d)
        //{
        //   double cantidadPesos = d.cantidad * Peso.CotizacionRespectoDolar;
        //   return new Peso(cantidadPesos);
        //}

        //g. Sobrecargar los operadores explicit y/o implicit para lograr compatibilidad entre los distintos tipos de datos.

        public static implicit operator Dolar(double d)
        {
            return new Dolar(d); 
        }

        //h. Sobrecargar los operadores de igualdad en las monedas. Los operadores de comparación == compararán cantidades.
        //i. Comparar Dólar con Dólar
        public static bool operator ==(Dolar dolar1, Dolar dolar2)
        {
            return dolar1.cantidad == dolar2.cantidad;
        }
        public static bool operator !=(Dolar dolar1, Dolar dolar2)
        {
            return !(dolar1 == dolar2);
        }

        //ii. Comparar Dólar con Peso.
        public static bool operator ==(Dolar dolar, Peso peso)
        {
            return dolar.cantidad == peso.Cantidad;
        }
        public static bool operator !=(Dolar dolar, Peso peso)
        {
            return !(dolar == peso);
        }
        //ii. Comparar Dólar con Euro.
        public static bool operator ==(Dolar dolar, Euro euro)
        {
            return dolar.cantidad == euro.Cantidad;
        }
        public static bool operator !=(Dolar dolar, Euro euro)
        {
            return !(dolar == euro);
        }

        //i. Se debe lograr que los objetos de estas clases se puedan sumar, restar y comparar entre sí con total normalidad como si fueran tipos numéricos, teniendo presente que 1 Dólar equivale a 102,65 Pesos.
        public static Dolar operator +(Dolar d1, Dolar d2)
        {
            double suma = d1.cantidad + d2.cantidad;
            return new Dolar(suma);
        }

        public static Dolar operator -(Dolar d1, Dolar d2)
        {
            double resta = d1.cantidad - d2.cantidad;
            return new Dolar(resta);
        }

        public static Dolar operator *(Dolar d1, Dolar d2)
        {
            double producto = d1.cantidad * d2.cantidad;
            return new Dolar(producto);
        }

        public static Dolar operator /(Dolar d1, Dolar d2)
        {
            double division = d1.cantidad / d2.cantidad;
            return new Dolar(division);
        }

        public static bool operator <(Dolar d1, Dolar d2)
        {
            return d1.cantidad < d2.cantidad;
        }

        public static bool operator >(Dolar d1, Dolar d2)
        {
            return d1.cantidad > d2.cantidad;
        }

        public static bool operator <=(Dolar d1, Dolar d2)
        {
            return d1.cantidad <= d2.cantidad;
        }

        public static bool operator >=(Dolar d1, Dolar d2)
        {
            return d1.cantidad >= d2.cantidad;
        }

    }
}
