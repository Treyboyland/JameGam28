using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerShear : PlayerPower
{
    [SerializeField]
    Transform cameraTransform;

    Sheep currentSheep;

    public override bool CanUse()
    {
        currentSheep = null;
        if (Physics.Raycast(transform.position, cameraTransform.forward, out RaycastHit hit, player.RaycastDistance))
        {
            currentSheep = hit.collider.gameObject.GetComponent<Sheep>();
        }

        return currentSheep != null;
    }

    public override void UsePower()
    {
        if (currentSheep == null)
        {
            return;
        }

        player.Gold += currentSheep.CurrentGold();
        currentSheep.SheerSheep();
    }
}
