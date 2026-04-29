using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float attackRange = 2f;
    public float damage = 10f;
    public float attackCooldown = 1f;

    float nextAttack;
    NavMeshAgent agent;
    PlayerHealth playerHealth;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        agent.SetDestination(player.position);

        float dist = Vector3.Distance(transform.position, player.position);

        if (dist <= attackRange && Time.time > nextAttack)
        {
            playerHealth.TakeDamage(damage);
            nextAttack = Time.time + attackCooldown;
        }
    }
}