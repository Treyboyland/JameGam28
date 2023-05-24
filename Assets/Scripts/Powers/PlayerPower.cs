using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerPower : MonoBehaviour
{
    [SerializeField]
    protected PlayerPowersSO power;

    [SerializeField]
    protected Player player;

    public PlayerPowersSO Power { get => power; }

    public abstract bool CanUse();
    public abstract void UsePower();
}
