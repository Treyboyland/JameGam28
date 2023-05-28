using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    TMP_Text textBox;

    int currentGold = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentGold != player.Gold)
        {
            UpdateText();
        }
    }

    void UpdateText()
    {
        currentGold = player.Gold;

        textBox.text = "" + currentGold;
    }
}
