using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Power", menuName = "Player/Player Power")]
public class PlayerPowersSO : ScriptableObject
{
    [SerializeField]
    string powerName;

    [SerializeField]
    Sprite icon;

    [SerializeField]
    int cost;

    [SerializeField]
    bool useTime;

    [SerializeField]
    float secondsBetweenUses;

    public string PowerName { get => powerName; }
    public Sprite Icon { get => icon; }
    public int Cost { get => cost; }
    public bool UseTime { get => useTime; }

    public float SecondsBetweenUses { get => secondsBetweenUses; }
}
