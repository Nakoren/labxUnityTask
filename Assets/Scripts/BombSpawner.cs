using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public List<GameObject> BombsEntitiesList;

    public GameObject Spawn()
    {
        Vector3 position = gameObject.transform.position;

        GameObject randomBomb = BombsEntitiesList[Random.Range(0, BombsEntitiesList.Count)];
        position.y = position.y + 5;
        GameObject bomb = Instantiate(randomBomb, position, Quaternion.identity);
        return bomb;
    }
}
