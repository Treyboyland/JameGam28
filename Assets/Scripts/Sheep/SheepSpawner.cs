using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

    void SpawnSheepAtPosition(Vector2Int point)
    {
        Sheep sheep = GetSheep();
        var groundPos = ground.GetGroundAtPosition(point);
        sheep.transform.position = groundPos.MovementTransform.position;
        sheep.CurrentPosition = groundPos.Position;
        sheep.gameObject.SetActive(true);
    }

    void SpawnInitial()
    {
        int initalCount = initialSpawns.Random();
        var allPoints = ground.MapSize.GetPoints();
        allPoints.Shuffle();

        for (int i = 0; i < initalCount; i++)
        {
            SpawnSheepAtPosition(allPoints[i]);
        }
    }

    public void SpawnMoreSheep(int count)
    {
        List<Sheep> currentSheep = GetActiveSheep();

        var usedPoints = currentSheep.Select(x => x.CurrentPosition).ToList();

        var allPoints = ground.MapSize.GetPoints();
        foreach (var point in usedPoints)
        {
            allPoints.Remove(point);
        }

        allPoints.Shuffle();

        count = count > allPoints.Count ? allPoints.Count : count;

        for (int i = 0; i < count; i++)
        {
            SpawnSheepAtPosition(allPoints[i]);
        }
    }

    public List<Sheep> GetActiveSheep()
    {
        return sheepPool.Where(x => x.gameObject.activeInHierarchy).ToList();
    }

    public int GetNumberOfSheep()
    {
        return GetActiveSheep().Count;
    }

    public void KillSheep(int count)
    {
        List<Sheep> sheep = GetActiveSheep();
        sheep.Shuffle();

        count = count > sheep.Count ? sheep.Count : count;

        for (int i = 0; i < count; i++)
        {
            sheep[i].Kill();
        }
    }
}
