namespace YMH219_FlappyBird;

public partial class Form1 : Form
{
    private const int GroundHeight = 60;
    private const int PipeWidth = 70;
    private const int Gap = 170;
    private const int PipeSpacing = 300;

    private readonly GameState state = new();
    private readonly List<PipePair> pipes = new();
    private readonly System.Windows.Forms.Timer gameTimer = new() { Interval = 20 };
    private readonly Random rnd = new();
    private readonly Label lblScore = new();
    private readonly Label lblInfo = new();
    private readonly PictureBox ground = new();
    private readonly Bird bird;

    private int GroundY => ClientSize.Height - GroundHeight;

    public Form1()
    {
        InitializeComponent();

        Text = "Flappy Bird - YMH219";
        ClientSize = new Size(800, 600);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        BackColor = Color.SkyBlue;
        KeyPreview = true;
        DoubleBuffered = true;

        for (int i = 0; i < 3; i++)
        {
            var p = new PipePair(PipeWidth, Gap, GroundY);
            pipes.Add(p);
            Controls.Add(p.TopPipe);
            Controls.Add(p.BottomPipe);
        }

        ground.SetBounds(0, GroundY, ClientSize.Width, GroundHeight);
        ground.BackColor = Color.SaddleBrown;
        Controls.Add(ground);

        var birdBox = new PictureBox { Size = new Size(40, 30), BackColor = Color.Gold };
        bird = new Bird(birdBox);
        Controls.Add(birdBox);

        lblScore.AutoSize = true;
        lblScore.Font = new Font("Segoe UI", 18, FontStyle.Bold);
        lblScore.BackColor = Color.Transparent;
        lblScore.Location = new Point(10, 10);
        Controls.Add(lblScore);

        lblInfo.AutoSize = true;
        lblInfo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
        lblInfo.BackColor = Color.Transparent;
        lblInfo.TextAlign = ContentAlignment.MiddleCenter;
        Controls.Add(lblInfo);

        lblScore.BringToFront();
        lblInfo.BringToFront();

        gameTimer.Tick += GameLoop;
        KeyDown += Form1_KeyDown;

        ResetGame();
    }

    private void ResetGame()
    {
        state.Reset();
        bird.Reset(ClientSize.Height / 2 - 15);
        bird.Box.Left = 150;

        int x = ClientSize.Width;
        foreach (var p in pipes)
        {
            p.Place(x, rnd.Next(80, GroundY - Gap - 80));
            x += PipeSpacing;
        }

        gameTimer.Stop();
        UpdateLabels();
        ShowInfo("SPACE ile başla");
    }

    private void Form1_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space)
        {
            if (state.IsGameOver) return;
            if (!state.IsRunning)
            {
                state.IsRunning = true;
                lblInfo.Visible = false;
                gameTimer.Start();
            }
            bird.Flap();
        }
        else if (e.KeyCode == Keys.R)
        {
            ResetGame();
        }
    }

    private void GameLoop(object? sender, EventArgs e)
    {
        bird.Update();

        foreach (var p in pipes)
        {
            p.Move(state.Speed);

            if (p.Right < 0)
            {
                int farthest = pipes.Max(x => x.Left);
                p.Place(farthest + PipeSpacing, rnd.Next(80, GroundY - Gap - 80));
            }

            if (!p.Passed && p.Right < bird.Box.Left)
            {
                p.Passed = true;
                state.AddPoint();
            }

            if (p.Hits(bird.Box.Bounds))
            {
                EndGame();
                return;
            }
        }

        if (bird.Box.Bottom >= GroundY || bird.Box.Top <= 0)
        {
            EndGame();
            return;
        }

        UpdateLabels();
    }

    private void EndGame()
    {
        gameTimer.Stop();
        state.GameOver();
        UpdateLabels();
        ShowInfo("GAME OVER\nYeniden başlatmak için R");
    }

    private void UpdateLabels() =>
        lblScore.Text = $"Skor: {state.Score}   En Yüksek: {state.HighScore}   Hız: {state.Speed}";

    private void ShowInfo(string text)
    {
        lblInfo.Text = text;
        lblInfo.Location = new Point(
            (ClientSize.Width - lblInfo.Width) / 2,
            ClientSize.Height / 2 - 80);
        lblInfo.Visible = true;
        lblInfo.BringToFront();
    }
}