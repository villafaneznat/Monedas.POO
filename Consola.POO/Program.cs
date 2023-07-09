using Entidades.POO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola.POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Monedas";

            //Construyo los objetos

            Peso peso1 = new Peso(5000);
            Peso peso2 = new Peso(10000);

            Dolar dolar1 = new Dolar(500);
            Dolar dolar2 = new Dolar(200);

            Euro euro = new Euro(200);
            Euro euro1 = new Euro(300);

            //Muestro las cantidades
            Console.WriteLine($"Cantidad de pesos1: {peso1.GetCantidad()}");
            Console.WriteLine($"Cantidad de pesos2: {peso2.Cantidad}");
            Console.WriteLine($"Cantidad de dolares1: {dolar1.GetCantidad()}");
            Console.WriteLine($"Cantidad de dolares2: {dolar2.GetCantidad()}");
            Console.WriteLine($"Cantidad de euros: {euro.Cantidad}");
            Console.WriteLine($"Cantidad de euros1: {euro1.Cantidad}");


            //Muestro las cotizaciones
            Console.WriteLine($"Cotizacion respecto dolar: {Peso.GetCotizacion()}");
            Console.WriteLine($"Cotizacion respecto dolar: {Dolar.GetCotizacion()}");
            Console.WriteLine($"Cotizacion respecto dolar: {Euro.GetCotizacion()}");


            /*-----------------------------------------------------------------------------------------*/
            Console.WriteLine("--------------------------------------------");
            //SOBRECARGA IMPLICITA

            /* Asigno a una variable double, un obj de tipo Peso, tecnicamente esto no podria hacerse,
            por eso creamos una conversion implicita dentro de la clase. */
            double cant = peso1;  
            Console.WriteLine(cant);

            /* De la misma manera sucede al revez, le asigno un double a un obj de tipo peso,
            creando, en la conversion implicita, una instancia de la clase, tomando el double como valor del atributo 'cantidad'. */
            Peso peso3 = cant;     
            Console.WriteLine(peso3.GetCantidad());

            /*Cambio el valor de la cantidad de peso3, para mostrar que es otra instancia,
            ya que contenia como cantidad, la cantidad de peso1, pero no la referencia del objeto,
            es pero eso que no afectamos la mutabilidad de peso1 al cambiar el valor de peso3. */

            peso3.Cantidad = 7000; 
            Console.WriteLine(peso3.GetCantidad());
            Console.WriteLine("-------");
            Console.WriteLine(peso1.GetCantidad());

            //Puerbo con Euro
            double cant1 = euro1;
            Console.WriteLine(cant);

            Euro euro4 = cant1;
            Console.WriteLine(euro4.Cantidad);

            /*-----------------------------------------------------------------------------------------*/
            Console.WriteLine("--------------------------------------------");

            //SOBRECARGA EXPLICITA

            /* A el obj de tipo Dolar (dolar1) lo convertimos/casteamos en un obj de tipo Peso, 
             obteniendo como resultado la instancia de un obj Peso que en su atributo 'cantidad' tendrá el resultado
            de la conversion de la cantidad de Dolares (de dolar1) a Pesos.*/
            Peso peso4 = (Peso)dolar1; 

            /* Lo mismo sucede al revéz, convierto un obj de tipo Peso (peso4) en un obj de tipo Dolar
             creando una instancia de la clase Dolar (dolar3) y asignandole el valor de la conversion al atributo 'cantidad'. */
            Dolar dolar3 = (Dolar)peso4;

            // Mostramos...
            /* Teniendo en cuenta que la cotizacion por dolar es de 102.65 y que la cantidad de dolar1 es 500,
               la cant de peso4 seria de 51365.
               Y como la cantidad de peso4 es de 51365, la cantidad de dolar3 seria de 500. */
            Console.WriteLine($"peso : {peso4.Cantidad} dolar: {dolar3.Cantidad}");

            //Pruebo de pesos a euros
            Euro euro2 = (Euro)peso1;
            Console.WriteLine($"peso: {peso1.Cantidad} euro: {euro2.Cantidad}");

            //Pruebo de dolar a euros:
            Euro euro3 = (Euro)dolar1;
            Console.WriteLine($"dolar: {dolar1.Cantidad} euro: {euro3.Cantidad}");

            Console.WriteLine("--------------------------------------------");

            //Operaciones Dolar
            var dolarEnCero = new Dolar(0); //Para validar la division

            var suma = dolar1 + dolar2;
            var resta = dolar1 - dolar2;
            var multiplicacion = dolar1 * dolar2;
            var division = dolar2 != dolarEnCero ? dolar1 / dolar2 : dolarEnCero;

            Console.Write($"Suma entre dolar1 y dolar2: {suma.Cantidad}\n" +
                $"Resta entre dolar1 y dolar2: {resta.Cantidad}\n" +
                $"Multiplicacion entre dolar1 y dolar2: {multiplicacion.Cantidad}\n");
            if (division.Cantidad == 0) 
            {
                Console.WriteLine("La cantidad de dolar2 es cero, no puede divirse por cero.");
            }
            else
            {
                Console.WriteLine($"Division entre dolar1 y dolar2: {division.Cantidad}");
            }

            Console.WriteLine("--------------------------------------------");

            //Operaciones Peso
            var pesoEnCero = new Peso(0); //Para validar la division

            var sumaPeso = peso1 + peso2;
            var restaPeso = peso1 - peso2;
            var multiplicacionPeso = peso1 * peso2;
            var divisionPeso = peso2 == pesoEnCero ? pesoEnCero : peso1 / peso2;

            Console.Write($"Suma entre peso1 y peso2: {sumaPeso.Cantidad}\n" +
                $"Resta entre peso1 y peso2: {restaPeso.Cantidad}\n" +
                $"Multiplicacion entre peso1 y peso2: {multiplicacionPeso.Cantidad}\n");
            if (divisionPeso.Cantidad == 0)
            {
                Console.WriteLine("La cantidad de peso2 es cero, no puede divirse por cero.");
            }
            else
            {
                Console.WriteLine($"Division entre peso1 y peso2: {divisionPeso.Cantidad}");
            }
            
            Console.WriteLine("--------------------------------------------");

            //Operaciones Euro

            var euroEnCero = new Euro(0); //Para validar la division

            var sumaEuro = euro1 + euro2;
            var restaEuro = euro1 - euro2;
            var multiplicacionEuro = euro1 * euro2;
            var divisionEuro = euro2 == euroEnCero ? euroEnCero : euro1 / euro2;

            Console.Write($"Suma entre euro1 y euro2: {sumaEuro.Cantidad}\n" +
                $"Resta entre euro1 y euro2: {restaEuro.Cantidad}\n" +
                $"Multiplicacion entre euro1 y euro2: {multiplicacionEuro.Cantidad}\n");
            if (divisionEuro.Cantidad == 0)
            {
                Console.WriteLine("La cantidad de euro2 es cero, no puede divirse por cero.");
            }
            else
            {
                Console.WriteLine($"Division entre euro1 y euro2: {divisionEuro.Cantidad}");
            }

            Console.WriteLine("--------------------------------------------");


            // Comparo Dolar con Dolar.

            var mayor = dolar1 > dolar2 ? "dolar1 es mayor que dolar2" : "dolar2 es mayor que dolar1";
            var menor = dolar1 < dolar2 ? "dolar1 es menor que dolar2" : "dolar2 es menor que dolar1";
            var mayorIgual = dolar1 <= dolar2 ? "dolar1 es mayor o igual que dolar2" : "dolar2 es mayor o igual que dolar1";
            var menorIgual = dolar1 <= dolar2 ? "dolar1 es menor o igual que dolar2" : "dolar2 es menor o igual que dolar1";
            Console.WriteLine($"{mayor}\n" +
                $"{menor}\n" +
                $"{mayorIgual}\n" +
                $"{menorIgual}\n");
            
            if (dolar1 == dolar3)
            {
                Console.WriteLine("La cantidad de dólares es igual");
            }
            else
            {
                Console.WriteLine("La cantidad de dólares no es igual");
            }

            Console.WriteLine("--------------------------------------------");

            //Comparo Peso con Peso

            var mayorPeso = peso1 > peso2 ? "peso1 es mayor que peso2" : "peso2 es mayor que peso1";
            var menorPeso = peso1 < peso2 ? "peso1 es menor que peso2" : "peso2 es menor que peso1";
            var mayorIgualPeso = peso1 <= peso2 ? "peso1 es mayor o igual que peso2" : "dolar2 es mayor o igual que peso1";
            var menorIgualPeso = peso1 <= peso2 ? "peso1 es menor o igual que peso2" : "dolar2 es menor o igual que peso1";
            Console.WriteLine($"{mayorPeso}\n" +
                $"{menorPeso}\n" +
                $"{mayorIgualPeso}\n" +
                $"{menorIgualPeso}\n");

            if (peso1 == peso3)
            {
                Console.WriteLine("La cantidad de pesos es igual");
            }
            else
            {
                Console.WriteLine("La cantidad de pesos no es igual");
            }

            Console.WriteLine("--------------------------------------------");

            //Comparo Euro con Euro

            var mayorEuro = euro1 > euro2 ? "euro1 es mayor que euro2" : "euro2 es mayor que euro1";
            var menorEuro = euro1 < euro2 ? "euro1 es menor que euro2" : "euro2 es menor que euro1";
            var mayorIgualEuro = euro1 <= euro2 ? "euro1 es mayor o igual que euro2" : "euro2 es mayor o igual que euro1";
            var menorIgualEuro = euro1 <= euro2 ? "euro1 es menor o igual que euro2" : "euro2 es menor o igual que euro1";
            Console.WriteLine($"{mayorEuro}\n" +
                $"{menorEuro}\n" +
                $"{mayorIgualEuro}\n" +
                $"{menorIgualEuro}\n");

            if (euro1 == euro3)
            {
                Console.WriteLine("La cantidad de euros es igual");
            }
            else
            {
                Console.WriteLine("La cantidad de euros no es igual");
            }

            Console.WriteLine("--------------------------------------------");

            //Comparo Dolar con Peso

            if (dolar1 == peso1)
            {
                Console.WriteLine("La cantidad de dólares es igual a la cantidad de pesos.");
            }
            else
            {
                Console.WriteLine("La cantidad de dólares no es igual a la cantidad de pesos.");
            }

            Console.WriteLine("--------------------------------------------");

            //Comparo Dolar con Euro

            if (dolar1 == euro1)
            {
                Console.WriteLine("La cantidad de dólares es igual a la cantidad de euros.");
            }
            else
            {
                Console.WriteLine("La cantidad de dólares no es igual a la cantidad de euros.");
            }
            Console.WriteLine("--------------------------------------------");

            //Comparo Euro con Peso

            if (euro1 == peso1)
            {
                Console.WriteLine("La cantidad de euros es igual a la cantidad de pesos.");
            }
            else
            {
                Console.WriteLine("La cantidad de euros no es igual a la cantidad de pesos.");
            }



            Console.ReadLine();







        }
    }
}
