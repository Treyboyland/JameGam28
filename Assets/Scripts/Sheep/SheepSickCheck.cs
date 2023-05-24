using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSickCheck : MonoBehaviour
{
    [SerializeField]
    Sheep sheep;

    [SerializeField]
    SheepStatusSO sickStatus;

    float elapsed = 0;

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= sheep.CurvesSO.SecondsBetweenIllnessChecks)
        {
            elapsed = 0;
            RunCheck();
        }
    }

    void RunCheck()
    {
        float probability = Random.Range(0.0f, 1.0f);

        if (!sheep.HasStatus(sickStatus) && probability < sheep.CurvesSO.IllnessProbability.Evaluate(sheep.Stats.Constitution))
        {
            sheep.AddStatus(sickStatus);
        }
    }

}
