using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerFence : PlayerPower
{
    [SerializeField]
    Transform cameraTransform;

    [SerializeField]
    GameObject placeholderFence;

    [SerializeField]
    FenceSpawner fenceSpawner;

    [SerializeField]
    GroundSpawner groundSpawner;

    [SerializeField]
    float raycastDistance;

    Ground targetedGround = null;

    public override bool CanUse()
    {
        return targetedGround != null && !targetedGround.Obstructed;
    }

    public override void UsePower()
    {
        if (targetedGround == null)
        {
            return;
        }

        SpawnFence();
    }

    void SpawnFence()
    {
        var fence = fenceSpawner.GetItem();
        fence.transform.position = targetedGround.transform.position;
        fence.Position = targetedGround.Position;
        targetedGround.Obstructed = true;
        fence.gameObject.SetActive(true);

        var otherFencePositions = groundSpawner.GetNeighbors(fence.Position);

        var otherFences = fenceSpawner.GetFencesAtPositions(otherFencePositions);

        foreach (var otherFence in otherFences)
        {
            Vector2Int diff = otherFence.Position - fence.Position;

            if (diff == Vector2Int.up)
            {
                fence.ActivateObjects(fence.UpObjects);
                otherFence.ActivateObjects(otherFence.DownObjects);
            }
            else if (diff == Vector2Int.down)
            {
                fence.ActivateObjects(fence.DownObjects);
                otherFence.ActivateObjects(otherFence.UpObjects);
            }
            else if (diff == Vector2Int.left)
            {
                fence.ActivateObjects(fence.LeftObjects);
                otherFence.ActivateObjects(otherFence.RightObjects);
            }
            else if (diff == Vector2Int.right)
            {
                fence.ActivateObjects(fence.RightObjects);
                otherFence.ActivateObjects(otherFence.LeftObjects);
            }
        }
    }

    private void Update()
    {
        if (IsActivePower)
        {
            CheckForOpening();
        }
        else
        {
            placeholderFence.gameObject.SetActive(false);
        }
    }

    void CheckForOpening()
    {
        targetedGround = null;
        int mask = LayerMask.GetMask("Ground");
        if (Physics.Raycast(transform.position, cameraTransform.forward, out RaycastHit hit, raycastDistance, mask))
        {
            targetedGround = hit.collider.gameObject.GetComponent<Ground>();
            if (targetedGround != null && !targetedGround.Obstructed)
            {
                placeholderFence.transform.position = targetedGround.transform.position;
                placeholderFence.gameObject.SetActive(true);
            }
            else
            {
                placeholderFence.gameObject.SetActive(false);
            }
        }
        else
        {
            placeholderFence.gameObject.SetActive(false);
        }
    }
}
