using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepTemperature : MonoBehaviour
{
    [SerializeField]
    Sheep sheep;

    [SerializeField]
    SheepWool wool;

    [SerializeField]
    SheepStatusSO hotStatus;

    [SerializeField]
    SheepStatusSO coldStatus;

    const int COMFORTABLE_TEMP = 5;

    delegate void StatusSetter();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TemperatureCheck();
    }

    void AddHotStatus()
    {
        sheep.AddStatus(hotStatus);
        sheep.RemoveStatus(coldStatus);
    }

    void AddColdStatus()
    {
        sheep.AddStatus(coldStatus);
        sheep.RemoveStatus(hotStatus);
    }

    void RemoveAll()
    {
        sheep.RemoveStatus(hotStatus);
        sheep.RemoveStatus(coldStatus);
    }

    int ComfortableModifier()
    {
        int str = sheep.Stats.Strength;

        if (str == 0)
        {
            return 0;
        }

        if (str < 4)
        {
            return 1;
        }

        if (str < 7)
        {
            return 1;
        }

        if (str < 10)
        {
            return 3;
        }

        //Strong sheep can exist at any temp comfortably
        return 99;
    }


    void TemperatureCheck()
    {
        int currentTemp = Weather.Instance.CurrentWeather.Temperature;

        int diff = currentTemp + wool.GetWoolModifier() - COMFORTABLE_TEMP;
        bool cool = diff < 0;

        //Delegate to call correct status setter method
        StatusSetter newStatus;

        if (Mathf.Abs(diff) < ComfortableModifier())
        {
            newStatus = cool ? AddColdStatus : AddHotStatus;
        }
        else
        {
            newStatus = RemoveAll;
        }

        newStatus();
    }
}
