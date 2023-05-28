using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField]
    Ground groundPrefab;

    [Tooltip("Assume plane is 1:5 with unity units")]
    [SerializeField]
    Transform plane;

    [SerializeField]
    Transform groundHolder;

    Vector2Int mapSize;

    [SerializeField]
    float mapY;

    [SerializeField]
    Player player;

    List<Ground> groundPool = new List<Ground>();

    public Vector2Int MapSize { get => mapSize; }



    // Start is called before the first frame update
    void Awake()
    {
        ClearMap();
        CreateMap();
        SetPlayerInitialPosition();
    }

    int GetUnits(float scale)
    {
        return (int)(10 * scale);
    }

    Ground CreateGround()
    {
        Ground newGround = Instantiate(groundPrefab, groundHolder);
        newGround.gameObject.SetActive(false);

        groundPool.Add(newGround);

        return newGround;
    }

    Ground GetGround()
    {
        foreach (var ground in groundPool)
        {
            if (!ground.gameObject.activeInHierarchy)
            {
                return ground;
            }
        }

        return CreateGround();
    }

    void ClearMap()
    {
        foreach (var ground in groundPool)
        {
            ground.gameObject.SetActive(false);
            ground.Position = Vector2Int.zero;
        }
    }

    void CreateMap()
    {
        mapSize = new Vector2Int(GetUnits(plane.transform.localScale.x), GetUnits(plane.transform.localScale.y));
        Vector3 offset = plane.transform.position;
        offset.x -= mapSize.x / 2;
        offset.z -= mapSize.y / 2;
        offset += new Vector3(.5f, 0, .5f); //BAD
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                var ground = GetGround();
                ground.Position = new Vector2Int(x, y);

                ground.transform.position = new Vector3(x, plane.transform.position.y, y) + offset;
                ground.gameObject.SetActive(true);
            }
        }
    }

    void SetPlayerInitialPosition()
    {
        Vector2Int center = new Vector2Int(mapSize.x / 2, mapSize.y / 2);
        var centerGround = groundPool.Where(x => x.gameObject.activeInHierarchy && x.Position == center).First();

        player.transform.position = centerGround.MovementTransform.position;
    }

    public Ground GetGroundAtPosition(Vector2Int pos)
    {
        return groundPool.Where(x => x.gameObject.activeInHierarchy && x.Position == pos).FirstOrDefault();
    }

    bool IsValidPoint(Vector2Int pos)
    {
        return GetGroundAtPosition(pos) != default(Ground);
    }

    public List<Vector2Int> GetNeighbors(Vector2Int pos)
    {
        List<Vector2Int> toReturn = new List<Vector2Int>();

        for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {
                if ((x == 0 && y == 0) || (Mathf.Abs(x) + Mathf.Abs(y) > 1))
                {
                    continue;
                }
                Vector2Int neighbor = new Vector2Int(pos.x + x, pos.y + y);

                if (IsValidPoint(neighbor))
                {
                    toReturn.Add(neighbor);
                }
            }
        }

        return toReturn;
    }
}
