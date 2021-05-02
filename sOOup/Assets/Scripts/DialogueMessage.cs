using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMessage
{
    public string name { get; set; }
    public string dialogue { get; set; }
    public List<DialogueChoice> choices = new List<DialogueChoice>();
    public DialogueMessage next { get; set; }
    public System.Action endAction { get; set; } = null;
}

public sealed class DialogueChoice
{
    public string optionText { get; set; }
    public DialogueMessage next { get; set; }
}
