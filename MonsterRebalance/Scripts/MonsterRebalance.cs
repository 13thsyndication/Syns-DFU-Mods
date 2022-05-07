// Project:         MonsterRebalance mod for Daggerfall Unity (http://www.dfworkshop.net)
// Copyright:       Copyright (C) 2022 13thSyndicate
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)
// Author:          Hazelnut & Ralzar & 13thSyndicate

using DaggerfallWorkshop;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Utility.ModSupport;
using DaggerfallWorkshop.Utility;
using UnityEngine;

namespace MonsterRebalance
{
    public class MonsterRebalance : MonoBehaviour
    {
        static Mod mod;

        [Invoke(StateManager.StateTypes.Start, 0)]
        public static void Init(InitParams initParams)
        {
            mod = initParams.Mod;
            var go = new GameObject(mod.Title);
            go.AddComponent<MonsterRebalance>();
        }
        void Awake()
        {
            InitMod();

            mod.IsReady = true;
        }

        private static void InitMod()
        {
            Debug.Log("Begin mod init: MonsterRebalance");

            //Iterate over the new mob enemy data array and load into DFU enemies data.
            foreach (EnemyData mobData in mobEnemyDataArray)
            {
                // Log a message indicating the enemy mob being updated.
                Debug.LogFormat("Updating enemy data for {0}.", EnemyBasics.Enemies[mobData.ID]);
                //Debug.LogFormat("Updating enemy data for {0}.", EnemyBasics.Enemies[mobData.ID].Name);

                if (mobData.Level != -1)
                    EnemyBasics.Enemies[mobData.ID].Level = mobData.Level;
                //if (mobData.Name != "")
                //    EnemyBasics.Enemies[mobData.ID].Name = mobData.Name;
                if (mobData.MinHp != -1)
                    EnemyBasics.Enemies[mobData.ID].MinHealth = mobData.MinHp;
                if (mobData.MaxHp != -1)
                    EnemyBasics.Enemies[mobData.ID].MaxHealth = mobData.MaxHp;
                if (mobData.Armor != -1)
                    EnemyBasics.Enemies[mobData.ID].ArmorValue = mobData.Armor;
                if (mobData.MinDmg != -1)
                    EnemyBasics.Enemies[mobData.ID].MinDamage = mobData.MinDmg;
                if (mobData.MaxDmg != -1)
                    EnemyBasics.Enemies[mobData.ID].MaxDamage = mobData.MaxDmg;
                if (mobData.MinDmg2 != -1)
                    EnemyBasics.Enemies[mobData.ID].MinDamage2 = mobData.MinDmg2;
                if (mobData.MaxDmg2 != -1)
                    EnemyBasics.Enemies[mobData.ID].MaxDamage2 = mobData.MaxDmg2;
                if (mobData.MinDmg3 != -1)
                    EnemyBasics.Enemies[mobData.ID].MinDamage3 = mobData.MinDmg3;
                if (mobData.MaxDmg3 != -1)
                    EnemyBasics.Enemies[mobData.ID].MaxDamage3 = mobData.MaxDmg3;
                if (mobData.MoveSnd != -1)
                    EnemyBasics.Enemies[mobData.ID].MoveSound = mobData.MoveSnd;
                if (mobData.BarkSnd != -1)
                    EnemyBasics.Enemies[mobData.ID].BarkSound = mobData.BarkSnd;
                if (mobData.AttackSnd != -1)
                    EnemyBasics.Enemies[mobData.ID].AttackSound = mobData.AttackSnd;
                if (mobData.CorpseTex != -1)
                    EnemyBasics.Enemies[mobData.ID].CorpseTexture = mobData.CorpseTex;
                if (mobData.MinMetalToHit != -1)
                    EnemyBasics.Enemies[mobData.ID].MinMetalToHit = mobData.MinMetalToHit;
            }

            Debug.Log("Finished mod init: MonsterRebalance");
        }

        public static int CorpseTexture(int archive, int record)
        {
            return ((archive << 16) + record);
        }

