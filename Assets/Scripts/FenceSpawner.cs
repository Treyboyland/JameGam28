using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FenceSpawner : ObjectSpawner<Fence>
{
    public List<Fence> GetFencesAtPositions(List<Vector2Int> positions)
    {
        return itemPool.Where(x => x.gameObject.activeInHierarchy && positions.Contains(x.Position)).ToList();
    }
}
