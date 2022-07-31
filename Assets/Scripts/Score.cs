using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text currentScoreText;
    public Text youScoreText;
    public Text newBestScoreText;

    public static int currentScore;
    public static int newBestScore = 0;

    private void Start()
    {
        currentScore = 0;
        currentScoreText.text = "Score: " + currentScore.ToString();
        youScoreText.text = "You score: " + currentScore.ToString();
    }
        
    public void AddedScore(int score)
    {
        currentScore += score;
        currentScoreText.text = "Score: " + currentScore.ToString();
        youScoreText.text = "You score: " + currentScore.ToString();

        if (currentScore > newBestScore)
        {
            PlayerPrefs.SetInt("score", currentScore);
            newBestScore = currentScore;
            newBestScoreText.text = "New best score:" + newBestScore.ToString();
            youScoreText.gameObject.SetActive(false);
            newBestScoreText.gameObject.SetActive(true);            
        }
    }

    
}
