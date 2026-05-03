using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    void Start()
    {
        foreach (Transform t in spawnPoints)
        {
            Instantiate(enemyPrefab, t.position, Quaternion.identity);
        }
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Debug.Log("YOU WIN");
        }
    }
}