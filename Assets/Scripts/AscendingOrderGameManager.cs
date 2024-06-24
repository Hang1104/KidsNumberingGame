using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AscendingOrderGameManager : MonoBehaviour
{
    public Text instructionText;
    public GameObject numberButtonPrefab;
    public GameObject dropZonePrefab;
    public Transform buttonParent;
    public Transform dropZoneParent;
    public GameObject resultSummaryPanel;
    public Text resultText;
    public GameObject correctAnswersText;
    public GameObject correctTick, wrongCross;

    private List<int> numbers;
    private List<Button> numberButtons;
    private List<GameObject> dropZones;
    private int buttonsClickedQ1 = 0;
    private int buttonsClickedQ2 = 0;
    private int buttonsClickedQ3 = 0;
    private int buttonsClickedQ4 = 0;
    private int currentQuestionIndex;
    public static int numberOfQuestionsToDisplay = 4;
    public static int correctAnswersCount;


    void Start()
    {
        correctAnswersCount = 0;
        instructionText.text = "Order the numbers from smallest to largest.";

        Question1();
    }

    void UpdateUI()
    {
        correctAnswersText.GetComponent<Text>().text = "" + correctAnswersCount;
    }

    void Question1()
    {
        currentQuestionIndex = 1;
       
        numbers = GenerateRandomNumbersQ1();
        CreateNumberButtonsQ1();
        CreateDropZonesQ1();

        foreach (GameObject dropZone in dropZones)
        {
            dropZone.GetComponent<Button>().onClick.AddListener(() => OnDropZoneClick(dropZone));
        }
    }
    
    void Question2()
    {
        currentQuestionIndex = 2;
        ClearDropZones();
        numbers = GenerateRandomNumbersQ2();
        CreateNumberButtonsQ2();
        CreateDropZonesQ2();

        foreach (GameObject dropZone in dropZones)
        {
            dropZone.GetComponent<Button>().onClick.AddListener(() => OnDropZoneClick(dropZone));
        }
    }
    
    void Question3()
    {
        currentQuestionIndex = 3;
        ClearDropZones();
        numbers = GenerateRandomNumbersQ3();
        CreateNumberButtonsQ3();
        CreateDropZonesQ3();

        foreach (GameObject dropZone in dropZones)
        {
            dropZone.GetComponent<Button>().onClick.AddListener(() => OnDropZoneClick(dropZone));
        }
    }

    void Question4()
    {
        currentQuestionIndex = 4;
        ClearDropZones();
        numbers = GenerateRandomNumbers();
        CreateNumberButtons();
        CreateDropZones();

        foreach (GameObject dropZone in dropZones)
        {
            dropZone.GetComponent<Button>().onClick.AddListener(() => OnDropZoneClick(dropZone));
        }
    }

    void CreateNumberButtons()
    {
        numberButtons = new List<Button>();
        int numRows = 3;
        int numColumns = 3;

        RectTransform panelRect = buttonParent.GetComponent<RectTransform>();
        float cellWidth = panelRect.rect.width / numColumns;
        float cellHeight = panelRect.rect.height / numRows;

        List<int> randomNumbers = GenerateRandomNumbers();

        int index = 0; 
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numColumns; col++)
            {
                float xPos = (col + 0.5f) * cellWidth - panelRect.rect.width / 2f;
                float yPos = (row + 0.5f) * cellHeight - panelRect.rect.height / 2f;
                Vector3 position = new Vector3(xPos, yPos, buttonParent.position.z);

                int number = randomNumbers[index++];

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

    void CreateNumberButtonsQ1()
    {
        numberButtons = new List<Button>();
        int numRows = 2;
        int numColumns = 2;

        RectTransform panelRect = buttonParent.GetComponent<RectTransform>();
        float cellWidth = panelRect.rect.width / numColumns;
        float cellHeight = panelRect.rect.height / numRows;

        List<int> randomNumbers = GenerateRandomNumbersQ1();

        int index = 0; 

        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numColumns; col++)
            {
                float xPos = (col + 0.5f) * cellWidth - panelRect.rect.width / 2f;
                float yPos = (row + 0.5f) * cellHeight - panelRect.rect.height / 2f;
                Vector3 position = new Vector3(xPos, yPos, buttonParent.position.z);

                int number = randomNumbers[index++];

                GameObject buttonGO = Instantiate(numberButtonPrefab, buttonParent);

                RectTransform buttonRect = buttonGO.GetComponent<RectTransform>();
                buttonRect.anchoredPosition = position;

                Text buttonText = buttonGO.GetComponentInChildren<Text>();
                buttonText.text = number.ToString();

                Button button = buttonGO.GetComponent<Button>();
                numberButtons.Add(button);

                int numberCopy = number; 
                button.onClick.AddListener(() => OnButtonClickQ1(numberCopy));
            }
        }
    }

    void CreateNumberButtonsQ2()
    {
        numberButtons = new List<Button>();
        int numRows = 2;
        int numColumns = 2;

        RectTransform panelRect = buttonParent.GetComponent<RectTransform>();
        float cellWidth = panelRect.rect.width / numColumns;
        float cellHeight = panelRect.rect.height / numRows;

        List<int> randomNumbers = GenerateRandomNumbersQ2();

        int index = 0; 

        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numColumns; col++)
            {
                float xPos = (col + 0.5f) * cellWidth - panelRect.rect.width / 2f;
                float yPos = (row + 0.5f) * cellHeight - panelRect.rect.height / 2f;
                Vector3 position = new Vector3(xPos, yPos, buttonParent.position.z);

                int number = randomNumbers[index++];

                GameObject buttonGO = Instantiate(numberButtonPrefab, buttonParent);

                RectTransform buttonRect = buttonGO.GetComponent<RectTransform>();
                buttonRect.anchoredPosition = position;

                Text buttonText = buttonGO.GetComponentInChildren<Text>();
                buttonText.text = number.ToString();

                Button button = buttonGO.GetComponent<Button>();
                numberButtons.Add(button);

                int numberCopy = number;
                button.onClick.AddListener(() => OnButtonClickQ2(numberCopy));
            }
        }
    }

    void CreateNumberButtonsQ3()
    {
        numberButtons = new List<Button>();
        int numRows = 2;
        int numColumns = 2;

        RectTransform panelRect = buttonParent.GetComponent<RectTransform>();
        float cellWidth = panelRect.rect.width / numColumns;
        float cellHeight = panelRect.rect.height / numRows;

        List<int> randomNumbers = GenerateRandomNumbersQ3();

        int index = 0; 

        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numColumns; col++)
            {
                float xPos = (col + 0.5f) * cellWidth - panelRect.rect.width / 2f;
                float yPos = (row + 0.5f) * cellHeight - panelRect.rect.height / 2f;
                Vector3 position = new Vector3(xPos, yPos, buttonParent.position.z);

                int number = randomNumbers[index++];

                GameObject buttonGO = Instantiate(numberButtonPrefab, buttonParent);

                RectTransform buttonRect = buttonGO.GetComponent<RectTransform>();
                buttonRect.anchoredPosition = position;

                Text buttonText = buttonGO.GetComponentInChildren<Text>();
                buttonText.text = number.ToString();

                Button button = buttonGO.GetComponent<Button>();
                numberButtons.Add(button);

                int numberCopy = number;
                button.onClick.AddListener(() => OnButtonClickQ3(numberCopy));
            }
        }
    }

    List<int> GenerateRandomNumbers()
    {
        List<int> nums = new List<int>();
        for (int i = 1; i <= 9; i++)
        {
            nums.Add(i);
        }

        for (int i = nums.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            int temp = nums[i];
            nums[i] = nums[randomIndex];
            nums[randomIndex] = temp;
        }

        return nums;
    }

    List<int> GenerateRandomNumbersQ1()
    {
        List<int> nums = new List<int>();
        for (int i = 1; i <= 4; i++)
        {
            nums.Add(i);
        }

        for (int i = nums.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            int temp = nums[i];
            nums[i] = nums[randomIndex];
            nums[randomIndex] = temp;
        }

        return nums;
    }
    
    List<int> GenerateRandomNumbersQ2()
    {
        List<int> nums = new List<int>();
        for (int i = 4; i <= 7; i++)
        {
            nums.Add(i);
        }

        for (int i = nums.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            int temp = nums[i];
            nums[i] = nums[randomIndex];
            nums[randomIndex] = temp;
        }

        return nums;
    }
    
    List<int> GenerateRandomNumbersQ3()
    {
        List<int> nums = new List<int>();
        for (int i = 6; i <= 9; i++)
        {
            nums.Add(i);
        }

        for (int i = nums.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            int temp = nums[i];
            nums[i] = nums[randomIndex];
            nums[randomIndex] = temp;
        }

        return nums;
    }

    void CreateDropZones()
    {
        dropZones = new List<GameObject>();

        int numDropZones = 9; 
        float spacing = 10f; 

        RectTransform dropZonePrefabRect = dropZonePrefab.GetComponent<RectTransform>();
        float prefabWidth = dropZonePrefabRect.rect.width;

        RectTransform dropZoneParentRect = dropZoneParent.GetComponent<RectTransform>();
        float totalWidth = numDropZones * prefabWidth + (numDropZones - 1) * spacing; 

        float startXPos = -totalWidth / 2f + prefabWidth / 2f;

        for (int i = 0; i < numDropZones; i++)
        {
            float xPos = startXPos + i * (prefabWidth + spacing);
            float yPos = 0f; // Assuming drop zones are aligned horizontally
            Vector3 position = new Vector3(xPos, yPos, dropZoneParent.position.z);

            GameObject dropZoneGO = Instantiate(dropZonePrefab, dropZoneParent);
            RectTransform dropZoneRect = dropZoneGO.GetComponent<RectTransform>();
            dropZoneRect.sizeDelta = new Vector2(prefabWidth, dropZoneRect.sizeDelta.y); 
            dropZoneRect.anchoredPosition = position;

            dropZones.Add(dropZoneGO);
        }
    }


    void CreateDropZonesQ1()
    {
        dropZones = new List<GameObject>();

        int numDropZones = 4; 
        float spacing = 10f; 

        RectTransform dropZonePrefabRect = dropZonePrefab.GetComponent<RectTransform>();
        float prefabWidth = dropZonePrefabRect.rect.width;

        RectTransform dropZoneParentRect = dropZoneParent.GetComponent<RectTransform>();
        float totalWidth = numDropZones * prefabWidth + (numDropZones - 1) * spacing; 

        float startXPos = -totalWidth / 2f + prefabWidth / 2f;

        for (int i = 0; i < numDropZones; i++)
        {
            float xPos = startXPos + i * (prefabWidth + spacing);
            float yPos = 0f; 
            Vector3 position = new Vector3(xPos, yPos, dropZoneParent.position.z);

            GameObject dropZoneGO = Instantiate(dropZonePrefab, dropZoneParent);
            RectTransform dropZoneRect = dropZoneGO.GetComponent<RectTransform>();
            dropZoneRect.sizeDelta = new Vector2(prefabWidth, dropZoneRect.sizeDelta.y); 
            dropZoneRect.anchoredPosition = position;

            dropZones.Add(dropZoneGO);

            dropZoneGO.GetComponent<Button>().onClick.AddListener(() => OnDropZoneClick(dropZoneGO));
        }
    }

    void CreateDropZonesQ2()
    {
        dropZones = new List<GameObject>();

        int numDropZones = 4; 
        float spacing = 10f; 

        RectTransform dropZonePrefabRect = dropZonePrefab.GetComponent<RectTransform>();
        float prefabWidth = dropZonePrefabRect.rect.width;

        RectTransform dropZoneParentRect = dropZoneParent.GetComponent<RectTransform>();
        float totalWidth = numDropZones * prefabWidth + (numDropZones - 1) * spacing; 

        float startXPos = -totalWidth / 2f + prefabWidth / 2f;

        for (int i = 0; i < numDropZones; i++)
        {
            float xPos = startXPos + i * (prefabWidth + spacing);
            float yPos = 0f; 
            Vector3 position = new Vector3(xPos, yPos, dropZoneParent.position.z);

            GameObject dropZoneGO = Instantiate(dropZonePrefab, dropZoneParent);
            RectTransform dropZoneRect = dropZoneGO.GetComponent<RectTransform>();
            dropZoneRect.sizeDelta = new Vector2(prefabWidth, dropZoneRect.sizeDelta.y);
            dropZoneRect.anchoredPosition = position;

            dropZones.Add(dropZoneGO);

            dropZoneGO.GetComponent<Button>().onClick.AddListener(() => OnDropZoneClick(dropZoneGO));
        }
    }

    void CreateDropZonesQ3()
    {
        dropZones = new List<GameObject>();

        int numDropZones = 4; 
        float spacing = 10f; 

        RectTransform dropZonePrefabRect = dropZonePrefab.GetComponent<RectTransform>();
        float prefabWidth = dropZonePrefabRect.rect.width;

        RectTransform dropZoneParentRect = dropZoneParent.GetComponent<RectTransform>();
        float totalWidth = numDropZones * prefabWidth + (numDropZones - 1) * spacing; 

        float startXPos = -totalWidth / 2f + prefabWidth / 2f;

        for (int i = 0; i < numDropZones; i++)
        {
            float xPos = startXPos + i * (prefabWidth + spacing);
            float yPos = 0f; 
            Vector3 position = new Vector3(xPos, yPos, dropZoneParent.position.z);

            GameObject dropZoneGO = Instantiate(dropZonePrefab, dropZoneParent);
            RectTransform dropZoneRect = dropZoneGO.GetComponent<RectTransform>();
            dropZoneRect.sizeDelta = new Vector2(prefabWidth, dropZoneRect.sizeDelta.y); 
            dropZoneRect.anchoredPosition = position;

            dropZones.Add(dropZoneGO);

            dropZoneGO.GetComponent<Button>().onClick.AddListener(() => OnDropZoneClick(dropZoneGO));
        }
    }

    void OnButtonClick(int number)
    {
        foreach (GameObject dropZone in dropZones)
        {
            Text dropZoneText = dropZone.GetComponentInChildren<Text>();
            if (dropZoneText.text == "")
            {
                dropZoneText.text = number.ToString();
                buttonsClickedQ4++; 
                break; 
            }
        }

        Button clickedButtonQ4 = numberButtons.Find(btn => btn.GetComponentInChildren<Text>().text == number.ToString());
        clickedButtonQ4.gameObject.SetActive(false);

        if (buttonsClickedQ4 == 9)
        {
            bool correctSequence = true;
            for (int i = 0; i < dropZones.Count; i++)
            {
                Text dropZoneText = dropZones[i].GetComponentInChildren<Text>();
                if (dropZoneText.text != (i + 1).ToString())
                {
                    correctSequence = false;
                    break; 
                }
            }

            if (correctSequence)
            {
                correctAnswersCount++;
                UpdateUI();
                StartCoroutine(ActivateTickForOneSecond());
                ShowResultSummary();
            }
            else
            {
                StartCoroutine(ActivateCrossForOneSecond());
            }

            
        }
    }

    void OnButtonClickQ1(int number)
    {
        foreach (GameObject dropZone in dropZones)
        {
            Text dropZoneText = dropZone.GetComponentInChildren<Text>();
            if (dropZoneText.text == "")
            {
                dropZoneText.text = number.ToString();
                buttonsClickedQ1++; 
                break; 
            }
        }

        Button clickedButtonQ1 = numberButtons.Find(btn => btn.GetComponentInChildren<Text>().text == number.ToString());
        clickedButtonQ1.gameObject.SetActive(false);

        if (buttonsClickedQ1 == 4)
        {
            bool correctSequence = true;
            for (int i = 0; i < dropZones.Count; i++)
            {
                Text dropZoneText = dropZones[i].GetComponentInChildren<Text>();
                if (dropZoneText.text != (i + 1).ToString())
                {
                    correctSequence = false;
                    break; 
                }
            }

            if (correctSequence)
            {
                correctAnswersCount++;
                UpdateUI();
                Question2();
                StartCoroutine(ActivateTickForOneSecond());
            }
            else
            {
                StartCoroutine(ActivateCrossForOneSecond());
            }
        }
    }

    void OnButtonClickQ2(int number)
    {
        foreach (GameObject dropZone in dropZones)
        {
            Text dropZoneText = dropZone.GetComponentInChildren<Text>();
            if (dropZoneText.text == "")
            {
                dropZoneText.text = number.ToString();
                buttonsClickedQ2++; 
                break; 
            }
        }

        Button clickedButtonQ2 = numberButtons.Find(btn => btn.GetComponentInChildren<Text>().text == number.ToString());
        clickedButtonQ2.gameObject.SetActive(false);

        if (buttonsClickedQ2 == 4)
        {
            bool correctSequence = true;
            for (int i = 4; i <= 7; i++)
            {
                Text dropZoneText = dropZones[i-4].GetComponentInChildren<Text>();
                if (dropZoneText.text != i.ToString())
                {
                    correctSequence = false;
                    break; 
                }
            }

            if (correctSequence)
            {
                correctAnswersCount++;
                UpdateUI();
                Question3();
                StartCoroutine(ActivateTickForOneSecond());
            }
            else
            {
                StartCoroutine(ActivateCrossForOneSecond());
            }
        }
    }

    void OnButtonClickQ3(int number)
    {
        foreach (GameObject dropZone in dropZones)
        {
            Text dropZoneText = dropZone.GetComponentInChildren<Text>();
            if (dropZoneText.text == "")
            {
                dropZoneText.text = number.ToString();
                buttonsClickedQ3++; 
                break;
            }
        }

        Button clickedButtonQ3 = numberButtons.Find(btn => btn.GetComponentInChildren<Text>().text == number.ToString());
        clickedButtonQ3.gameObject.SetActive(false);

        if (buttonsClickedQ3 == 4)
        {
            bool correctSequence = true;
            for (int i = 0; i < dropZones.Count; i++)
            {
                Text dropZoneText = dropZones[i].GetComponentInChildren<Text>();
                int expectedNumber = i + 6;
                if (dropZoneText.text != expectedNumber.ToString())
                {
                    correctSequence = false;
                    break; 
                }
            }

            if (correctSequence)
            {
                correctAnswersCount++;
                UpdateUI();
                Question4();
                StartCoroutine(ActivateTickForOneSecond());
            }
            else
            {
                StartCoroutine(ActivateCrossForOneSecond());
            }
        }
    }

    void ClearDropZones()
    {
        foreach (GameObject dropZone in dropZones)
        {
            Destroy(dropZone); 
        }
        dropZones.Clear(); 
    }

    void ShowResultSummary()
    {
        resultSummaryPanel.SetActive(true);
    }

    void OnDropZoneClick(GameObject dropZone)
    {
        Text dropZoneText = dropZone.GetComponentInChildren<Text>();
        if (!string.IsNullOrEmpty(dropZoneText.text))
        {
            int number = int.Parse(dropZoneText.text);
            Button correspondingButton = numberButtons.Find(btn => btn.GetComponentInChildren<Text>().text == number.ToString());
            correspondingButton.gameObject.SetActive(true);

            dropZoneText.text = "";

            if (currentQuestionIndex == 1)
                buttonsClickedQ1--;
            if (currentQuestionIndex == 2)
                buttonsClickedQ2--;
            if (currentQuestionIndex == 3)
                buttonsClickedQ3--;
            else if (currentQuestionIndex == 4)
                buttonsClickedQ4--;
        }
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
}