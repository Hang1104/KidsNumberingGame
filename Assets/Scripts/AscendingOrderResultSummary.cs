using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AscendingOrderResultSummary : MonoBehaviour
{
    public Text resultText;
    public Text scoreText;

    void Start()
    {
        float numberComparePercentage = (float)AscendingOrderGameManager.correctAnswersCount / AscendingOrderGameManager.numberOfQuestionsToDisplay * 100f;

        if (numberComparePercentage >= 70f)
        {
            resultText.text = "Congratulations!";
        }
        else
        {
            resultText.text = "Better luck next time!";
        }

        scoreText.text = "Score: " + AscendingOrderGameManager.correctAnswersCount + "/" + AscendingOrderGameManager.numberOfQuestionsToDisplay;
    }
}
