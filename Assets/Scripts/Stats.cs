using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stats
{
    public class Stats
    {
        public int lvl = 1;
        public float HP;
        public float MP;
        public float EXP = 1000;
        public int vitality = 20;
        public int STR = 20;
        public int energy = 20;
        public int minATKweapon = 10;
        public int maxATKweapon = 10;
        public int damage = 10; /// /////////////////////
        public int minDMG;
        public int maxDMG;

        public Stats()
        {
            this.newdmg();
            this.newhp();
            this.newmp();
        }
        public Stats(int lvl, float EXP, int STR, int vitality, int energy)
        {
            this.lvl = lvl;
            this.EXP = EXP;
            this.STR = STR;
            this.energy = energy;
            this.vitality = vitality;
            this.newhp();
            this.newmp();
            this.newdmg();
            this.vitality = vitality;
        }
        public void lvlUP()
        {
            this.lvl += 1;
            this.EXP += Mathf.Floor(this.EXP / 2.5f);
        }
        public void newdmg()
        {
            this.minDMG = minATKweapon * (this.STR + 100) / 100;
            this.maxDMG = maxATKweapon * (this.STR + 100) / 100;
        }
        public void newhp()
        {
            this.HP = Mathf.Floor(this.vitality * 3.6f);
        }
        public void newmp()
        {
            this.MP = Mathf.Floor(this.energy * 1.1f);
        }
    }
}


