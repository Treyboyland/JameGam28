using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SheepMovement : MonoBehaviour
{
    [SerializeField]
    Sheep sheep;

    [SerializeField]
    List<DirectionAndRotation> directionMap;

    public bool CanMove { get; set; } = true;

    [System.Serializable]
    struct DirectionAndRotation
    {
        public Direction Direction;
        public Vector3 Rotation;
    }


    enum Direction
    {
        UP = 1,
        DOWN,
        LEFT,
        RIGHT
    }

    List<Direction> allDirections = new List<Direction>() { Direction.UP, Direction.DOWN, Direction.LEFT, Direction.RIGHT };

    static GroundSpawner groundSpawner;

    private void OnEnable()
    {
        if (groundSpawner == null)
        {
            groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        }
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(Movement());
        }
    }

    IEnumerator Movement()
    {
        while (true)
        {
            yield return new WaitForSeconds(sheep.Stats.SecondsBetweenMoves);
            yield return StartCoroutine(ExecuteMoves());
        }
    }

    Direction GetDirection(Direction lastDirection)
    {
        List<Direction> possible = allDirections.Where(x => x != lastDirection).ToList();

        return possible.Random();
    }

    void SetRotation(Direction currentDirection)
    {
        var rotation = directionMap.Where(x => x.Direction == currentDirection).First().Rotation;

        sheep.transform.localRotation = Quaternion.Euler(rotation);
    }

    Vector2Int GetUpdatedGroundPosition(Direction direction)
    {
        Vector2Int pos = sheep.CurrentPosition;
        switch (direction)
        {
            case Direction.UP:
                pos.y++;
                break;
            case Direction.DOWN:
                pos.y--;
                break;
            case Direction.LEFT:
                pos.x--;
                break;
            case Direction.RIGHT:
                pos.x++;
                break;
        }

        return pos;
    }

    void MoveToNewPosition(Direction currentDirection)
    {
        var pos = GetUpdatedGroundPosition(currentDirection);
        var ground = groundSpawner.GetGroundAtPosition(pos);
        if (ground != null && !ground.Obstructed)
        {
            sheep.transform.position = ground.MovementTransform.position;
            sheep.CurrentPosition = pos;
        }
        else if (ground == null)
        {
            //TOOD: Handle Out of Bounds
        }
    }


    IEnumerator ExecuteMoves()
    {
        //TODO: Map exit, or should I increase the size of the map by 1 unit?
        //int moves = sheep.Stats.MoveCount.Random();

        var max = sheep.CurvesSO.MaxMoves.Evaluate(sheep.Stats.Strength);

        int moves = (int)UnityEngine.Random.Range(0, max);

        Direction lastMove = (Direction)0;

        for (int i = 0; i < moves; i++)
        {

            Direction nextMove = GetDirection(lastMove);
            SetRotation(nextMove);
            yield return new WaitForSeconds(sheep.CurvesSO.SecondsBetweenSmallMoves);
            MoveToNewPosition(nextMove);
        }
    }
}
