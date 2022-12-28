using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public enum Type
    {
        Player,
        Machine
    }

    private const float MAX_Y_POSITION = 4f;

    [SerializeField] 
    private Type playerType;
    private Side side;

    private readonly float speed = 5f;
    Transform ball;

    private void Awake()
    {
        side = UtilClass.GetSide(transform.position.x);
        ball = FindObjectOfType<Ball>().transform;
    }

    private void Update()
    {
        switch (playerType)
        {
            case Type.Player: PlayerMove(); break;
            case Type.Machine: MachineMove(); break;
        }

        ClampPosition();
    }

    private void PlayerMove()
    {
        float verticalInput = 0f;

        switch (side)
        {
            case Side.Right: verticalInput = Input.GetAxisRaw("VerticalLeft"); break;
            case Side.Left: verticalInput = Input.GetAxisRaw("VerticalRight"); break;
        }

        Move(verticalInput);
    }

    private void MachineMove()
    {
        float targetYDirection = ball.position.y - transform.position.y;

        Move(targetYDirection);
    }

    private void Move(float verticalDirection)
    {
        transform.position += Time.deltaTime * verticalDirection * speed * Vector3.up;
    }

    private void ClampPosition()
    {
        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, -MAX_Y_POSITION, MAX_Y_POSITION);
        transform.position = position;
    }
}
