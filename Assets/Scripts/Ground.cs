using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [Tooltip("Place Sheep Should move to")]
    [SerializeField]
    Transform movementPosition;

    public Transform MovementTransform { get => movementPosition; }

    public Vector2Int Position;
}
