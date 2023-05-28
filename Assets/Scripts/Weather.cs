using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    [Range(0, 10)]
    int currentTemp;

    [SerializeField]
    float secondsBetweenWeatherChanges;

    public WeatherData CurrentWeather { get; protected set; }

    public WeatherData NextWeather { get; set; }

    static Weather _instance;

    public static Weather Instance { get => _instance; }

    delegate WeatherData WeatherSetter();

    float elapsed = 0;

    [System.Serializable]
    public struct WeatherData
    {
        public int Temperature;
        public string WeatherString;
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Debug.LogWarning("More than 1 instance in scene: " + _instance.gameObject.name + " " + gameObject.name);
        }

        CurrentWeather = GetTemperate();
        SetRandomWeatherNext();
    }

    private void Update()
    {
        elapsed += Time.deltaTime;

        if (elapsed > secondsBetweenWeatherChanges)
        {
            elapsed = 0;
            CurrentWeather = NextWeather;
            SetRandomWeatherNext();
        }
    }

    public WeatherData GetTemperate()
    {
        int temp = Random.Range(4, 7);
        string weatherString = "Temperate";

        return new WeatherData() { Temperature = temp, WeatherString = weatherString };
    }

    public WeatherData GetCold()
    {
        int temp = Random.Range(0, 4);
        string weatherString = "Cold";

        return new WeatherData() { Temperature = temp, WeatherString = weatherString };
    }

    public WeatherData GetHot()
    {
        int temp = Random.Range(7, 11);
        string weatherString = "Hot";

        return new WeatherData() { Temperature = temp, WeatherString = weatherString };
    }


    void SetRandomWeatherNext()
    {
        List<WeatherSetter> setters = new List<WeatherSetter>() { GetHot, GetCold, GetTemperate };

        NextWeather = setters.Random()();
    }
}
