using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductorConsumidor.Model
{
    public class Productor
    {
        private const int MaximoTiempoDurmiendo = 501; 
        private IBuffer _recursoCompartido;
        private Random _tiempoInatividad;

        public Productor(IBuffer recurso, Random generador) 
        {
            _recursoCompartido = recurso;
            _tiempoInatividad = generador;  
        }

        public void Producir()
        {
            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(_tiempoInatividad.Next(1,MaximoTiempoDurmiendo));
                _recursoCompartido.Buffer = i;
            }

            Console.WriteLine($"{Thread.CurrentThread.Name} terminó de reproducir");
        }
    }
}
