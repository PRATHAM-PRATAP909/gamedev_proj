using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public Camera fpsCam;
    public float range = 100f;
    public CameraShake cameraShake;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Click Detected");
            Shoot();
        }
    }

    void Shoot()
    {
        // Trigger camera shake
        if (cameraShake != null)
        {
            cameraShake.Shake(0.08f);
        }

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);

            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(1);
                Debug.Log("Enemy Took Damage");
            }
        }
        else
        {
            Debug.Log("Nothing Hit");
        }
    }
}