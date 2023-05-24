using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    List<PlayerPower> powers;

    [SerializeField]
    int gold;

    [SerializeField]
    float raycastDistance;


    public float Speed { get => speed; }
    public List<PlayerPower> Powers { get => powers; }
    public int Gold { get => gold; set => gold = value; }
    public float RaycastDistance { get => raycastDistance; }
    public PlayerPower CurrentPower { get => currentPower; }

    int currentPowerIndex = 0;

    PlayerPower currentPower;

    private void Start()
    {
        SetPowerIndex(0);
    }

    public void PreviousPower()
    {
        currentPowerIndex--;
        if (currentPowerIndex == 0)
        {
            currentPowerIndex = powers.Count - 1;
        }
        UpdatePower();
    }

    public void NextPower()
    {
        currentPowerIndex++;
        if (currentPowerIndex >= powers.Count)
        {
            currentPowerIndex = 0;
        }
        UpdatePower();
    }

    public void SetPowerIndex(int index)
    {
        if (index >= 0 && index < powers.Count)
        {
            currentPowerIndex = index;
        }
        UpdatePower();
    }

    public void SetPowerByData(PlayerPowersSO power)
    {
        for (int i = 0; i < powers.Count; i++)
        {
            if (powers[i].Power == power)
            {
                currentPowerIndex = i;
                UpdatePower();
                break;
            }
        }
    }

    void UpdatePower()
    {
        if (currentPowerIndex >= 0 && currentPowerIndex < powers.Count)
        {
            currentPower = powers[currentPowerIndex];
        }
    }

    public void UsePower()
    {
        if (currentPower != null && currentPower.Power.Cost <= gold && currentPower.CanUse())
        {
            Gold -= currentPower.Power.Cost;
            //TODO: Actually do power stuff
            currentPower.UsePower();
        }
    }
}
