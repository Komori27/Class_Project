using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    [SerializeField] float transitionTime;
    public Collider2D levelChangeCollider;
    private bool changeLevel = false;

    void Start()
    {
        levelChangeCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (changeLevel)
        {
            Debug.Log("LvLchange");
            LoadNextLevel();
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
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int levelIndex) 
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
