internal class Program
{
    public static void Main()
    {
        MyList myList = new MyList();

        Console.WriteLine("Count = " + myList.Count);
        myList.Add(10);
        myList.Add(20);
        myList.Add(30);
        Console.WriteLine("Count = " + myList.Count);
        myList.Add(40);
        Console.WriteLine("Count = " + myList.Count);
        myList.Add(-1);
        myList.Add(54);
        myList.Add(32);
        myList.Add(-123);
        Console.WriteLine("Count = " + myList.Count);

        Console.WriteLine("До изменения" + myList.ToString());
        Console.WriteLine("Использование ForEach");
        myList.ForEach(item => Console.WriteLine(item));

        myList.Remove(20);
        Console.WriteLine("Count = " + myList.Count);
        myList.ForEach(item => Console.WriteLine(item));

        myList.Insert(1, 5);
        Console.WriteLine("Count = " + myList.Count);
        myList.ForEach(item => Console.WriteLine(item));

        myList.RemoveAt(2);
        Console.WriteLine("Count = " + myList.Count);
        myList.ForEach(item => Console.WriteLine(item));

        myList.Clear();
        Console.WriteLine("Count = " + myList.Count);
        myList.ForEach(item => Console.WriteLine(item));

        Console.WriteLine("После изменения: " + myList.ToString());
        Console.ReadLine();
    }
}