using UnityEngine;
using System;

public class ShootBall : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float shootForce;
    [SerializeField] private Transform firePoint;
    [Space]
    public bool canShoot = true;

    [Header("Juice")]
    [SerializeField] private AudioSource shootSound;

    private void Update()
    {
        if (canShoot && Input.GetKeyDown(KeyCode.Mouse0)) Shoot();
    }

    private void Shoot()
    {
        GameHandler.instance.SwitchGameState(1);
        shootSound.Play();


        Ball ballScript = Instantiate(bullet, firePoint.position, firePoint.rotation).GetComponent<Ball>();
        if (ballScript != null)
        {
            ballScript.AddBallForce(shootForce);
        }
    }
}
