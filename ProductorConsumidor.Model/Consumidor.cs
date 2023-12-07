using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductorConsumidor.Model
{
    public class Consumidor
    {
        private const int MaxTiempoDurmiendo = 501;
        private IBuffer _recursoCompartido;
        private Random _generador;
        
        public Consumidor(IBuffer recurso, Random generador)
        {
            _recursoCompartido = recurso;
            _generador = generador;
        }

        public void consumir()
        {
            int suma = 0;

            for (int i = 1; i <= 10;  i++)
            {
                Thread.Sleep(_generador.Next(1, MaxTiempoDurmiendo));
                suma += _recursoCompartido.Buffer;
            }

            Console.WriteLine($"{Thread.CurrentThread.Name} leyo y sumó valores por un total {suma}");
        }
    }
}
