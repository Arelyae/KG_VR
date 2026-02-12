using UnityEngine;

public class S_Collide : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject enemy;

    [SerializeField] private string tagPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagPlayer))
        {
            Destroy(other.gameObject);
            Destroy(enemy);
        }
    }
}