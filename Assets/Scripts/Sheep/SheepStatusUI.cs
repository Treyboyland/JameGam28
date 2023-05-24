using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheepStatusUI : MonoBehaviour
{
    [SerializeField]
    Image statusImage;

    [SerializeField]
    Sheep sheep;

    int currentStatusIndex;

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            sheep.OnStatusUpdated.AddListener(ResetStatus);
            StartCoroutine(StatusLoop());
        }
    }

    private void OnDisable()
    {
        sheep.OnStatusUpdated.RemoveListener(ResetStatus);
    }

    void ResetStatus()
    {
        StopAllCoroutines();
        currentStatusIndex = 0;
        StartCoroutine(StatusLoop());
    }

    void SetImageAlpha(float value)
    {
        var color = statusImage.color;
        color.a = value;
        statusImage.color = color;
    }

    IEnumerator StatusLoop()
    {
        while (true)
        {
            if (sheep.CurrentStatus.Count == 0)
            {
                yield return null;
                SetImageAlpha(0);
                continue;
            }

            SetImageAlpha(1);
            currentStatusIndex = (currentStatusIndex + 1) % sheep.CurrentStatus.Count;
            statusImage.sprite = sheep.CurrentStatus[currentStatusIndex].Icon;
            yield return new WaitForSeconds(sheep.CurvesSO.SecondsBetweenStatusChanges);
        }
    }
}
