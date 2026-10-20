namespace Geometry;

public class Ellipse : Circle   // Эллипс
{
    private double radius_1; // Меньший радиус

    public Ellipse(double radius, double radius_1) : base(radius)   // Конструктор Ellipse
    {
        this.radius_1 = radius_1;
    }

    public override double Perimeter()
    {
        return 2 * Math.PI * Math.Sqrt((Math.Pow(radius, 2) + Math.Pow(radius_1, 2)) / 2);    // Формула Эйлера
    }
    public override double? Square()
    {
        return Math.PI * radius * radius_1;   // Площадь эллипса
    }
}