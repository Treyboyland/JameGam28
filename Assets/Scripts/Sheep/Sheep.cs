using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;

public class Sheep : MonoBehaviour
{
    [SerializeField]
    SheepStats stats;

    [SerializeField]
    SheepWool wool;

    [SerializeField]
    SheepCurvesSO curvesSO;

    [SerializeField]
    LookAtConstraint constraint;


    public float WoolGrowthProgress { get; }

    public SheepStats Stats { get => stats; }
    public SheepCurvesSO CurvesSO { get => curvesSO; set => curvesSO = value; }

    public Vector2Int CurrentPosition { get; set; }
    public List<SheepStatusSO> CurrentStatus { get => currentStatus; }

    static Player player;

    List<SheepStatusSO> currentStatus = new List<SheepStatusSO>();

    public UnityEvent OnStatusUpdated = new UnityEvent();


    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindObjectOfType<Player>();
        }
        stats.Randomize();
        ConstraintSource source = new ConstraintSource();
        source.sourceTransform = player.transform;
        source.weight = 1;
        constraint.AddSource(source);
        //TODO: Symbol or numbers counting down to sheep death       
    }

    public void SheerSheep()
    {
        //TODO: Money calculation
        wool.ResetTime();
    }

    public int CurrentGold()
    {
        return (int)(curvesSO.MaxGold * wool.Progress);
    }

    public void AddStatus(SheepStatusSO status)
    {
        if (!currentStatus.Contains(status))
        {
            currentStatus.Add(status);
            OnStatusUpdated.Invoke();
        }
    }

    public void RemoveStatus(SheepStatusSO status)
    {
        currentStatus.Remove(status);
        OnStatusUpdated.Invoke();
    }

    public bool HasStatus(SheepStatusSO statusSO)
    {
        return currentStatus.Contains(statusSO);
    }

    public void Kill()
    {
        gameObject.SetActive(false);
    }
}
