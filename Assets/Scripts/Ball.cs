using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private readonly float speed = 10;

    public event EventHandler<BallEventArgs> MadePoint;
    public class BallEventArgs : EventArgs
    {
        public Side exitBallSide;

        public BallEventArgs(Side exitBallSide)
        {
            this.exitBallSide = exitBallSide;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StarMove(delay: 1.5f);
    }

    private IEnumerator StartMoveCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

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

    public void StarMove(float delay)
    {
        StartCoroutine(StartMoveCoroutine(delay));
    }

    private void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;

        StarMove(delay: 1.5f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Side exitBallSide = SideSystem.GetSide(transform.position.x);
        MadePoint?.Invoke(this, new BallEventArgs(exitBallSide));

        ResetBall();
    }
}
