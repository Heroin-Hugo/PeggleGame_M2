using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    Vector3 mousePosition;
    [SerializeField] private Camera mainCam;

    void Update()
    {
        mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePosition - transform.position;

        transform.up = direction;
    }
}
