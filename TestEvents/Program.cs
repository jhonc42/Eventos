using Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            //Crear una instancia de Operations:
            var E = new Operations();
            // se coloca E.DivideByZero += y a continuacion el manejador del evento CON EXPRESION LAMBDA DIRECTAMENTE, el tipo de datos en los parametros es inferido:
            E.DivideByZero += (sender, e) =>
            {
                Console.WriteLine($"División entre cero: {e.A}, {e.B}");
                //para pasarle algun valor al evento desde el suscriptor o mejor manejador de evento: ejemplo pasarle un uno:
                //como llega el evento significa que le envio un 0 y lo podria cambiar por un 1:
                e.B = 1;
            };
            int N1 = 4;
            int N2 = 0;
            //Llama al metodo Divide y le envia dos numeros:
            int R = E.Divide(N1,N2);
            Console.WriteLine($"{N1}/{N2}={R}");

            Console.Write("Comment of GitHub");
            Console.Write("Presiona <Enter> para finalizar");
            
            Console.ReadLine();
        }
        //PARA NO USAR ESTE MANEJADOR SE DECLARO CON LAMBDA DIRECTAMENTE EN EL E.DIVIDEBYZERO
        //private static void E_DivideByZero(object sender, EventArgs e)
        //{
            //se borra el throw new NotImple... y se coloca el codigo que quiere que suceda si el evento es notificado osea si paso el evento determinado:
            //throw new NotImplementedException();
        //    Console.WriteLine("División entre cero");
        //}
    }
}
