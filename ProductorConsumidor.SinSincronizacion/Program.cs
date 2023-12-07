using ProductorConsumidor.Model;
using ProductorConsumidor.SinSincronizacion;

Console.WriteLine("Demostración de Productor-Consumidor sin sincronización");

IBuffer recursoCompartido = new BufferImpl();
Random generador = new Random();

Productor productor = new Productor(recursoCompartido, generador);
Consumidor consumidor = new Consumidor(recursoCompartido, generador);

Thread hiloProductor = new Thread(new ThreadStart(productor.Producir));
Thread hiloConsumidor = new Thread(new ThreadStart(consumidor.consumir));

hiloProductor.Name = "Productor";
hiloProductor.Name = "Consumidor";

hiloProductor.Start();
hiloConsumidor.Start();


