using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SheepCurvesSO", menuName = "Sheep/Skill Curve")]
public class SheepCurvesSO : ScriptableObject
{
    [SerializeField]
    AnimationCurve maxMoves;

    [SerializeField]
    AnimationCurve waitBetweenMoves;

    [SerializeField]
    AnimationCurve coldThreshhold;

    [SerializeField]
    AnimationCurve hotThreshold;

    [SerializeField]
    AnimationCurve illnessProbability;

    [SerializeField]
    AnimationCurve woolGrowth;

    [SerializeField]
    float secondsBetweenIllnessChecks;

    [SerializeField]
    float secondsBetweenSmallMoves;

    [SerializeField]
    float secondsBetweenStatusChanges;

    [SerializeField]
    int maxGold;

    public AnimationCurve MaxMoves { get => maxMoves; }
    public float SecondsBetweenSmallMoves { get => secondsBetweenSmallMoves; }
    public AnimationCurve WaitBetweenMoves { get => waitBetweenMoves; }

    public float SecondsBetweenStatusChanges { get => secondsBetweenStatusChanges; }
    public AnimationCurve WoolGrowth { get => woolGrowth; }
    public float SecondsBetweenIllnessChecks { get => secondsBetweenIllnessChecks; }
    public AnimationCurve IllnessProbability { get => illnessProbability; }

    public int MaxGold { get => maxGold; }
}
