using System;

class Program
{
    static void Main()
    {
        // Создаем экземпляр MyList и добавляем элементы
        MyList<int> numbers = new MyList<int>();
        Console.WriteLine("=== Добавление элементов ===");
        numbers.Add(5);
        numbers.Add(10);
        numbers.Add(3);
        numbers.Add(8);
        numbers.Add(1);
        Console.WriteLine("Список после добавления элементов: " + numbers);

        // Вставка элемента по индексу
        Console.WriteLine("\n=== Вставка элементов ===");
        numbers.Insert(2, 15);
        Console.WriteLine("Список после вставки 15 на позицию 2: " + numbers);

        // Получение элемента по индексу
        Console.WriteLine("\n=== Доступ к элементам по индексу ===");
        Console.WriteLine("Элемент на позиции 3: " + numbers[3]);

        // Удаление элемента
        Console.WriteLine("\n=== Удаление элемента ===");
        numbers.Remove(8);
        Console.WriteLine("Список после удаления 8: " + numbers);

        // Удаление по индексу
        Console.WriteLine("\n=== Удаление элемента по индексу ===");
        numbers.RemoveAt(0);
        Console.WriteLine("Список после удаления элемента на позиции 0: " + numbers);

        // Проверка, содержит ли список элемент
        Console.WriteLine("\n=== Проверка наличия элементов ===");
        Console.WriteLine("Список содержит 10: " + numbers.Contains(10));
        Console.WriteLine("Список содержит 100: " + numbers.Contains(100));

        // Поиск индекса элемента
        Console.WriteLine("\n=== Поиск индекса элемента ===");
        Console.WriteLine("Индекс элемента 15: " + numbers.IndexOf(15));

        // Получение текущего количества элементов
        Console.WriteLine("\n=== Количество элементов ===");
        Console.WriteLine("Количество элементов: " + numbers.Count);

        // Сортировка списка по возрастанию
        Console.WriteLine("\n=== Сортировка по возрастанию ===");
        numbers.Sort();
        Console.WriteLine("Список после сортировки: " + numbers);

        // Сортировка по убыванию с использованием Comparison<T>
        Console.WriteLine("\n=== Сортировка по убыванию ===");
        numbers.Sort((x, y) => y.CompareTo(x));
        Console.WriteLine("Список после сортировки по убыванию: " + numbers);

        // Использование метода Find
        Console.WriteLine("\n=== Поиск элементов с помощью Find ===");
        int found = numbers.Find(x => x > 5);
        Console.WriteLine("Первый элемент больше 5: " + found);

        // Преобразование в массив
        Console.WriteLine("\n=== Преобразование в массив ===");
        int[] array = numbers.ToArray();
        Console.WriteLine("Массив: " + string.Join(", ", array));


        Console.WriteLine("\n=== Перебор элементов с помощью ForEach ===");
        Console.Write("Элементы списка: ");
        numbers.ForEach(item => Console.Write(item + " "));
        Console.WriteLine();

        Console.WriteLine("\n=== Емкость списка (Capacity) ===");
        Console.WriteLine("Текущая емкость: " + numbers.Capacity);
        numbers.Capacity = 20;
        Console.WriteLine("Новая емкость после увеличения: " + numbers.Capacity);

        Console.WriteLine("\n=== Очистка списка ===");
        numbers.Clear();
        Console.WriteLine("Список после очистки: " + numbers);
        Console.WriteLine("Количество элементов после очистки: " + numbers.Count);

        MyList<string> fruits = new MyList<string>();

        fruits.Add("Apple");
        fruits.Add("Banana");
        fruits.Add("Cherry");

        fruits.Insert(1, "Orange");

        Console.WriteLine("\n\tСписок фруктов:");
        Console.WriteLine(fruits);

        string _Found = fruits.Find(f => f.StartsWith("B"));
        Console.WriteLine("\nНайденный фрукт: " + _Found);

        fruits.Sort();
        Console.WriteLine("\nСписок фруктов после сортировки:");
        Console.WriteLine(fruits);

        fruits.Remove("Orange");
        Console.WriteLine("\nСписок фруктов после удаления 'Orange':");
        Console.WriteLine(fruits);
    }
}