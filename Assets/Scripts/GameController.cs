using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField] 
    private Ball ball;
    private int[] playerScoreArray;

    public event EventHandler<ScoredChandedEventArgs> OnScoredChanded;
    public class ScoredChandedEventArgs : EventArgs
    {
        public Side sideThatScored;
        public int score;

        public ScoredChandedEventArgs(Side sideThatScored, int score)
        {
            this.sideThatScored = sideThatScored;
            this.score = score;
        }
    }

    private void Awake()
    {
        Instance = this;
        playerScoreArray = new int[2];

        ball.OnMadePoint += Ball_OnMadePoint;
    }

    private void Ball_OnMadePoint(object sender, Ball.BallEventArgs e)
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
        OnScoredChanded?.Invoke(this, new ScoredChandedEventArgs(sideThatScored, playerScoreArray[playerPointIndex]));
    }
}
