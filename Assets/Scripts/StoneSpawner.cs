
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StoneSpawner : MonoBehaviour
{
    public List<GameObject> BoulderEntitiesList;

    public GameObject Spawn()
    {
        Vector3 position = gameObject.transform.position;

        GameObject randomStone = BoulderEntitiesList[Random.Range(0, BoulderEntitiesList.Count)];
        position.y = position.y+5;
        GameObject stone = Instantiate(randomStone, position, Quaternion.identity);
        return stone;
    }
}
