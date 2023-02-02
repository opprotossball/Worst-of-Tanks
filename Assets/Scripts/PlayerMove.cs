using UnityEngine;
using System;
public class PlayerMove : MonoBehaviour
{
    public PlayerScript playerScript;
    internal float[] gears = new float[5]{ -1f, 0f, 1f, 1.25f, 1.5f };
    private AudioManager audioManager;
    private int gearLeft;
    private int gearRight;
    private string[] sounds = new string[]{ "", "TracksSlow", "TracksMedium", "TracksFast" };
    private Rigidbody2D rb;
    public int GearRight
    {
        get { return gearRight; }
        set
        {
            gearRight = value;
            PlayTrackSound();
        }
    }
    public int GearLeft
    {
        get { return gearLeft; }
        set
        {
            gearLeft = value;
            PlayTrackSound();
        }
    }
    private void PlayTrackSound()
    {
        for (int i = 1; i < 4; i++)
        {
            if (Math.Max(Math.Abs(GearLeft - 1), Math.Abs(GearRight - 1)) == i || !FindObjectOfType<AudioManager>().IsPlaying(sounds[i]))
            {
                FindObjectOfType<AudioManager>().Play(sounds[i]);
            }
            else
            {
                FindObjectOfType<AudioManager>().Stop(sounds[i]);
            }
        }
    }
    void Awake()
    {
        gearLeft = 1;
        gearRight = 1;
        rb = GetComponent<Rigidbody2D>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void OnFixedUpdate()
    {
        Vector2 localVelocity = rb.transform.InverseTransformDirection(rb.velocity);
        rb.AddRelativeForce(new Vector2(0, -Math.Sign(localVelocity.y) * (float)Math.Pow(localVelocity.y, 2) / 3));
        rb.AddRelativeForce(new Vector2(0, gears[gearLeft] + gears[gearRight]));
        rb.AddTorque((gears[gearRight] - gears[gearLeft]) / 5);
    }
}
