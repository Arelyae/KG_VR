using System.Collections;
using UnityEngine;

public class S_Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform parentGun;

    private Coroutine returnPos = null;

    public void LaunchBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        bullet.GetComponent<S_Bullet>().Initialized("Player");
    }

    public void ReturnPos()
    {
        if (returnPos != null)
        {
            StopCoroutine(returnPos);
            returnPos = null;
        }

        returnPos = StartCoroutine(ReturnPosCoroutine());
    }

    private IEnumerator ReturnPosCoroutine()
    {
        yield return new WaitForSeconds(0.05f);

        transform.SetParent(parentGun);

        transform.position = parentGun.position;
        transform.rotation = parentGun.rotation;
    }
}