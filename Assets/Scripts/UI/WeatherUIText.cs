using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeatherUIText : MonoBehaviour
{
    [SerializeField]
    Weather weather;

    [SerializeField]
    TMP_Text textBox;

    Weather.WeatherData current;

    Weather.WeatherData next;

    private void Start()
    {
        UpdateUI();
    }


    private void Update()
    {
        if (current.WeatherString != weather.CurrentWeather.WeatherString || next.WeatherString != weather.NextWeather.WeatherString)
        {
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        current = weather.CurrentWeather;
        next = weather.NextWeather;

        textBox.text = "Current: " + current.WeatherString + "\r\n" +
            "Next: " + next.WeatherString;
    }
}
