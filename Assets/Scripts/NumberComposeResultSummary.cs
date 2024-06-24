using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NumberComposeResultSummary : MonoBehaviour
{
    public Text resultText;
    public Text scoreText;

    void Start()
    {
        float numberComposePercentage = (float)NumberComposeGameManager.correctAnswersCount / NumberComposeGameManager.numberOfQuestionsToDisplay * 100f;


        if (numberComposePercentage >= 70f)
        {
            resultText.text = "Congratulations!";
        }
        else
        {
            resultText.text = "Better luck next time!";
        }

        scoreText.text = "Score: " + NumberComposeGameManager.correctAnswersCount + "/" + NumberComposeGameManager.numberOfQuestionsToDisplay;
    }
}
