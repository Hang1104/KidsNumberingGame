using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class NumberComposeGameManager : MonoBehaviour
{

    public Button wholeNumberButton;
    public GameObject correctTick, wrongCross;
    public GameObject correctAnswersText;
    public GameObject resultSummaryPanel;
    public Transform dropZoneParent;


    public Transform buttonParent;
    public GameObject numberButtonPrefab;
    private int currentQuestionIndex;
    public static int numberOfQuestionsToDisplay = 10;
    public static int correctAnswersCount;
    private List<Button> numberButtons;
    private int buttonsClicked = 0;


    void Start()
    {
        correctAnswersCount = 0;
        currentQuestionIndex = 0;
        CreateNumberButtons();
        GenerateRandomNumber();
    }

    void UpdateUI()
    {
        correctAnswersText.GetComponent<Text>().text = "" + correctAnswersCount;
    }


    void CreateNumberButtons()
    {
        numberButtons = new List<Button>();
        int numRows = 3;
        int numColumns = 3;

        RectTransform panelRect = buttonParent.GetComponent<RectTransform>();
        float cellWidth = panelRect.rect.width / numColumns;
        float cellHeight = panelRect.rect.height / numRows;

        int[,] numbers = new int[,]
        {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numColumns; col++)
            {
                float xPos = (col + 0.5f) * cellWidth - panelRect.rect.width / 2f;
                float yPos = (row + 0.5f) * cellHeight - panelRect.rect.height / 2f;
                Vector3 position = new Vector3(xPos, yPos, buttonParent.position.z);

                int number = numbers[row, col];

                GameObject buttonGO = Instantiate(numberButtonPrefab, buttonParent);
                RectTransform buttonRect = buttonGO.GetComponent<RectTransform>();
                buttonRect.anchoredPosition = position;

                Text buttonText = buttonGO.GetComponentInChildren<Text>();
                buttonText.text = number.ToString();

                Button button = buttonGO.GetComponent<Button>();
                numberButtons.Add(button);

                int numberCopy = number;
                button.onClick.AddListener(() => OnButtonClick(numberCopy));
            }
        }
    }

    void GenerateRandomNumber()
    {
        int randomNumber = Random.Range(2, 10);
        wholeNumberButton.GetComponentInChildren<Text>().text = randomNumber.ToString();
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

    void OnButtonClick(int number)
    {
        foreach (Transform dropZone in dropZoneParent)
        {
            Text dropZoneText = dropZone.GetComponentInChildren<Text>();
            if (dropZoneText.text == "")
            {
                dropZoneText.text = number.ToString();
                buttonsClicked++;
                break;
            }
        }

        if (buttonsClicked == 2)
        {
            bool validCombination = IsValidCombination();

            if (validCombination)
            {
                correctAnswersCount++;
                UpdateUI();
                StartCoroutine(ActivateTickForOneSecond());
            }
            else
            {
                StartCoroutine(ActivateCrossForOneSecond());
            }

            ResetDropZones();
            currentQuestionIndex++;

            if (currentQuestionIndex < numberOfQuestionsToDisplay)
            {
                GenerateRandomNumber();
                buttonsClicked = 0;
            }
            else
            {
                ShowResultSummary();
            }
        }
    }

    bool IsValidCombination()
    {
        int[] numbers = new int[2];
        int index = 0;

        foreach (Transform dropZone in dropZoneParent)
        {
            Text dropZoneText = dropZone.GetComponentInChildren<Text>();
            if (!int.TryParse(dropZoneText.text, out numbers[index]))
            {
                Debug.LogError("Invalid input in drop zone");
                return false;
            }
            index++;
        }

        int wholeNumber = int.Parse(wholeNumberButton.GetComponentInChildren<Text>().text);
        int sum = numbers[0] + numbers[1];
        return sum == wholeNumber;
    }

    void ResetDropZones()
    {
        foreach (Transform dropZone in dropZoneParent)
        {
            Text dropZoneText = dropZone.GetComponentInChildren<Text>();
            dropZoneText.text = ""; 
        }
    }

    void ShowResultSummary()
    {
        resultSummaryPanel.SetActive(true);
    }
}
