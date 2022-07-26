using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    public static bool gameOver = false;

    private void Awake()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);        
    }

    private void Update()
    {
        if (gameOver == true)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        gameOver = false;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }       

    public void RestartSceneButton()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
        Time.timeScale = 1;
    }
}
