using System; 
using System.Linq; // Добавлено для удобной сортировки студентов по алфавиту

public class Student
{
    public int number;
    public string surname;
    public string name;
    public string patronymic;
    public string date_of_birth;
    public string address;
    public string phone_num;

    public static bool operator ==(Student a, Student b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;

        return a.number == b.number
            && a.surname == b.surname
            && a.name == b.name
            && a.patronymic == b.patronymic
            && a.date_of_birth == b.date_of_birth
            && a.address == b.address
            && a.phone_num == b.phone_num;
    }

    public static bool operator !=(Student a, Student b) => !(a == b);

    public override bool Equals(object obj)
    {
        return obj is Student student && this == student;
    }

    public override string ToString()
    {
        return $@"{surname} {name} {patronymic} (№ Книжки: {number})";
    }
}

public class Group
{
    public int group_number;
    public Student[] stud_list = {};

    // Индексатор для поиска по номеру зачетной книжки
    public Student this[int studentNumber]
    {
        get 
        { 
            // Ищем студента в массиве с таким номером
            foreach (var s in stud_list)
            {
                if (s.number == studentNumber) return s;
            }
            return null; // Если не нашли
        }
    }

    public void Add(Student stud)
    {
        if (stud == null) return;
        
        // Увеличиваем размер массива на 1
        Array.Resize(ref stud_list, stud_list.Length + 1);

        // Записываем студента в самый конец
        stud_list[stud_list.Length - 1] = stud;
    }
    public void Remove(Student stud)
    {
        if (stud == null) return;

        // Ищем индекс студента в массиве
        int indexToRemove = -1;
        for (int i = 0; i < stud_list.Length; i++)
        {
            if (stud_list[i] == stud)
            {
                indexToRemove = i;
                break;
            }
        }

        // Если студент найден, удаляем его сдвигом массива
        if (indexToRemove != -1)
        {
            Student[] newArray = new Student[stud_list.Length - 1];

            Array.Copy(stud_list, 0, newArray, 0, indexToRemove);
            Array.Copy(stud_list, indexToRemove + 1, newArray, indexToRemove, stud_list.Length - indexToRemove - 1);

            stud_list = newArray;
        }
    }

    // Возврат номера группы и списка в алфавитном порядке
    public string GetInfo()
    {
        // Сортируем студентов по Фамилии, затем по Имени
        var sortedStudents = stud_list.OrderBy(s => s.surname).ThenBy(s => s.name);

        string studentsInfo = "";
        foreach (var s in sortedStudents)
        {
            studentsInfo += s.ToString() + "\n";
        }

        return $"Группа №{group_number}\nСписок студентов (по алфавиту):\n{studentsInfo}";
    }
}

public class Program
{
    public static void Main()
    {
        Student student1 = new Student{ number = 1, surname = "Иванов", name = "Андрей", patronymic = "Николаевич" };
        Student student2 = new Student{ number = 2, surname = "Петров", name = "Алексей", patronymic = "Петрович" };
        Student student3 = new Student{ number = 5, surname = "Абрамов", name = "Сергей", patronymic = "Владимирович" };
        
        // Создаем группу
        Group group = new Group();
        group.group_number = 101;

        // Тестируем добавление
        group.Add(student1);
        group.Add(student2);
        group.Add(student3);

        Console.WriteLine("--- После добавления 3-х студентов ---");
        Console.WriteLine(group.GetInfo());

        // Тестируем удаление (удалим Петрова)
        group.Remove(student2);

        Console.WriteLine("--- После удаления Петрова ---");
        Console.WriteLine(group.GetInfo());

        // Тестируем индексатор (ищем студента с номером книжки 5 - Абрамов)
        Console.WriteLine("--- Поиск через индексатор ---");
        Student found = group[5]; 
        if (found != null)
        {
            Console.WriteLine($"Найден студент по зачетке №5: {found.surname} {found.name}");
        }
    }
}
