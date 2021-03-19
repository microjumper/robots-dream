using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Path path;

    public Text scoreText;
    private int score;

    public bool GameRunning { get; private set;}

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
    }

    void Start()
    {
        GameRunning = false;

        score = 0;
        scoreText.text = $"Score: {score}";
    }

    public void StartGame()
    {
        GameRunning = true;

        path.StartBuilding();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void AddPoint()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
}
