using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public PlayerScript playerScript;
    public void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (playerScript.playerMove.GearLeft < playerScript.playerMove.gears.Length - 1)
            {
                playerScript.playerMove.GearLeft++;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (playerScript.playerMove.GearLeft > 0)
            {
                playerScript.playerMove.GearLeft--;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (playerScript.playerMove.GearRight < playerScript.playerMove.gears.Length - 1)
            {
                playerScript.playerMove.GearRight++;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (playerScript.playerMove.GearRight > 0)
            {
                playerScript.playerMove.GearRight--;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerScript.playerShoot.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerScript.turret.RotateLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerScript.turret.RotateRight();
        }
    }
}
