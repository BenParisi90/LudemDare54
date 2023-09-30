using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    int poolSize = 10;

    List<GameObject> pooledObjects = new List<GameObject>();
    public List<GameObject> PooledObjects => pooledObjects;

    void Awake()
    {
        //create a pool of objects
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        //find an inactive object in the pool and return it
        foreach (GameObject obj in pooledObjects)
        {
            if (obj.activeInHierarchy == false)
            {
                return obj;
            }
        }

        Debug.LogWarning("No inactive objects found in pool");
        return null;
    }
}
