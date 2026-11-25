using UnityEngine;

public class BallBreakBarrier : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            ball.DestroyBall();
        }
    }
}
