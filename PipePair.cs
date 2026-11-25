namespace YMH219_FlappyBird;

public class PipePair
{
    public PictureBox TopPipe { get; }
    public PictureBox BottomPipe { get; }
    public bool Passed { get; set; }

    private readonly int gap;
    private readonly int groundY;

    public int Left => TopPipe.Left;
    public int Right => TopPipe.Right;

    public PipePair(int width, int gap, int groundY)
    {
        this.gap = gap;
        this.groundY = groundY;
        TopPipe = new PictureBox { Width = width, BackColor = Color.ForestGreen };
        BottomPipe = new PictureBox { Width = width, BackColor = Color.ForestGreen };
    }

    public void Place(int x, int gapTop)
    {
        TopPipe.SetBounds(x, 0, TopPipe.Width, gapTop);
        BottomPipe.SetBounds(x, gapTop + gap, BottomPipe.Width, groundY - (gapTop + gap));
        Passed = false;
    }

    public void Move(int speed)
    {
        TopPipe.Left -= speed;
        BottomPipe.Left -= speed;
    }

    public bool Hits(Rectangle r) =>
        r.IntersectsWith(TopPipe.Bounds) || r.IntersectsWith(BottomPipe.Bounds);
}