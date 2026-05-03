using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float dmg)
    {
        health -= dmg;

        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}