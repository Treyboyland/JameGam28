using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    T prefab;
    protected List<T> itemPool = new List<T>();

    T CreateItem()
    {
        T newItem = Instantiate(prefab, transform);
        newItem.gameObject.SetActive(false);

        itemPool.Add(newItem);

        return newItem;
    }

    public T GetItem()
    {
        foreach (var item in itemPool)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                return item;
            }
        }

        return CreateItem();
    }
}
