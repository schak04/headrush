using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 25f;
    public float range = 100f;
    public PlayerHealth playerHealth;
    public LayerMask ignoreLayer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, range, ~ignoreLayer))
        {
            if (hit.collider.CompareTag("Head"))
            {
                hit.collider.GetComponentInParent<EnemyHealth>().TakeDamage(damage * 2);
                playerHealth.Heal(10);
                Debug.Log("HEADSHOT!");
            }
            else if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<EnemyHealth>().TakeDamage(damage);
                Debug.Log("Body Hit");
            }
        }
    }
}