using System;
using System.Linq;

class Doctor
{
    private int experience;
    private int patientCount;
    private int[] policies;
    private string firstName;
    private string lastName;
    private string specialization;
    private static int doctorCount;
    private static Random rand = new Random();

    public Doctor()
    {
        doctorCount++;
        experience = 5;
        patientCount = 4;
        firstName = "Ivan";
        lastName = "Ivanov";
        specialization = "Stomatolog";
        policies = new int[patientCount];
        for (int i = 0; i < patientCount; i++)
        {
            policies[i] = rand.Next(1000, 9999);
        }
    }

    public Doctor(int patientCount, int experience)
    {
        doctorCount++;
        firstName = "Sanea";
        lastName = "Sincekov";
        this.patientCount = patientCount;
        this.experience = experience;
        specialization = "Radiologist";
        policies = new int[patientCount];
        for (int i = 0; i < patientCount; i++)
        {
            policies[i] = rand.Next(1000, 9999);
        }
    }

    public Doctor(Doctor prototype)
    {
        doctorCount++;
        firstName = prototype.firstName;
        lastName = prototype.lastName;
        patientCount = prototype.patientCount;
        experience = prototype.experience;
        specialization = prototype.specialization;
        policies = (int[])prototype.policies.Clone();
    }

    public void PrintFields()
    {
        Console.WriteLine($"Доктор: {firstName} {lastName}, Специализация: {specialization}, Опыт: {experience}, Пациенты: {patientCount}");
        Console.Write("Полисы пациентов: ");
        Console.WriteLine(string.Join(", ", policies));
        Console.WriteLine("=================================");
    }

    public void EnterFields()
    {
        Console.Write("Введите имя врача: ");
        firstName = Console.ReadLine() ?? "Unknown";
        
        Console.Write("Введите фамилию врача: ");
        lastName = Console.ReadLine() ?? "Unknown";
        
        Console.Write("Введите опыт врача в годах: ");
        while (!int.TryParse(Console.ReadLine(), out experience) || experience <= 0)
        {
            Console.Write("Ошибка! Введите корректный опыт: ");
        }
        
        Console.Write("Введите специализацию: ");
        specialization = Console.ReadLine() ?? "Unknown";
        
        Console.Write("Введите число пациентов: ");
        while (!int.TryParse(Console.ReadLine(), out patientCount) || patientCount <= 0)
        {
            Console.Write("Ошибка! Введите корректное число пациентов: ");
        }
        
        policies = new int[patientCount];
        for (int i = 0; i < patientCount; i++)
        {
            policies[i] = rand.Next(1000, 9999);
        }
    }

    public void AddPatient(int policyNumber)
    {
        if (policies.Contains(policyNumber))
        {
            Console.WriteLine("Ошибка! Такой полис уже существует.");
            return;
        }
        Array.Resize(ref policies, policies.Length + 1);
        policies[^1] = policyNumber;
        patientCount++;
    }

    public bool RemovePatient(int policyNumber)
    {
        if (!policies.Contains(policyNumber))
        {
            Console.WriteLine("Ошибка! Полис не найден.");
            return false;
        }
        policies = policies.Where(p => p != policyNumber).ToArray();
        patientCount--;
        return true;
    }

    public static void CompareDoctors(Doctor d1, Doctor d2)
    {
        Console.WriteLine(d1.patientCount > d2.patientCount
            ? "Первый доктор популярнее."
            : "Второй доктор популярнее.");
    }

    public static void Main()
    {
        Doctor[] hospital = new Doctor[5];
        hospital[0] = new Doctor();
        hospital[1] = new Doctor(8, 10);
        hospital[2] = new Doctor(hospital[0]);
        hospital[3] = new Doctor(5, 15);
        hospital[4] = new Doctor(6, 8);

        foreach (var doctor in hospital)
        {
            doctor.PrintFields();
        }

        Console.WriteLine("Заполнение последнего врача с клавиатуры:");
        hospital[^1].EnterFields();
        hospital[^1].PrintFields();

        int policyToMove = hospital[1].policies[0];
        if (hospital[1].RemovePatient(policyToMove))
        {
            hospital[0].AddPatient(policyToMove);
        }

        hospital[0].PrintFields();
        hospital[1].PrintFields();

        CompareDoctors(hospital[0], hospital[1]);

        int totalPatients = hospital.Sum(d => d.patientCount);
        Console.WriteLine($"Общее число пациентов: {totalPatients}");
        Console.WriteLine($"Общее число врачей: {doctorCount}");
    }
}
