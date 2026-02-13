using UnityEngine;

public class S_GunManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject gun;

    [Header("Inputs")]
    [SerializeField] private RSE_OnDisplayGun rseOnDisplayGun;

    private void OnEnable()
    {
        rseOnDisplayGun.Action += DisplayGun;
    }

    private void DisplayGun(bool val)
    {
        gun.SetActive(val);
    }
}