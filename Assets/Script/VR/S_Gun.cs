using UnityEngine;

public class S_Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    private GameObject lastFiredBullet;

    public void LaunchBullet()
    {
        lastFiredBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}