using UnityEngine;

public class S_Bullet : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed = 80f;
    [SerializeField] private float maxLifetime = 2.0f;

    private void Start()
    {
        Destroy(gameObject, maxLifetime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}