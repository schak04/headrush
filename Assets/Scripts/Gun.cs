using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 25f;
    public float range = 100f;
    public PlayerHealth playerHealth;
    public LayerMask ignoreLayer;

    [Header("Juice")]
    public Light muzzleFlash;
    public AudioSource gunSound;
    public float flashDuration = 0.05f;

    void Start()
    {
        if (muzzleFlash != null) muzzleFlash.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (gunSound != null) gunSound.Play();
        if (muzzleFlash != null) StartCoroutine(Flash());

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

    System.Collections.IEnumerator Flash()
    {
        muzzleFlash.enabled = true;
        yield return new WaitForSeconds(flashDuration);
        muzzleFlash.enabled = false;
    }
}