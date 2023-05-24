using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    [SerializeField]
    Sheep sheepPrefab;

    [SerializeField]
    Vector2Int initialSpawns;

    [SerializeField]
    GroundSpawner ground;

    List<Sheep> sheepPool = new List<Sheep>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnInitial();
    }

    Sheep CreateSheep()
    {
        Sheep newSheep = Instantiate(sheepPrefab, transform);
        newSheep.gameObject.SetActive(false);

        sheepPool.Add(newSheep);

        return newSheep;
    }

    Sheep GetSheep()
    {
        foreach (var sheep in sheepPool)
        {
            if (!sheep.gameObject.activeInHierarchy)
            {
                return sheep;
            }
        }

        return CreateSheep();
    }

    void SpawnInitial()
    {
        int initalCount = initialSpawns.Random();
        var allPoints = ground.MapSize.GetPoints();
        allPoints.Shuffle();

        for (int i = 0; i < initalCount; i++)
        {
            Sheep sheep = GetSheep();
            var point = allPoints[i];
            var groundPos = ground.GetGroundAtPosition(point);
            sheep.transform.position = groundPos.MovementTransform.position;
            sheep.CurrentPosition = groundPos.Position;
            sheep.gameObject.SetActive(true);
        }
    }
}
