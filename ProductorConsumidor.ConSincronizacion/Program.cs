using ProductorConsumidor.ConSincronizacion;
using ProductorConsumidor.Model;

Console.WriteLine("Demostracion de sincronización en Productor-Consumidor");

BufferImpl recusoCompartido = new BufferImpl();
Random generador = new Random();

Console.WriteLine("{0, -40}{1, -9}{2}\n", "operacion", "Buffer", "Conteo Ocupado");
recusoCompartido.MostrarEstado("Esrado inicial");

Productor productor = new Productor(recusoCompartido, generador);
Consumidor consumidor = new Consumidor(recusoCompartido,generador);

Thread hiloProductor = new Thread(new ThreadStart(productor.Producir));
Thread hiloConsumidor = new Thread(new ThreadStart(consumidor.consumir));

hiloProductor.Name = "Productor";
hiloConsumidor.Name = "Consumidor";

hiloProductor.Start();
hiloConsumidor.Start();