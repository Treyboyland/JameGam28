using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PowerButtonUI : MonoBehaviour
{
    [SerializeField]
    Button button;

    [SerializeField]
    Image buttonImage;

    [SerializeField]
    Image progressImage;

    [SerializeField]
    Color selectedColor, notSelectedColor;

    [SerializeField]
    Image image;

    [SerializeField]
    TMP_Text textBox;

    PlayerPowersSO power;

    static Player player;

    public PlayerPowersSO Power
    {
        get => power;
        set
        {
            gameObject.name = "PowerButton-" + value.PowerName;
            power = value;
            textBox.text = "" + (power.Cost == 0 ? "" : power.Cost);
            image.sprite = power.Icon;
        }
    }


    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindObjectOfType<Player>();
        }
        button.onClick.AddListener(ChangePower);
    }

    void ChangePower()
    {
        player.SetPowerByData(power);
    }

    private void Update()
    {
        buttonImage.color = player.CurrentPower.Power == power ? selectedColor : notSelectedColor;
        if (power.UseTime)
        {
            var playerPower = player.GetPlayerPower(power);
            if (playerPower != default(PlayerPower))
            {
                progressImage.fillAmount = playerPower.Progress;
            }
        }
    }
}
