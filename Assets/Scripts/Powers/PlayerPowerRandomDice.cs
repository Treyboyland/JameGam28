using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPowerRandomDice : PlayerPower
{
    [SerializeField]
    string diceRollPower;

    [SerializeField]
    string diceRollSheepSpawn;

    [SerializeField]
    string diceRollSheepSpawnJackpot;

    [SerializeField]
    SheepSpawner sheepSpawner;

    [SerializeField]
    Weather weather;

    float elapsed = 0;

    public UnityEvent<string> OnPowerUsed = new UnityEvent<string>();

    public override bool CanUse()
    {
        return Progress >= 1;
    }

    private void Update()
    {
        elapsed += Time.deltaTime;
    }

    public override void UsePower()
    {
        elapsed = 0;
        int roll = HelperFunctions.DiceRoll(diceRollPower);
        string power;

        switch (roll)
        {
            case 1:
                //Kill sheep - Thunderstorm
                sheepSpawner.KillSheep(sheepSpawner.GetNumberOfSheep() / 4);
                power = "THUNDERSTORM";
                break;
            case 2:
                //Puddles - Rain
                power = "Rain";
                break;
            case 3:
                //Temperate Climate
                power = "Temperate";
                weather.NextWeather = weather.GetTemperate();
                break;
            case 4:
                //Money
                player.Gold += 500;
                power = "Money";
                break;
            case 5:
                //Spawn more sheep
                int sheepRoll = HelperFunctions.DiceRoll(diceRollSheepSpawn);
                sheepSpawner.SpawnMoreSheep(sheepRoll);
                power = "Sheep";
                break;
            case 6:
                //Spawn more sheep
                int sheepRollJackpot = HelperFunctions.DiceRoll(diceRollSheepSpawnJackpot);
                sheepSpawner.SpawnMoreSheep(sheepRollJackpot);
                power = "SHEEP!!!";
                break;
            default:
                power = "Default";
                break;
        }

        OnPowerUsed.Invoke(power);
    }

    public override float Progress
    {
        get
        {
            return Mathf.Clamp(elapsed / power.SecondsBetweenUses, 0.0f, 1.0f);
        }
    }
}
