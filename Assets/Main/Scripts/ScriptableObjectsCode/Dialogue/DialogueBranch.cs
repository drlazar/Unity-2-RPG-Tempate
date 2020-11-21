using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Branch", menuName = "CustomObject/Branch")]
public class DialogueBranch : ScriptableObject
{
    public string dialogueID = "";
    public List<string> dialogueLines;
    public List<ResponseBranch> responseOption;
}

[System.Serializable]
public class ResponseBranch
{
    public string text;
    public DialogueBranch nextBranch;
}
