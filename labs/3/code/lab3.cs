public abstract class Figure    // Фигура
{
    public string Name {get; set;}
    public string Colour {get; set;}
    public abstract double Perimeter();
    public abstract double? Square();

    public override string ToString()
    {
        return $@"
        Фигура:
        {Name}
        Цвет:
        {Colour}
        Периметр:
        {Perimeter()}
        Площадь:
        {Square()}";
    }
}

public class Circle : Figure    // Круг
{
    protected double radius;

    public Circle(double radius)    // Конструктор Circle
    {
        this.radius = radius;
    }

    public override double Perimeter()
    {
        return 2 * Math.PI * radius;    // Длина окружности
    }
    public override double? Square()
    {
        return Math.PI * (Math.Pow(radius, 2));    // Площадь круга
    }
}


public class Ellipse : Circle   // Эллипс
{
    // Больший радиус наследуется из Circle
    private double radius_1; // Меньший радиус

    public Ellipse(double radius, double radius_1) : base(radius)   // Конструктор Ellipse
    {
        this.radius_1 = radius_1;
    }

    public override double Perimeter()
    {
        return 
        2 * Math.PI * Math.Sqrt((Math.Pow(radius, 2) + Math.Pow(radius_1, 2)) / 2);    // Периметр эллипса (формула Эйлера)
    }
    public override double? Square()
    {
        return Math.PI * radius * radius_1;   // Площадь эллипса
    }
}

public class Ring : Circle  // Кольцо
{
    public Ring(double radius) : base(radius) { }   // Конструктор Ring

    public override double? Square()
    {
        return null;
    }
}


public class Parallelogram : Figure // Параллелограмм
{
    protected double side_a;
    protected double side_b;
    protected double height_a;  // Высота, проведенная к стороне A

    public Parallelogram(double side_a, double side_b, double height_a) // Конструктор Parallelogram
    {
        this.side_a = side_a;
        this.side_b = side_b;
        this.height_a = height_a;
    }

    public override double Perimeter()
    {
        return 2* (side_a + side_b);
    }

    public override double? Square()
    {
        return height_a * side_a;
    }
}


public class Rectangle : Parallelogram  // Прямоугольник
{
    public Rectangle(double side_a, double side_b) : base(side_a, side_b, side_b) { }   // Конструктор Rectangle
}


public class Rhombus : Parallelogram    // Ромб
{
    public Rhombus(double side_a, double height_a) : base(side_a, side_a, height_a) { } // Конструктор Rhombus  
}


public class NAngle : Figure    // Правильный n-угольник
{
    protected int angles_num;
    protected double side;
    protected double radius;    // Радиус вписанной окружности
    public NAngle(int angles_num, double side, double radius)   // Конструктор NAngle
    {
        this.angles_num = angles_num;
        this.radius = radius;
        this.side = side;
    }
    public override double Perimeter()
    {
        return angles_num * side;
    }
    public override double? Square()
    {
        double P = Perimeter();
        return 0.5 * P * radius;
    }
}

public class SquareFigure : NAngle  // Квадрат
{
    public SquareFigure(double side, double radius) : base(4, side, radius) { } // Конструктор SquareFigure
}

public class Triangle : NAngle  // Треугольник
{
    public Triangle(double side, double radius) : base(3, side, radius) { } // Конструктор Triangle
}

public class Program
{
    public static void Main()
    {
        // Консольное меню
        while (true)
        {
            Console.WriteLine(@"
            ====== СОЗДАНИЕ ФИГУРЫ ======
            1. Круг
            2. Эллипс
            3. Кольцо
            4. Параллелограмм
            5. Прямоугольник
            6. Ромб
            7. Правильный n-угольник
            8. Квадрат
            9. Треугольник
            0. Выход из меню");
            
            Console.Write("Ваш выбор: ");
            string? choiceInput = Console.ReadLine();
            if (!int.TryParse(choiceInput, out int choice))
            {
                Console.WriteLine("Пожалуйста, введите корректное число.");
                continue;
            }

            if (choice == 0)
            {
                Console.WriteLine("Выход из программы...");
                break;
            }

            Console.Write("Имя фигуры: ");
            string name = Console.ReadLine() ?? ""; 

            Console.Write("Цвет: ");
            string colour = Console.ReadLine() ?? ""; 

            Figure? currentFigure = null;

            switch (choice)
            {
                case 1: // Круг
                    Console.Write("Радиус: ");
                    double cRadius = Convert.ToDouble(Console.ReadLine());
                    currentFigure = new Circle(cRadius); 
                    break;

                case 2: // Эллипс
                    Console.Write("Больший радиус: ");
                    double eRadA = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Меньший радиус: ");
                    double eRadB = Convert.ToDouble(Console.ReadLine());
                    currentFigure = new Ellipse(eRadA, eRadB); 
                    break;

                case 3: // Кольцо
                    Console.Write("Радиус: ");
                    double rRadius = Convert.ToDouble(Console.ReadLine());
                    currentFigure = new Ring(rRadius); 
                    break;

                case 4: // Параллелограмм
                    Console.Write("Сторона A: ");
                    double pSideA = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Сторона B: ");
                    double pSideB = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Высота к стороне A: ");
                    double pHeight = Convert.ToDouble(Console.ReadLine());
                    currentFigure = new Parallelogram(pSideA, pSideB, pHeight);
                    break;

                case 5: // Прямоугольник
                    Console.Write("Сторона A (Ширина): ");
                    double rectA = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Сторона B (Высота): ");
                    double rectB = Convert.ToDouble(Console.ReadLine());
                    currentFigure = new Rectangle(rectA, rectB);
                    break;

                case 6: // Ромб
                    Console.Write("Сторона: ");
                    double rhSide = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Высота: ");
                    double rhHeight = Convert.ToDouble(Console.ReadLine());
                    currentFigure = new Rhombus(rhSide, rhHeight);
                    break;

                case 7: // Правильный n-угольник
                    Console.Write("Количество углов (n): ");
                    int nAngles = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Длина стороны: ");
                    double nSide = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Радиус вписанной окружности: ");
                    double nRad = Convert.ToDouble(Console.ReadLine());
                    currentFigure = new NAngle(nAngles, nSide, nRad);
                    break;

                case 8: // Квадрат
                    Console.Write("Сторона: ");
                    double sqSide = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Радиус вписанной окружности: ");
                    double sqRad = Convert.ToDouble(Console.ReadLine());
                    currentFigure = new SquareFigure(sqSide, sqRad);
                    break;

                case 9: // Треугольник
                    Console.Write("Сторона: ");
                    double trSide = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Радиус вписанной окружности: ");
                    double trRad = Convert.ToDouble(Console.ReadLine());
                    currentFigure = new Triangle(trSide, trRad);
                    break;

                default:
                    Console.WriteLine("Неверный выбор, попробуйте еще раз.");
                    continue;
            }

            // Настройка свойств и немедленный вывод ToString()
            if (currentFigure != null)
            {
                currentFigure.Name = name;
                currentFigure.Colour = colour;
                
                Console.WriteLine("\n=== УСПЕШНО СОЗДАНА ФИГУРА ===");
                // Метод ToString() вызывается неявно прямо на этой строке:
                Console.WriteLine(currentFigure); 
                Console.WriteLine(new string('=', 30));
            }
        }
    }
}