
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boulder_spawner : MonoBehaviour
{
    public GameObject BoulderEntity;


    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn()
    {
        Vector3 position = gameObject.transform.position;
        position.y = position.y+5;
        Instantiate(BoulderEntity, position, Quaternion.identity);
    }
}
