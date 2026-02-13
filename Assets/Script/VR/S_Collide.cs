using UnityEngine;
using UnityEngine.Events;

public class S_Collide : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject enemy;

    [SerializeField] private string tagPlayer;

    public UnityEvent OnObjectDestroyed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagPlayer))
        {
            OnObjectDestroyed.Invoke();
            Destroy(other.gameObject);
            Destroy(enemy);
        }
    }
}