        private class EnemyData
        {
            public int ID { get { return id; } }          // ID of this mobile
            public string Name { get { return name; } }     // Monster Name
            public int Level { get { return level; } }       // Monster Level
            public int MinHp { get { return minHp; } }       // Minimum health
            public int MaxHp { get { return maxHp; } }       // Maximum health
            public int Armor { get { return armor; } }       // Armor value
            public int MinDmg { get { return minDmg; } }      // Minimum damage per first hit of attack
            public int MaxDmg { get { return maxDmg; } }      // Maximum damage per first hit of attack
            public int MinDmg2 { get { return minDmg2; } }     // Minimum damage per second hit of attack
            public int MaxDmg2 { get { return maxDmg2; } }     // Maximum damage per second hit of attack
            public int MinDmg3 { get { return minDmg3; } }     // Minimum damage per third hit of attack
            public int MaxDmg3 { get { return maxDmg3; } }     // Maximum damage per third hit of attack
            public int MoveSnd { get { return moveSnd; } }     // Movement sound file
            public int BarkSnd { get { return barkSnd; } }     // Bark sound file
            public int AttackSnd { get { return attackSnd; } }   // Attack sound file
            public int CorpseTex { get { return corpseTex; } }  // Monster Corpse texture
            public int MinMetalToHit { get { return minMetalToHit; } } // Minimum weapon type needed to hit monster

            private readonly int id, level, minHp, maxHp, armor;
            private readonly string name;
            private readonly int minDmg, maxDmg, minDmg2, maxDmg2, minDmg3, maxDmg3;
            private readonly int moveSnd, barkSnd, attackSnd, corpseTex;
            private readonly int minMetalToHit;

            public EnemyData(int id = -1, string name = "", int level = -1, int minHp = -1, int maxHp = -1, int armor = -1,
                            int minDmg = -1, int maxDmg = -1, int minDmg2 = -1, int maxDmg2 = -1, int minDmg3 = -1, int maxDmg3 = -1,
                            int moveSnd = -1, int barkSnd = -1, int attackSnd = -1, int corpseTex = -1, int minMetalToHit = -1)
            {
                this.id = id;
                this.name = name;
                this.level = level;
                this.minHp = minHp;
                this.maxHp = maxHp;
                this.armor = armor;
                this.minDmg = minDmg;
                this.maxDmg = maxDmg;
                this.minDmg2 = minDmg2;
                this.maxDmg2 = maxDmg2;
                this.minDmg3 = minDmg3;
                this.maxDmg3 = maxDmg3;
                this.moveSnd = moveSnd;
                this.barkSnd = barkSnd;
                this.attackSnd = attackSnd;
                this.corpseTex = corpseTex;
                this.minMetalToHit = minMetalToHit;
            }

        }

        private static EnemyData[] mobEnemyDataArray = new EnemyData[]
        {                                     
            new EnemyData
            (   // Giant Bat
                id: 3,
                minDmg: 1, maxDmg: 4,
                minHp: 5, maxHp: 15,                                                              
                //moveSnd: (int)SoundClips.EnemyGiantMove  // <- example of setting a level and a sound clip.
            ),
            (   // Harpy
                id: 13,
                minMetalToHit: WeaponMaterialTypes.Silver,
            ),
            new EnemyData
            (   // Zombie
                id: 17,
                minDmg: 1, maxDmg: 5,
            ),
            new EnemyData
            (   //Gargoyle
                id: 22,
                minMetalToHit: WeaponMaterialTypes.Dwarven,
            ),
            new EnemyData
            (   //Frost Daedra
                id: 25,
                minDmg: 15, maxDmg: 50,
                minHp: 25, maxHp: 130,
            ),
            new EnemyData
            (   //Daedroth
                id: 27,
                minDmg: 10, maxDmg: 30,
                minMetalToHit: WeaponMaterialTypes.Dwarven,
            ),
            new EnemyData
            (   //Daedra Lord
                id: 31,
                minDmg: 20, maxDmg: 70,
            ),
        }      
    }}