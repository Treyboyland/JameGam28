using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    [SerializeField]
    List<GameObject> upObjects, downObjects, leftObjects, rightObjects;

    public Vector2Int Position { get; set; }
    public List<GameObject> RightObjects { get => rightObjects; set => rightObjects = value; }
    public List<GameObject> LeftObjects { get => leftObjects; set => leftObjects = value; }
    public List<GameObject> DownObjects { get => downObjects; set => downObjects = value; }
    public List<GameObject> UpObjects { get => upObjects; set => upObjects = value; }

    public void ActivateObjects(List<GameObject> objects)
    {
        foreach (var obj in objects)
        {
            obj.SetActive(true);
        }
    }

    public void DeactivateObjects(List<GameObject> objects)
    {
        foreach (var obj in objects)
        {
            obj.SetActive(false);
        }
    }
}
