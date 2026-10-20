namespace Geometry;

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
        return 2 * (side_a + side_b);
    }

    public override double? Square()
    {
        return height_a * side_a;
    }
}