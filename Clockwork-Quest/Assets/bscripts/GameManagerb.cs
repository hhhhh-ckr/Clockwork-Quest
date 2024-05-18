using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerb : MonoBehaviour
{
    public PerformanceTrackerb performanceTracker;
    public AICommentatorb aiCommentator;
    public DialogueSystemb dialogueSystem;

    private void EndLevel()
    {
        // Performans verilerini al ve AI yorumunu göster
        dialogueSystem.ShowEndOfLevelDialogue();
        // Performans verilerini sıfırla
        performanceTracker.Reset();
    }
}
