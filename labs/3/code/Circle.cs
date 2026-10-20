namespace Geometry;

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