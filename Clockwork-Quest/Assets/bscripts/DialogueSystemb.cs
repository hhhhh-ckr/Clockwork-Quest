using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystemb : MonoBehaviour
{
    public Text dialogueText;
    public AICommentatorb aiCommentator;

    public void ShowEndOfLevelDialogue()
    {
        string comment = aiCommentator.GetComment();
        dialogueText.text = comment;
        // Diyalog kutusunu göstermek için gerekli diğer işlemler
    }
}
