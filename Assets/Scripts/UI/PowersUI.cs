using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersUI : MonoBehaviour
{
    [SerializeField]
    PowerButtonUI buttonPrefab;

    [SerializeField]
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        SpawnButtons();
    }

    void SpawnButtons()
    {
        foreach (var power in player.Powers)
        {
            var newButton = Instantiate(buttonPrefab, transform) as PowerButtonUI;
            newButton.Power = power.Power;
        }
    }
}
