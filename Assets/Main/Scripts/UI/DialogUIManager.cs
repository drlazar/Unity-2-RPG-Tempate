using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogUIManager : MonoBehaviour
{
    public GameObject background;
    public GameObject mainText;
    public GameObject responseTab;
    public GameObject continueText;
    public List<Button> responsesHolder;

    [SerializeField]
    private int currentIndex = 0;
    [SerializeField]
    private int responses = 0;

    private DialogueBranch branch;

    // Start is called before the first frame update
    void Start()
    {
        DeactiveDialogue();
    }

    public void ActiveDialogue()
    {
        background.SetActive(true);
        mainText.SetActive(true);
        continueText.SetActive(true);
        responseTab.SetActive(true);
        foreach (Button response in responsesHolder)
        {
            response.gameObject.SetActive(false);
        }
    }

    public void DeactiveDialogue()
    {
        background.SetActive(false);
        mainText.SetActive(false);
        continueText.SetActive(false);
        responseTab.SetActive(false);
        foreach (Button response in responsesHolder)
        {
            response.gameObject.SetActive(false);
        }
    }

    public void NextBranch(int branchSelect)
    {
        RecieveDialogueBranch(branch.responseOption[branchSelect].nextBranch);
        ActiveDialogue();
        NextDialogue();
    }

    
    public void RecieveDialogueBranch(DialogueBranch newBranch)
    {
        this.branch = newBranch;
        responses = Mathf.Clamp(branch.responseOption.Count, 0, 3);
        currentIndex = 0;

    }

    public void NextDialogue()
    {
        if (currentIndex >= branch.dialogueLines.Count)
        {
            //No response -> End Dialogue
            if (responses == 0)
            {
                DeactiveDialogue();
            }
            else
            {
                continueText.SetActive(false);
                for (int i = 0; i < responses; i++)
                {
                    if (i >= 3)
                    {
                        break;
                    }

                    responsesHolder[i].gameObject.SetActive(true);
                    responsesHolder[i].GetComponentInChildren<TextMeshProUGUI>().text = branch.responseOption[i].text;
                }
            }
        }
        else
        {
            mainText.GetComponent<TextMeshProUGUI>().text = branch.dialogueLines[currentIndex];
            continueText.SetActive(true);
            currentIndex++;
        }

    }
}
