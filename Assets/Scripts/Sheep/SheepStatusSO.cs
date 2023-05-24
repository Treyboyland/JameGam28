using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SheepStatus-", menuName = "Sheep/Sheep Status")]
public class SheepStatusSO : ScriptableObject
{
    [SerializeField]
    string statusName;

    [SerializeField]
    Sprite icon;

    public Sprite Icon { get => icon; }
    public string StatusName { get => statusName; }
}
