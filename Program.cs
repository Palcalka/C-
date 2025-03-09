using System;
using System.Reflection.Metadata;

class Doct
{
    int ExperienceDoc;
    int Countpacient;
    int[] Polis;
    string Firstname;
    string Secondname;
    string Specialization;
    static int CountDoct;
    static Random rand = new Random();

    // Конструктор по умолчанию
    public Doct()
    {
        CountDoct++;
        Countpacient = 4;
        ExperienceDoc = 5;
        Firstname = "Ivan";
        Secondname = "Ivanov";
        Specialization = "Stomatolog";
        Polis = new int[Countpacient];
        for (int i = 0; i < Countpacient; i++)
        {
            Polis[i] = rand.Next(4);
        }
    }
    // Конструктор с параметрами
    public Doct(int Countpacient, int ExperienceDoc)
    {
        CountDoct++;
        Firstname = "Sanea";
        Secondname = "Sincekov";
        this.Countpacient = Countpacient;
        this.ExperienceDoc = ExperienceDoc;
        Specialization = "Raddiologist";
        for (int i = 0; i < Countpacient; i++)
        {
            Polis[i] = rand.Next(4);
        }
    }
    // Конструктор копирования
    public Doct(Doct Prototype)
    {
        CountDoct++;
        Firstname = Prototype.Firstname;
        Secondname = Prototype.Secondname;
        Countpacient = Prototype.Countpacient;
        ExperienceDoc = Prototype.ExperienceDoc;
        Specialization = Prototype.Specialization;
        for (int i = 0; i < Countpacient; i++)
        {
            Polis[i] = Prototype.Polis[i];
        }
    }
    // Вывод  личного дела врача
    public void PrintFields()
    {
        Console.WriteLine("Личноe дела врача:");
        Console.WriteLine("Имя" + Firstname);
        Console.WriteLine("Фамилия:" + Secondname);
        Console.WriteLine("Опыт:" + ExperienceDoc);
        Console.WriteLine("Специализация:" + Specialization);
        Console.WriteLine("Число vizitors:" + Countpacient);
        Console.WriteLine("Число посетителей:");
        for (int i = 0; i < Polis.Length; i++)
        {
            Console.Write(Polis[i] + " ");
        }
        Console.WriteLine("\n===============================");

    }
    // C клавиатуры проверка
    public void EnterFields()
    {
        while (String.IsNullOrEmpty(Firstname))
        {
            Console.WriteLine("Введите имя вврача");
            Firstname = Console.ReadLine();
        }
        while (String.IsNullOrEmpty(Secondname))
        {
            Console.WriteLine("Введите Фамилию вврача");
            Secondname = Console.ReadLine();
        }
        while (ExperienceDoc <= 0)
        {
            Console.WriteLine("Введите опыт вврача в годах");
            ExperienceDoc = Convert.ToInt32(Console.ReadLine());
        }
        while (String.IsNullOrEmpty(Specialization))
        {
            Console.WriteLine("Введите специализацию вврача");
            Specialization = Console.ReadLine();
        }
        while (Countpacient <= 0)
        {
            Console.WriteLine("Введите число пациентов врача ");
            Countpacient = Convert.ToInt32(Console.ReadLine());
        }


        string pacientcount = Console.ReadLine();
        while (String.IsNullOrEmpty(pacientcount) == false)
        {
            Polis.Append(Convert.ToInt32(pacientcount));
            pacientcount = Console.ReadLine();
        }
    }
    //заполняющую случайными значениями
    public void RandomFill()
    {
        string[] randomFirstnames = { "vanea", "Jora", "MAX", "pETEA", "vOVA" };
        string[] randomSecondnames = { "ranic", "hons", "ponisaka", "iku", "turunuk" };
        string[] randomSpecialization = { "Pediator", "LOR", "Okulist", "hIRURG", "ORTOPED" };
        Firstname = randomFirstnames[rand.Next(randomFirstnames.Length)];
        Secondname = randomSecondnames[rand.Next(randomSecondnames.Length)];
        Specialization = randomSpecialization[rand.Next(randomSpecialization.Length)];
        ExperienceDoc = rand.Next(2, 16);
        Countpacient = rand.Next(1, 11);
        for (int i = 0; i < Countpacient; i++)
        {
            Polis.Append(rand.Next(2000, 5000));
        }
    }
    // функцию добавления пациента по номеру его полиса
    public void addPacientbyPolis(int policyNumber)
    {
        for (int i = 0; i < Polis.Length; i++)
        {
            if (Polis[i] == policyNumber)
            {
                Console.WriteLine("Вы ошиблись");
                return;
            }
        }
    }
    //функцию добавления пациента по номеру его полиса.

    public int RemovePacientbyPolis(int policyNumber)
    {
        for (int i = 0; i < Polis.Length; i++)
        {
            if (Polis[i] == policyNumber)
            {
                Polis = Polis.Where(val => val == policyNumber).ToArray();
                return policyNumber;
            }
        }
        Console.WriteLine("Вы ошиблись номер введен неверно ");
        return -1;
    }
    //сравнения двух врачей по популярности
    public static void DoctComparing(Doct doct1, Doct doct2)
    {
        if (doct1.Countpacient > doct2.Countpacient)
        {
            Console.WriteLine("Популярность первого доктора выше");
        }
        else
        {
            Console.WriteLine("Популярность Второго доктора выше");
        }
    }
    public void main()
    {
        Doct[] Hospital = new Doct[10];
        Hospital[0] = new Doct(); // Конструктор по умолчанию
        Hospital[1] = new Doct(10, 10); // Конструктор с параметрами
        Hospital[2] = new Doct(Hospital[0]); // Конструктор копирования


        for (int i = 0; i < Hospital.Length; i++)
        {
            if (Hospital[i] != null)
            {
                Hospital[i].PrintFields();
            }
        }

        for (int i = 0; i < Hospital.Length; i++)
        {
            if (Hospital[i] != null)
            {
                Hospital[i].RandomFill();
                Hospital[i].PrintFields();
            }
        }
        Hospital[Hospital.Length - 1].RandomFill();
        Hospital[0].addPacientbyPolis(Hospital[1].RemovePacientbyPolis(2));
        Hospital[0].PrintFields();
        Hospital[1].PrintFields();
        DoctComparing(Hospital[0], Hospital[1]);
        int totalPatient = 0;

        for (int i = 0; i < Hospital.Length; i++)
        {
            totalPatient = totalPatient + Hospital[i].Countpacient;
        }
        // Вывод общего количества созданных автомобилей
        Console.WriteLine($"\nВсего Врачей :"+ CountDoct);
    }
}