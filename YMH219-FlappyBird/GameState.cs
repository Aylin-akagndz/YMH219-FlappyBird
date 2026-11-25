namespace YMH219_FlappyBird;

public class GameState
{
    public int Score { get; private set; }
    public int HighScore { get; private set; }
    public int Speed { get; private set; } = 5;
    public bool IsRunning { get; set; }
    public bool IsGameOver { get; private set; }

    public void AddPoint()
    {
        Score++;
        if (Score > HighScore) HighScore = Score;
        if (Score % 5 == 0) Speed++;
    }

    public void GameOver()
    {

        IsRunning = false;
        IsGameOver = true;
    }

    public void Reset()
    {
        Score = 0;
        Speed = 5;
        IsRunning = false;
        IsGameOver = false;
    }
}
