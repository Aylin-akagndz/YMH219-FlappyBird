namespace YMH219_FlappyBird;

public class Bird
{
    private const double Gravity = 0.6;
    private const double FlapPower = -9;

    public PictureBox Box { get; }
    public double VelocityY { get; private set; }

    public Bird(PictureBox box)
    {
        Box = box;
    }

    public void Update()
    {
        VelocityY += Gravity;
        Box.Top += (int)VelocityY;
    }

    public void Flap() => VelocityY = FlapPower;

    public void Reset(int top)
    {
        Box.Top = top;
        VelocityY = 0;
    }
}