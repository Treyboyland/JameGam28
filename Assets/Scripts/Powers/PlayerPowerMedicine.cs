using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerMedicine : PlayerPower
{
    [SerializeField]
    Transform cameraTransform;

    [SerializeField]
    SheepStatusSO sickStatus;

    Sheep currentSheep;

    public override bool CanUse()
    {
        currentSheep = null;
        if (Physics.Raycast(transform.position, cameraTransform.forward, out RaycastHit hit, player.RaycastDistance))
        {
            currentSheep = hit.collider.gameObject.GetComponent<Sheep>();
        }

        return currentSheep != null && currentSheep.HasStatus(sickStatus);
    }

    public override void UsePower()
    {
        if (currentSheep != null && currentSheep.HasStatus(sickStatus))
        {
            currentSheep.RemoveStatus(sickStatus);
        }
    }
}
