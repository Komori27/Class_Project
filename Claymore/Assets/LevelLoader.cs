using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    [SerializeField] float transitionTime;
    public Collider2D levelChangeCollider;
    private bool changeLevel = false;
    public GameObject loadingScreen;
    public Slider slider;
    GameManager gameManager;



    void Start()
    {
        levelChangeCollider = GetComponent<Collider2D>();
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.SetCurrentLevelIndex(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (changeLevel)
        {
            Debug.Log("LvLchange");
            //LoadNextLevel();
            LoadMainMenu();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.CompareTag("Player"))
       {
            changeLevel = true;
       }
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().buildIndex + 1));
        int newLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        gameManager.SetCurrentLevelIndex(newLevelIndex);
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int levelIndex) 
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        
    }

    IEnumerator LoadAsynchronously(int levelIndex) 
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);

        loadingScreen.SetActive(true);

        while(!operation.isDone) 
        {

            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
