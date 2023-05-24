using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct SheepStats
{
    [Tooltip("How quickly the sheep dies when dying")]
    public float DeathSpeed;

    [Tooltip("Seconds between movement executions")]
    public float SecondsBetweenMoves;

    public int Constitution;
    public int Strength;
    public int Intelligence;
    public int Wisdom;
    public int Dexterity;
    public int Charisma;

    public void Randomize()
    {
        Constitution = UnityEngine.Random.Range(0, 11);
        Strength = UnityEngine.Random.Range(0, 11);
        Intelligence = 0;
        Wisdom = 0;
        Dexterity = UnityEngine.Random.Range(0, 11);
        Charisma = UnityEngine.Random.Range(0, 11);
    }

    /*
    (From 0 - 10?)
    CON -> Illness, Heat and Cold Resistance, how long it survives in the puddle
    DEX -> how frequently it moves,
    CHA -> How fast the wool grows,
    STR/Vigor -> How far the sheep moves,
    INT, WIS -> always 0 
    In-Game
    (Body temp, location, wool quantity)
    */
}
