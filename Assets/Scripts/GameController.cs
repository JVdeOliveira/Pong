using System;
using System.Diagnostics;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField] 
    private Ball ball;
    private int[] playerScoreArray;

    public event EventHandler<ScoredChangedEventArgs> ScoredChanged;
    public class ScoredChangedEventArgs : EventArgs
    {
        public Side sideThatScored;
        public int score;

        public ScoredChangedEventArgs(Side sideThatScored, int score)
        {
            this.sideThatScored = sideThatScored;
            this.score = score;
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        playerScoreArray = new int[2];

        ball.MadePoint += Ball_MadePoint;
    }

    private void Ball_MadePoint(object sender, Ball.BallEventArgs e)
    {
        Side sideThatScored;

        if (e.exitBallSide == Side.Left)
        {
            sideThatScored = Side.Right;
        }
        else
        {
            sideThatScored = Side.Left;
        }

        AddScore(sideThatScored);
    }

    private void AddScore(Side sideThatScored)
    {
        int playerPointIndex = (int)sideThatScored;

        playerScoreArray[playerPointIndex]++;
        ScoredChanged?.Invoke(this, new ScoredChangedEventArgs(sideThatScored, playerScoreArray[playerPointIndex]));
    }
}
