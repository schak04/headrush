using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    bool isGameOver = false;

    void Start()
    {
        foreach (Transform t in spawnPoints)
        {
            Instantiate(enemyPrefab, t.position, Quaternion.identity);
        }
    }

    void Update()
    {
        if (isGameOver) return;

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            isGameOver = true;
            Debug.Log("VICTORY ACHIEVED! ALL ENEMIES SLAUGHTERED!");
        }
    }
}