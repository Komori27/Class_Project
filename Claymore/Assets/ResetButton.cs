using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    private Button resetButton;

    void Start()
    {
        resetButton = GetComponent<Button>();
        resetButton.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
