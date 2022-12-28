using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private readonly float speed = 10;

    public event EventHandler<BallEventArgs> OnMadePoint;
    public class BallEventArgs : EventArgs
    {
        public Side exitBallSide;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Invoke(nameof(StartMove), 1.5f);
    }

    public void StartMove()
    {
        List<Vector2> directionList = new()
        {
            new Vector2(1, 1).normalized,
            new Vector2(1, -1).normalized,
            new Vector2(-1, -1).normalized,
            new Vector2(-1, 1).normalized
        };

        int directionIndex = UnityEngine.Random.Range(0, directionList.Count);

        rb.velocity = directionList[directionIndex] * speed;
    }

    private void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;

        Invoke(nameof(StartMove), 1.5f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Side exitBallSide = UtilClass.GetSide(transform.position.x);
        OnMadePoint?.Invoke(this, new BallEventArgs { exitBallSide = exitBallSide });

        ResetBall();
    }
}
