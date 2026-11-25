using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject bounceLight;
    [SerializeField] private AudioSource hitStuffSound;

    public void AddBallForce(float amount)
    {
        rb.AddForce(transform.up * amount, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var peg = collision.gameObject.GetComponent<Peg>();
        if (peg != null)
        {
            peg.MarkPeg();
            hitStuffSound.Play();
        }
    }

    public void DestroyBall()
    {
        GameHandler.instance.SwitchGameState(2);
        Destroy(gameObject);
    }
}
