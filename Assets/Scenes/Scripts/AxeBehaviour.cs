using UnityEngine;

public class AxeBehaviour : MonoBehaviour
{
    Rigidbody rb;
    bool stuck = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!stuck)
        {
            stuck = true;

            // stop physics
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            rb.useGravity = false;
            rb.isKinematic = true;

            // stick into surface
            transform.position = collision.contacts[0].point;
            transform.parent = collision.transform;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ThrowAxe player = other.GetComponent<ThrowAxe>();

            if (player != null)
            {
                player.PickupAxe();
                Destroy(transform.root.gameObject);
            }
        }
    }
}