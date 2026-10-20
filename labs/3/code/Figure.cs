namespace Geometry;

public abstract class Figure    // Фигура
{
    
    public string Name { get; set; }
    public Colour ObjectColour { get; set; } 

        public enum Colour
    {
        red,
        orange,
        yellow,
        green,
        blue,
        violet,
        black,
        white,
        grey,
        brown
    }
    
    public abstract double Perimeter();
    public abstract double? Square();

    public override string ToString()
    {
        return $@"
        Фигура:  {Name}
        Цвет:    {ObjectColour}
        Периметр: {Perimeter():F2}
        Площадь:  {(Square() != null ? Square().Value.ToString("F2") : "Не применимо")}";
    }
}