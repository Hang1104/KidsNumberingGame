using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class ComposeNumberQuestionData
{
    public Sprite wholeNumberImage;
    public List<ButtonPair> correctAnswerButtons;
}


[System.Serializable]
public class ButtonPair
{
    public Button button1;
    public Button button2;
}

