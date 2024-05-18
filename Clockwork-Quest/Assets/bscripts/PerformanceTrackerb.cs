using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceTrackerb : MonoBehaviour
{
       public int enemiesKilled = 0;
       public int damageTaken = 0;
       public float levelCompletionTime = 0f;
   
       private void Update()
       {
           // Bölüm süresini takip et
           levelCompletionTime += Time.deltaTime;
       }
   
       public void RecordEnemyKill()
       {
           enemiesKilled++;
       }
   
       public void RecordDamageTaken(int damage)
       {
           damageTaken += damage;
       }
   
       public void Reset()
       {
           enemiesKilled = 0;
           damageTaken = 0;
           levelCompletionTime = 0f;
       }
}
