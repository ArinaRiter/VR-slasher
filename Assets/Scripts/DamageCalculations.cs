using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalculations : MonoBehaviour
{
    private PlayerStats stats;
    private NPCstats npcstats;
    private void Start()
    {
        if (TryGetComponent(out PlayerStats playerStats))
        {
            stats = playerStats;
        }
        else if (TryGetComponent(out NPCstats npcStats))
        {
            npcstats = npcStats;
        }
    }
    public void TakeDamage(int dmg)
    {
        if (stats != null)
        {
            stats.curHP -= dmg;
        }
        else if (npcstats != null)
        {

        }
    }
}
