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
    public enum Side
    {
        Right,
        Left
    }

    private const float MAX_Y_POSITION = 4f;
    private const float SPEED = 5f;

    [SerializeField] 
    private Type playerType;
    private Side side;

    private void Awake()
    {
        SetSide();
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
            case Side.Left:  verticalInput = Input.GetAxisRaw("VerticalRight"); break;
        }

        transform.position += Time.deltaTime * verticalInput * SPEED * Vector3.up;
    }

    private void MachineMove()
    {

    }

    private void ClampPosition()
    {
        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, -MAX_Y_POSITION, MAX_Y_POSITION);
        transform.position = position;
    }

    private void SetSide()
    {
        bool isRight = transform.position.x > 0;

        side = isRight ? Side.Right : Side.Left;
    }
}
