using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Singlenton.Model
{
    public class SessionManager
    {

        public Usuario Usuario { get; set; }
        public DateTime FechaInicio { get; set; }

        private static SessionManager _session;

        public static Object _lock = new Object();

        //Metodo que normalmete se nombra de la siguiente forma para poder tener acceso a dicha instancia
        public static SessionManager GetInstance
        {
            get
            {
                //if (_session == null)
                //{
                //    _session = new SessionManager();
                //}

                if (_session == null)          
                    throw new Exception("La sesion no a sido iniciada");
                

                return _session;
            }
        }

        //La sesion es una unica instancia de acceso global, variacio por el ejemplo que estamos dando
        public static void Login(Usuario usuario)
        {
            //Validacion por si mas de un hilo trata de acceder a las instancia: para no "solapar" dos proceso que pidan la instancia
            lock(_lock)
            {
                if (_session == null)
                {
                    _session = new SessionManager();
                    _session.Usuario = usuario;
                    _session.FechaInicio = DateTime.Now;
                }
                else
                {
                    throw new Exception("La sesion ya a sido iniciada");
                }
            }
        }

        public static void Logout()
        {
            lock(_lock){
                if (_session != null)
                {
                    _session = null;
                }
                else
                {
                    throw new Exception("La sesion no a sido iniciada");
                }
            }
        }


        //Poner el constructor en privado para no crear una instancia fuera de la clase
        private SessionManager()
        {

        }

    }
}
