using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CompareNumberGameManager : MonoBehaviour
{
    public GameObject leftPanel;
    public GameObject rightPanel;
    public GameObject correctTick, wrongCross;
    public CompareNumberQuestionData[] allQuestions;
    public GameObject correctAnswersText;
    public GameObject resultSummaryPanel;

    private List<CompareNumberQuestionData> shuffledQuestions = new List<CompareNumberQuestionData>();
    private int currentQuestionIndex;
    public static int numberOfQuestionsToDisplay = 10;
    public static int correctAnswersCount;

    void Start()
    {
        correctAnswersCount = 0;
        ShuffleQuestions();
        DisplayNextQuestion();
    }

    void UpdateUI()
    {
        correctAnswersText.GetComponent<Text>().text = "" + correctAnswersCount;
    }

    void ShuffleQuestions()
    {
        shuffledQuestions.Clear();
        shuffledQuestions.AddRange(allQuestions);
        for (int i = shuffledQuestions.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            CompareNumberQuestionData temp = shuffledQuestions[i];
            shuffledQuestions[i] = shuffledQuestions[j];
            shuffledQuestions[j] = temp;
        }
        if (shuffledQuestions.Count > numberOfQuestionsToDisplay)
        {
            shuffledQuestions.RemoveRange(numberOfQuestionsToDisplay, shuffledQuestions.Count - numberOfQuestionsToDisplay);
        }
    }

    void DisplayNextQuestion()
    {
        if (currentQuestionIndex < shuffledQuestions.Count)
        {
            CompareNumberQuestionData currentQuestion = shuffledQuestions[currentQuestionIndex];

            Image leftPanelImage = leftPanel.GetComponent<Image>();
            Image rightPanelImage = rightPanel.GetComponent<Image>();

            leftPanelImage.sprite = currentQuestion.leftImage;
            rightPanelImage.sprite = currentQuestion.rightImage;

            Button correctButton = currentQuestion.correctAnswerButton;
            correctButton.onClick.RemoveAllListeners();
            correctButton.onClick.AddListener(() => CheckAnswer(correctButton));

        }
        else
        {
            ShowResultSummary();
        }
    }

    public void CheckAnswer(Button selectedButton)
    {
        CompareNumberQuestionData currentQuestion = shuffledQuestions[currentQuestionIndex];
        if (selectedButton == currentQuestion.correctAnswerButton)
        {
            Debug.Log("Correct!");
            correctAnswersCount++;
            UpdateUI();
            StartCoroutine(ActivateTickForOneSecond());

        }
        else
        {
            Debug.Log("Wrong!");
            StartCoroutine(ActivateCrossForOneSecond());
        }

        currentQuestionIndex++;
        DisplayNextQuestion();
    }

    System.Collections.IEnumerator ActivateTickForOneSecond()
    {
        correctTick.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        correctTick.gameObject.SetActive(false);
    }
    
    System.Collections.IEnumerator ActivateCrossForOneSecond()
    {
        wrongCross.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        wrongCross.gameObject.SetActive(false);
    }

    void ShowResultSummary()
    {
        // Activate result summary panel
        resultSummaryPanel.SetActive(true);
    }
}