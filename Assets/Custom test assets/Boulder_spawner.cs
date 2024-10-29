
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boulder_spawner : MonoBehaviour
{
    public GameObject BoulderEntity;
    public GameObject Camera;
    private static GameObject[] Hills;
    void Start()
    {
        Hills = GameObject.FindGameObjectsWithTag("Hill");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn()
    {
        float minDistance = Vector3.Distance(Hills[0].transform.position, Camera.transform.position);
        GameObject targetHill = Hills[0];
        for (int i = 1; i < Hills.Length; i++)
        {
            float dist = Vector3.Distance(Hills[i].transform.position, Camera.transform.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                targetHill = Hills[i];
            }
        }
        Vector3 position = targetHill.transform.position;
        position.y = 50;
        Instantiate(BoulderEntity, position, Quaternion.identity);
    }
}
