using UnityEngine;

public class ThrowAxe : MonoBehaviour
{
    public GameObject axePrefab;
    public Transform throwPoint;
    public float throwForce = 20f;

    bool hasAxe = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && hasAxe)
        {
            Throw();
        }
    }

    void Throw()
    {
        Debug.Log("Axe Thrown");
        GameObject axe = Instantiate(axePrefab, throwPoint.position, throwPoint.rotation);

        Rigidbody rb = axe.GetComponent<Rigidbody>();
        rb.AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);

        hasAxe = false;
    }

    public void PickupAxe()
    {
        hasAxe = true;
    }
}
