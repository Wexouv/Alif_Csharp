/*
Многопоточное программирование - это когда программа может запускать методы в 
отдельных потоках (параллельных или асинхронных). Если приложение включает в себя
сложные и требующие много времени операции, то полезно исплзовать потоки, при этом
каждый поток выполняет определенную задачу.
*/

static void SayHello() {
    Console.WriteLine("Hello");
}

static void GetData() {
    // Get data
}

static void Main() {
    var newThread = new Thread(SayHello);
    newThread.Start();
    var newThread2 = new Thread(GetData);
    newThread2.Start();
}

/*
Aсинхронное программирование - это когда методы работают независимо друг от друга (запуск).
Асинхронное программирование позволяет нам делать что-то еще, ожидая завершения другой задачи.
*/

static void Main() {
    Task.Run(() => PushData());
    Task.Run(() => GetData());
}

/*
Параллельное программирование - это когда методы (потоки) работают одновременно (параллельнo)
*/

static void Main() {
    var tasks = new Task[amount];
    // Start all tasks in parallel
    for (int i = 0; i < amount; ++i)
        tasks[i] = Task.Factory.StartNew( () => Draw());
}

//---------------------------------------------------------------

// https://en.wikipedia.org/wiki/Multithreading_(computer_architecture)
