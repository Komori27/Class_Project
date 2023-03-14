using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject gameOverPanel;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void RestartScen()
    {
        SceneManager.LoadScene("Lvl1");
        Debug.Log("Restart");
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}