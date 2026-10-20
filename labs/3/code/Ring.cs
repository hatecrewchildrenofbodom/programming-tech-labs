namespace Geometry;

public class Ring : Circle  // Кольцо
{
    public Ring(double radius) : base(radius) { }   // Конструктор Ring

    public override double? Square()
    {
        return null;
    }
}