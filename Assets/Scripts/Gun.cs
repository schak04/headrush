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

    [Header("Recoil")]
    public float shakeIntensity = 0.1f;
    public float shakeDuration = 0.1f;

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
        StartCoroutine(Shake());

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

    System.Collections.IEnumerator Shake()
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeIntensity;
            float y = Random.Range(-1f, 1f) * shakeIntensity;

            transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}