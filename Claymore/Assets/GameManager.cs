using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using static System.TimeZoneInfo;


public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] PlatformerPlayer player;
    public GameObject loadingScreen;
    public Slider slider;
    [SerializeField] float transitionTime;
    public Animator transition;


    public static int currentLevelIndex;

    void Start()
    {
        gameOverPanel.SetActive(false);

    }

    public void SetCurrentLevelIndex(int newLevelIndex)
    {
        currentLevelIndex = newLevelIndex;
    }

    public void RestartScen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        AsyncOperation operation = SceneManager.LoadSceneAsync("Main Menu");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void SavePlayer() 
    {
        SaveSystem.SavePlayer(player, currentLevelIndex);
        Debug.Log(currentLevelIndex);
        Debug.Log("Save");
    }

    public void LoadPlayer()
    {

        PlayerData data = SaveSystem.LoadPlayer();

        if (currentLevelIndex != data.currentLevelIndex)
        {
            RestartScen();
        }
        else
        {
        Vector2 position;
        position.x = data.currentPosition[0];
        position.y = data.currentPosition[1];
        player.transform.position = position;

        Debug.Log(position);
        Debug.Log(data.currentLevelIndex);
        Debug.Log("Load");
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(0);

        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);

    }
    private IEnumerator LoadLevelAndSetPlayerPosition(PlayerData data)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(data.currentLevelIndex);
        while (!operation.isDone)
        {
            yield return null;
        }

        PlatformerPlayer player = FindObjectOfType<PlatformerPlayer>();
        while (player == null)
        {
            yield return null;
            player = FindObjectOfType<PlatformerPlayer>();
        }

        Vector2 position;
        position.x = data.currentPosition[0];
        position.y = data.currentPosition[1];
        player.transform.position = position;

        Debug.Log(position);
        Debug.Log(data.currentLevelIndex);
        Debug.Log("Load");
    }
}