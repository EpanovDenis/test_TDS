using UnityEngine;
using UnityEngine.UI;

public class SaveScore : MonoBehaviour
{
    public Text saveScore;
    private int bestScore;

    private void Awake()
    {
        bestScore = PlayerPrefs.GetInt("score");
    }

    private void Start()
    {
        if (bestScore > 0)
        {
            saveScore.text = "Best score: " + bestScore;
        }
        else
        {
            saveScore.text = "Best score: 0";
        }
    }
}
