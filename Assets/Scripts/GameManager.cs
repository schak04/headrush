using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    public enum GameState { Playing, Won, Lost }
    public GameState currentState = GameState.Playing;

    void Start()
    {
        foreach (Transform t in spawnPoints)
        {
            Instantiate(enemyPrefab, t.position, Quaternion.identity);
        }
    }

    void Update()
    {
        if (currentState != GameState.Playing) return;

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            EndGame(GameState.Won);
        }
    }

    public void EndGame(GameState state)
    {
        currentState = state;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    void OnGUI()
    {
        if (currentState == GameState.Playing) return;

        string message = currentState == GameState.Won ? "VICTORY ACHIEVED!" : "YOU DIED...";
        GUIStyle style = new GUIStyle();
        style.fontSize = 50;
        style.normal.textColor = Color.white;
        style.alignment = TextAnchor.MiddleCenter;

        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), message, style);

        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 50, 100, 40), "Restart"))
        {
            Time.timeScale = 1f;
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}