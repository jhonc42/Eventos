using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Editor
{
    public class Operations
    {
        //ESTE ES EL EDITOR:
        //NOTA: en esta clase se define el Editor del evento, se declara que si B es igual a 0 se dispare un evento llamado DivideByZero

        //NOTA: para notificar algo lo mejor es usar un evento que un delegado aunque con delegados se pueden.

        /*
         LOS DOS PARAMETROS DE UN EVENTO:
            el object es el que dispara el evento
            el eventargs son los datos del evento

            //declarar el delegado para el evento:
            delegate void EventHandler (object sender, EventArgs e);

            //como se declara un evento:
            //palabra reservada event + tipo del delegado + nombre del evento;
            event EventHandler NameEvent
         */

        // para crear un evento necesita un delegado que es la base del evento
        // declaracion del delegado:
        // si el delegado se va a usar con un evento es mejor ponerle de nombre: nombrecualquier + EventHandler
        //ESTE DELEGADO RECIBE DATOS PARA ENVIO O TRASPASO DE DATOS DE TIPO DivideByZeroEventArgs QUE ES LA CLASE QUE ESTA ABAJO DE TODO EL CODIGO
        public delegate void DivideByZeroEventHandler(object sender, DivideByZeroEventArgs e);
        // declaracion del evento que usara el delegado anterior
        public event DivideByZeroEventHandler DivideByZero;

        //public string Message; 
        //esta forma anterior expone o define un campo sobre el cual no tienen control es decir el cliente le puede poner lo que quiera
        //mejor practica encapsulelo en una propiedad:
        public string Message { get; set; }

        public int Divide(int A, int B)
        {
            int Result = 0;
            if (B == 0)
            {
                // revisa si el evento tiene un suscriptor: si no lo tiene es mejor no llamarlo
                if (DivideByZero != null)
                {
                    //EN ESTE CASO YA SE ENVIAN DATOS
                    //DE LA SIGUIENTE FORMA SE ENVIAN LOS DATOS DE LA CLASE DIVIDEBYZEROEVENTARGS DE UNA VEZ
                    var Data = new DivideByZeroEventArgs ( A , B );
                    //PERO SI AUN NO TIENE EL DATO DE A Y B PODRIA ENVIARLO LUEGO DE ESTA FORMA
                    var Data2 = new DivideByZeroEventArgs();
                    //CUANDO TENGA EL DATO LO ENVIA:
                    Data2.A = A;
                    Data2.B = B;
                    //SI NO TIENE CONSTRUCTOR PUEDE ENVIARLO DE LA SIGUIENTE FORMA PERO NO ES BUENA PRACTICA:
                    //DivideByZero(this, new DivideByZeroEventArgs { A = A, B = B });
                    //ESTA ES BUENA PRACTICA CON CONSTRUCTOR:
                    DivideByZero(this, Data);
                    //En este caso si el suscriptor o manejador de evento le pasa el 1 podria hacer la division:
                    Result = A / Data.B;

                }
            }
            else
            {
                Result = A / B;
            }
            return Result;
        }
        

    }

    //SE NECESITA HACER QUE HEREDE DE EVENTARGS PARA USAR ESTA CLASE EN EL EVENTO:
    //SE RECOMIENDA QUE PONGA A LAS CLASES QUE PERTENECEN AL EVENTO EL NOMBRE DEL EVENTO MAS EL SUFIJO EVENTARGS:

    public class DivideByZeroEventArgs : EventArgs
    {
        ////ESTE CONSTRUCTOR ES PARA NO OBLIGAR AL QUE VAYA A USAR LA CLASE A PASARLE PARAMETROS CUANDO SE INSTANCIE:
        public DivideByZeroEventArgs() { }
        //CONSTRUCTOR DE LA CLASE:
        public DivideByZeroEventArgs(int A, int B)
        {
            this.A = A;
            this.B = B;
        }
        public int A { get; set; }
        public int B { get; set; }
    }


}
