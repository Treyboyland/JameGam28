using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [Tooltip("Place Sheep Should move to")]
    [SerializeField]
    Transform movementPosition;

    public Transform MovementTransform { get => movementPosition; }

    Vector2Int position;

    public Vector2Int Position
    {
        get => position;
        set
        {
            position = value;
            gameObject.name = "Ground [" + position.x +","+ position.y + "]";
        }
    }

    public bool Obstructed { get; set; } = false;
}
