public class Student
{
    public int number;
    public string surname;
    public string name;
    public string patronymic;
    public string date_of_birth;
    public string address;
    public string phone_num;

    public static bool operator ==(Student a, Student b) => 
    (a.number == b.number)
    && (a.surname == b.surname)
    && (a.name == b.name)
    && (a.patronymic == b.patronymic)
    && (a.date_of_birth == b.date_of_birth)
    && (a.address == b.address)
    && (a.phone_num == b.phone_num);

    public static bool operator !=(Student a, Student b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        return obj is Student student && this == student;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}


public class Program
{
    public static void Main()
    {
        Student student1 = new Student{
            number = 1, 
            address = "Рязань", 
            date_of_birth = "12.06.2004", 
            name = "Андрей", 
            patronymic = "Николаевич", 
            surname = "Иванов", 
            phone_num = "123"};

        Student student2 = new Student{
            number = 1, 
            address = "Рязань", 
            date_of_birth = "12.06.2004", 
            name = "Андрей", 
            patronymic = "Николаевич", 
            surname = "Иванов", 
            phone_num = "123"};

        Student student3 = new Student{
            number = 5, 
            address = "Коломна", 
            date_of_birth = "02.02.2004", 
            name = "Сергей", 
            patronymic = "Владимирович", 
            surname = "Сергеев", 
            phone_num = "1234"};
        
        if (student1.Equals(student2) == true)
        {Console.WriteLine("Студенты 1 и 2 совпадают\n");}
        else {
            Console.WriteLine("Студенты 1 и 2 не совпадают\n");
        }

        if (student1.Equals(student3) == true)
        {Console.WriteLine("Студенты 1 и 3 совпадают\n");
        } else {
            Console.WriteLine("Студенты 1 и 3 не совпадают\n");
        }
    }
}