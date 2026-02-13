using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class S_ShatteredGlass : MonoBehaviour
{
    [Tooltip("The general direction the bullet is traveling.")]
    public Vector3 hitDirection = Vector3.forward;

    [Tooltip("The strength of the bullet impact.")]
    public float hitForce = 10f;

    [Tooltip("Adds random variation to the direction so the pieces separate.")]
    public float spread = 0.5f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        // Calculate a unique direction for this specific piece
        Vector3 randomOffset = Random.insideUnitSphere * spread;
        Vector3 finalDirection = (hitDirection + randomOffset).normalized;

        // Apply immediate physical impact (Impulse is best for sudden hits like bullets)
        rb.AddForce(finalDirection * hitForce, ForceMode.Impulse);

        // Add random tumbling spin
        rb.AddTorque(Random.insideUnitSphere * hitForce, ForceMode.Impulse);
    }
}