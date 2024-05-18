using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICommentatorb : MonoBehaviour
{
    public PerformanceTrackerb performanceTracker;

    public string GetComment()
    {
        if (performanceTracker.enemiesKilled > 10 && performanceTracker.damageTaken < 5)
        {
            return "Mükemmel bir performans! Çok az hasar alarak birçok düşman öldürdünüz.";
        }
        else if (performanceTracker.enemiesKilled < 5 && performanceTracker.damageTaken > 20)
        {
            return "Bu bölümde zorlandınız. Daha dikkatli olmalısınız.";
        }
        else
        {
            return "Orta seviyede bir performans sergilediniz. İyi iş çıkardınız!";
        }
    }
}
