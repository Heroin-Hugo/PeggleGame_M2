using UnityEngine;

public class Peg : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject destroyParticle;
    [SerializeField] private bool markedForDestruction = false;
    [SerializeField] private GameObject markedForDestructionIndicator;

    public void MarkPeg()
    {
        markedForDestructionIndicator.SetActive(true);
        markedForDestruction = true;
        GameHandler.instance.AddPegToList(this);
    }

    public void BreakPeg()
    {
        Instantiate(destroyParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
