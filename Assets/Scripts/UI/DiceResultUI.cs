using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceResultUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text textBox;

    [SerializeField]
    float secondsToWait;

    private void Start()
    {
        textBox.text = "";
    }

    public void SetString(string value)
    {
        StopAllCoroutines();
        textBox.text = value;
        StartCoroutine(ShowForTime());
    }

    IEnumerator ShowForTime()
    {
        yield return new WaitForSeconds(secondsToWait);
        textBox.text = "";
    }
}
