using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkingController : MonoBehaviour
{
    public DialogueMessage topMessage;
    public Text nameTxtBox;
    public Text dialogueTextBox;
    public GameObject choicec1;
    public GameObject choicec2;

    private WinController wc;

    void Start()
    {
        // this reads easier if you start from the bottom and go up.
        DialogueMessage failMsg = new DialogueMessage() { name = "Neighborhood Man", dialogue = "fook off", endAction = SpeechCheckFail };
        DialogueMessage passMsg = new DialogueMessage() { name = "Neighborhood Man", dialogue = "I'll take 50 cans.", endAction = SpeechCheckPass };

        DialogueMessage msg6_2 = new DialogueMessage() { name = "Neighborhood Man", dialogue = "Oh that makes sense.", next = passMsg };
        DialogueMessage msg6_1 = new DialogueMessage() { name = "Skipper", dialogue = "It's very good for dipping and complements starches as a side.", next = msg6_2 };
        DialogueMessage msg5_4 = new DialogueMessage() { name = "Skipper", dialogue = "I'm going to force feed you it.", next = failMsg };
        DialogueMessage msg5_3 = new DialogueMessage() { name = "Neighborhood Man", dialogue = "I'm not too sure about this.", next = msg5_4 };
        DialogueMessage msg5_2 = new DialogueMessage() { name = "Neighborhood Man", dialogue = "*sips soup*", next = msg5_3 };
        DialogueMessage msg5_1 = new DialogueMessage() { name = "Skipper", dialogue = "Here, give it a taste, it will change your mind.", next = msg5_2 };
        DialogueChoice ch2_2 = new DialogueChoice() { optionText = "Explain yourself", next = msg6_1 };
        DialogueChoice ch2_1 = new DialogueChoice() { optionText = "Give a sample", next = msg5_1 };
        DialogueMessage msg4 = new DialogueMessage() { name = "Neighborhood Man", dialogue = "That sounds disgusting." };
        msg4.choices.Add(ch2_1);
        msg4.choices.Add(ch2_2);
        DialogueMessage msg3_1 = new DialogueMessage() { name = "Skipper", dialogue = "I have a new flavor of soup here. It's called spicy nacho cheese.", next = msg4 };
        DialogueMessage msg2_1 = new DialogueMessage() { name = "Skipper", dialogue = "How I shove this soup can up your ass.", next = failMsg };
        DialogueChoice ch1_2 = new DialogueChoice() { optionText = "Be gentle", next = msg3_1 };
        DialogueChoice ch1_1 = new DialogueChoice() { optionText = "Be aggressive", next = msg2_1 };
        DialogueMessage msg1 = new DialogueMessage() { name = "Neighborhood Man", dialogue = "What do you mean? Are you selling me something?" };
        msg1.choices.Add(ch1_1);
        msg1.choices.Add(ch1_2);
        topMessage = new DialogueMessage() { name = "Skipper", dialogue = "do you have time to listen to soup?" };

        wc = FindObjectOfType<WinController>();
    }

    void Update()
    {
        if (wc == null)
        {
            wc = FindObjectOfType<WinController>();
        }
    }

    public void SpeechCheckPass()
    {

    }

    public void SpeechCheckFail()
    {

    }
}
