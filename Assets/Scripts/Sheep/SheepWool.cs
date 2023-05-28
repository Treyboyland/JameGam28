using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepWool : MonoBehaviour
{
    [SerializeField]
    Sheep sheep;

    [SerializeField]
    AnimationCurve woolScale;

    float elapsed = 0;

    public float Progress { get => elapsed / sheep.CurvesSO.WoolGrowth.Evaluate(sheep.Stats.Charisma); }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        UpdateWoolSize();
    }

    Vector3 GetScale()
    {
        var value = woolScale.Evaluate(Progress);
        return new Vector3(value, value, value);
    }

    public void UpdateWoolSize()
    {
        var newScale = GetScale();

        transform.localScale = newScale;
    }

    public void ResetTime()
    {
        elapsed = 0;
        UpdateWoolSize();
    }

    public int GetWoolModifier()
    {
        float progress = Progress;

        if (progress < .2f)
        {
            return -2;
        }
        if (progress < .4f)
        {
            return -1;
        }
        if (progress <= .6)
        {
            return 0;
        }
        if (progress < .8)
        {
            return 1;
        }
        return 2;
    }

}
