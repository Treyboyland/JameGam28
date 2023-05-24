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

    public string PowerName { get => powerName; }
    public Sprite Icon { get => icon; }
    public int Cost { get => cost; }
    
}
