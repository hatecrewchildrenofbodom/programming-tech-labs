using Geometry;
public class Program
{
    public static void Main()
    {
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
            if (!int.TryParse(choiceInput, out int choice) || choice < 0 || choice > 9)
            {
                Console.WriteLine("Пожалуйста, введите корректное число от 0 до 9.");
                continue;
            }

            if (choice == 0)
            {
                Console.WriteLine("Выход из программы...");
                break;
            }

            Console.Write("Имя фигуры: ");
            string name = Console.ReadLine() ?? "Без имени"; 

            // Ввод цвета с приведением к Enum
            Console.WriteLine("Доступные цвета: red, orange, yellow, green, blue, violet, black, white, grey, brown");
            Console.Write("Введите цвет из списка: ");
            string colourInput = Console.ReadLine() ?? "";

            // Пытаемся преобразовать строку в элемент Enum (игнорируя регистр букв)
            if (!Enum.TryParse(colourInput, true, out Figure.Colour chosenColour))
            {
                Console.WriteLine("Такого цвета нет в списке. Будет назначен цвет по умолчанию (red).");
                chosenColour = Figure.Colour.red;
            }

            Figure? currentFigure = null;

            switch (choice)
            {
                case 1:
                    Console.Write("Радиус: ");
                    double cRadius = Convert.ToDouble(Console.ReadLine());
                    currentFigure = new Circle(cRadius); 
                    break;

                case 2:
                    Console.Write("Больший радиус: ");
                    double eRadA = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Меньший радиус: ");
                    double eRadB = Convert.ToDouble(Console.ReadLine());
                    currentFigure = new Ellipse(eRadA, eRadB); 
                    break;

                case 3:
                    Console.Write("Радиус: ");
                    double rRadius = Convert.ToDouble(Console.ReadLine());
                    currentFigure = new Ring(rRadius); 
                    break;

                case 4:
                    Console.Write("Сторона A: ");
                    double pSideA = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Сторона B: ");
                    double pSideB = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Высота к стороне A: ");
                    double pHeight = Convert.ToDouble(Console.ReadLine());
                    currentFigure = new Parallelogram(pSideA, pSideB, pHeight);
                    break;

                case 5:
                    Console.Write("Сторона A (Ширина): ");
                    double rectA = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Сторона B (Высота): ");
                    double rectB = Convert.ToDouble(Console.ReadLine());
                    currentFigure = new Rectangle(rectA, rectB);
                    break;

                case 6:
                    Console.Write("Сторона: ");
                    double rhSide = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Высота: ");
                    double rhHeight = Convert.ToDouble(Console.ReadLine());
                    currentFigure = new Rhombus(rhSide, rhHeight);
                    break;

                case 7:
                    Console.Write("Количество углов (n): ");
                    int nAngles = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Длина стороны: ");
                    double nSide = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Радиус вписанной окружности: ");
                    double nRad = Convert.ToDouble(Console.ReadLine());
                    currentFigure = new NAngle(nAngles, nSide, nRad);
                    break;

                case 8:
                    Console.Write("Сторона: ");
                    double sqSide = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Радиус вписанной окружности: ");
                    double sqRad = Convert.ToDouble(Console.ReadLine());
                    currentFigure = new SquareFigure(sqSide, sqRad);
                    break;

                case 9:
                    Console.Write("Сторона: ");
                    double trSide = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Радиус вписанной окружности: ");
                    double trRad = Convert.ToDouble(Console.ReadLine());
                    currentFigure = new Triangle(trSide, trRad);
                    break;
            }

            if (currentFigure != null)
            {
                // Заполняем свойства геттерами/сеттерами
                currentFigure.Name = name;
                currentFigure.ObjectColour = chosenColour;

                // Выводим информацию о фигуре
                Console.WriteLine(currentFigure.ToString());
            }
        }
    }
}
