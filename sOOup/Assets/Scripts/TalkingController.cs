using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkingController : MonoBehaviour
{
    public DialogueMessage topMessage;
    public Text nameTxtBox;
    public Text dialogueTextBox;
    public GameObject nameBox;
    public GameObject dialogueBox;
    public List<Button> choiceButtons;
    public List<Text> choiceButtonsText;
    public bool canStartDialogue = false;
    public bool dialogueOpen = false;
    public bool choicesOpen = false;
    public bool isDone = false;

    private WinController wc;
    private bool lastClick = false;
    private DialogueMessage nextMessage;

    void Start()
    {
        // this reads easier if you start from the bottom and go up.
        // If you want to do this somewhere else copy and paste the script and redo this part I'm not making it modular.
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
        topMessage = new DialogueMessage() { name = "Skipper", dialogue = "do you have time to listen to soup?", next = msg1 };
        nextMessage = topMessage;

        wc = FindObjectOfType<WinController>();

        nameBox.SetActive(false);
        nameTxtBox.gameObject.SetActive(false);
        dialogueBox.SetActive(false);
        dialogueTextBox.gameObject.SetActive(false);
        foreach (Button button in choiceButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (wc == null)
        {
            wc = FindObjectOfType<WinController>();
        }

        if (!wc.isAnimating)
        {
            bool click = Input.GetKey(KeyCode.Mouse0);
            if (canStartDialogue && !choicesOpen && !isDone && click && lastClick != click)
            {
                if (!dialogueOpen)
                {
                    nameBox.SetActive(true);
                    nameTxtBox.gameObject.SetActive(true);
                    dialogueBox.SetActive(true);
                    dialogueTextBox.gameObject.SetActive(true);
                    foreach (Button button in choiceButtons)
                    {
                        button.gameObject.SetActive(false);
                    }
                    dialogueOpen = true;
                    FindObjectOfType<Player_SideScroll>().canMove = false;
                }

                PrintDialogueToString();
            }
            lastClick = click;
        }
    }

    public void SpeechCheckPass()
    {
        dialogueOpen = false;
        isDone = true;
        wc.SetWin();
    }

    public void SpeechCheckFail()
    {
        dialogueOpen = false;
        isDone = true;
        wc.SetLose();
    }

    public void ClickOption(int optionNumber)
    {
        // change dialogue
        choicesOpen = false;
        nextMessage = nextMessage.choices[optionNumber].next;
        foreach (Button button in choiceButtons)
        {
            button.gameObject.SetActive(false);
        }
        PrintDialogueToString();
    }

    private void PrintDialogueToString()
    {
        // print dialogue
        nameTxtBox.text = nextMessage.name;
        dialogueTextBox.text = nextMessage.dialogue;

        // print choices if there are any and stop advancement
        if (nextMessage.choices != null && nextMessage.choices.Count > 0)
        {
            // enable choices and top advance
            choicesOpen = true;
            for (int i = 0; i < nextMessage.choices.Count; i++)
            {
                choiceButtons[i].gameObject.SetActive(true);
                choiceButtonsText[i].text = nextMessage.choices[i].optionText;
            }
        }
        else if (nextMessage.next != null)
        {
            // advance cursor.
            choicesOpen = false;
            nextMessage = nextMessage.next;
        }
        else if (nextMessage.endAction != null)
        {
            nextMessage.endAction();
        }
        else
        {
            //you fucked up if you are here.
        }
    }
}
