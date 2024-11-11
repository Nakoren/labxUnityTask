
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boulder_spawner : MonoBehaviour
{
    public GameObject BoulderEntity;

    public GameObject Spawn()
    {
        Vector3 position = gameObject.transform.position;
        position.y = position.y+5;
        GameObject stone = Instantiate(BoulderEntity, position, Quaternion.identity);
        return stone;
    }
}
