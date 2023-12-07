using ProductorConsumidor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductorConsumidor.SinSincronizacion
{
    public class BufferImpl : IBuffer
    {
        private int _buffer = -1;
        public int Buffer 
        { 
            get
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} leyó el valor {_buffer}");
                return _buffer;
            }
            set
            {
                _buffer = value;
                Console.WriteLine($"{Thread.CurrentThread.Name} escribió el valor {value}");
            }
        }
    }
}
