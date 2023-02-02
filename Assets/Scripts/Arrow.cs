using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side
{
    Left,
    Right
}

public class Arrow : MonoBehaviour
{
    public int gear;
    public Side side;
    public PlayerScript playerScript;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }
    void Update()
    {
        if (side == Side.Left)
        {
            if (playerScript.playerMove.GearLeft == gear || (gear > 0 && gear < playerScript.playerMove.GearLeft))
            {
                spriteRenderer.enabled = true;
            }
            else
            {
                spriteRenderer.enabled = false;
            }
        }
        else if (side == Side.Right)
        {
            if (playerScript.playerMove.GearRight == gear || (gear > 0 && gear < playerScript.playerMove.GearRight))
            {
                spriteRenderer.enabled = true;
            }
            else
            {
                spriteRenderer.enabled = false;
            }
        }
    }
}
