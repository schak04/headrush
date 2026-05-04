using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    public Color hitColor = Color.red;

    private Renderer rend;
    private Color originalColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (rend != null) StartCoroutine(HitFlash());

        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }

    System.Collections.IEnumerator HitFlash()
    {
        rend.material.color = hitColor;
        yield return new WaitForSeconds(0.1f);
        rend.material.color = originalColor;
    }
}