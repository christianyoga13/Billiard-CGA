using UnityEngine;

public class PoolCueCollision : MonoBehaviour
{
    public GameObject white;
    public float forceMultiplier = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == white)
        {
            Vector3 direction = collision.contacts[0].point - transform.position;
            direction = direction.normalized;

            Rigidbody whiteBallRigidbody = white.GetComponent<Rigidbody>();
            whiteBallRigidbody.AddForce(direction * forceMultiplier, ForceMode.Impulse);
        }
    }
}