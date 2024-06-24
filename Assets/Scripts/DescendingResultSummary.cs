using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DescendingResultSummary : MonoBehaviour
{
    public Text resultText;
    public Text scoreText;

    void Start()
    {
        // Calculate the percentage of correct answers
        float numberComparePercentage = (float)DescendingOrderGameManager.correctAnswersCount / DescendingOrderGameManager.numberOfQuestionsToDisplay * 100f;

        // Display the result text based on the percentage
        if (numberComparePercentage >= 70f)
        {
            resultText.text = "Congratulations!";
        }
        else
        {
            resultText.text = "Better luck next time!";
        }

        scoreText.text = "Score: " + DescendingOrderGameManager.correctAnswersCount + "/" + DescendingOrderGameManager.numberOfQuestionsToDisplay;
    }
}
