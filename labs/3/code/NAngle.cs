namespace Geometry;

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