using ProductorConsumidor.Model;

namespace ProductorConsumidor.ConSincronizacion
{
    public class BufferImpl : IBuffer
    {
        private int _buffer = -1;
        private int _conteoBufferOcupado = 0;

        public int Buffer 
        { 
            get
            {
                Monitor.Enter(this);
                if (_conteoBufferOcupado == 0)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} esta intentando leer.");
                    MostrarEstado($"Buffer vacio. {Thread.CurrentThread.Name} se pone en espera.");
                    Monitor.Wait(this);
                }

                _conteoBufferOcupado--;
                MostrarEstado($"{Thread.CurrentThread.Name} lee {_buffer}");
                Monitor.Pulse(this);
                int copiaBuffer = _buffer;
                Monitor.Exit(this);
                return copiaBuffer;
            } 
            set
            {
                Monitor.Enter(this);
                if (_conteoBufferOcupado == 1)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} está intentando escribir");
                    MostrarEstado($"Buffer lleno. {Thread.CurrentThread.Name} se pone en espera");
                    Monitor.Wait(this);
                }

                _buffer = value;
                _conteoBufferOcupado++;
                MostrarEstado($"{Thread.CurrentThread.Name} escribe {_buffer}");
                Monitor.Pulse(this);
                Monitor.Exit(this);
            }
        }

        public void MostrarEstado(string operacion)
        {
            Console.WriteLine("{0, -40}{1, -9}{2}", operacion, _buffer, _conteoBufferOcupado);
        }
    }
}
