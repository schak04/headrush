using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    public Color hitColor = Color.red;

    private Renderer[] renderers;
    private Color[] originalColors;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        originalColors = new Color[renderers.Length];
        
        for (int i = 0; i < renderers.Length; i++)
        {
            originalColors[i] = renderers[i].material.color;
        }
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (renderers.Length > 0) StartCoroutine(HitFlash());

        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }

    System.Collections.IEnumerator HitFlash()
    {
        foreach (Renderer r in renderers) r.material.color = hitColor;
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = originalColors[i];
        }
    }
}