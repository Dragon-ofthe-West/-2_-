using System;

// Интерфейс Alive
public interface Alive
{
    void makeSound();
    int getAge();
    string getName();
}

// Базовый класс Animal
public class Animal : Alive
{
    protected int age;
    protected string shape;
    protected string name;

    public Animal(string name, int age, string shape)
    {
        this.name = name;
        this.age = age;
        this.shape = shape;
    }

    public virtual void makeSound()
    {
        Console.WriteLine("Животное издает звук");
    }

    public int getAge()
    {
        return age;
    }

    public string getName()
    {
        return name;
    }

    public void setName(string name)
    {
        this.name = name;
    }
}

// Класс Cat
public class Cat : Animal
{
    private Random random;

    public Cat(string name, int age, string shape) : base(name, age, shape)
    {
        random = new Random();
    }

    public override void makeSound()
    {
        // С вероятностью 50% не издавать звуков
        if (random.Next(2) == 0) // 0 или 1 (50% вероятность)
        {
            Console.WriteLine($"{name} мяукает: Мяу!");
        }
        else
        {
            Console.WriteLine($"{name} молчит");
        }
    }
}

// Класс Dog
public class Dog : Animal
{
    public Dog(string name, int age, string shape) : base(name, age, shape) { }

    public override void makeSound()
    {
        Console.WriteLine($"{name} лает: Гав-гав!");
    }
}

// Класс Person
public class Person
{
    private string name;
    private Alive companion;

    public Person(string name, Alive companion)
    {
        this.name = name;
        this.companion = companion;
    }

    public void getCompanionInfo()
    {
        Console.WriteLine($"=== Информация о человеке ===");
        Console.WriteLine($"Имя человека: {name}");
        Console.WriteLine($"--- Информация о компаньоне ---");
        Console.WriteLine($"Имя компаньона: {companion.getName()}");
        Console.WriteLine($"Возраст компаньона: {companion.getAge()} лет");
        Console.Write($"Звук компаньона: ");
        companion.makeSound();
        Console.WriteLine();
    }
}

// Основная программа
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Лабораторная работа 2 - Наследование и полиморфизм");
        Console.WriteLine("=================================================\n");

        // Создаем животных-компаньонов
        Cat cat = new Cat("Барсик", 3, "Стройный");
        Dog dog = new Dog("Шарик", 5, "Крупный");

        // Создаем людей с компаньонами
        Person person1 = new Person("Иван Иванов", cat);
        Person person2 = new Person("Мария Петрова", dog);

        // Выводим информацию о компаньонах
        person1.getCompanionInfo();
        person2.getCompanionInfo();

        // Демонстрация работы метода makeSound() у кота с разными результатами
        Console.WriteLine("Демонстрация работы метода makeSound() у кота:");
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Попытка {i + 1}: ");
            cat.makeSound();
        }

        Console.WriteLine("\nПрограмма завершена. Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}