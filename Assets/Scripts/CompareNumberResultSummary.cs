using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CompareNumberResultSummary : MonoBehaviour
{
    public Text resultText;
    public Text scoreText;

    void Start()
    {
       
        float numberComparePercentage = (float)CompareNumberGameManager.correctAnswersCount / CompareNumberGameManager.numberOfQuestionsToDisplay * 100f;
        
        if (numberComparePercentage >= 70f)
        {
            resultText.text = "Congratulations!";
        }
        else
        {
            resultText.text = "Better luck next time!";
        }
       
        scoreText.text = "Score: " + CompareNumberGameManager.correctAnswersCount + "/" + CompareNumberGameManager.numberOfQuestionsToDisplay;
    }
}
