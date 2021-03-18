using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
    }

    public void StartGame()
    {
        GameRunning = true;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Game");
    }
}
