using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_controller : MonoBehaviour
{
    public GameObject[] villagers;
    public GameObject RainDrop;
    public GameObject cloud;
    public GameObject RaindropContainerGO;
    private int cloudTargetNumber = 0;
    private Vector3 MovementTarget;
    private double RaindropCooldown = 0.01;

    private void Start()
    {
        MovementTarget = villagers[0].transform.position;
        MovementTarget.y = cloud.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(cloud.transform.position,MovementTarget)>1)
        {
            MoveCloud();
        }
        else
        {
            RaindropCooldown -= Time.deltaTime;
            DropRain();
        }

    }

    public void ChangeMoveTarget()
    {
        cloudTargetNumber++;
        if (cloudTargetNumber == villagers.Length)
        {
            cloudTargetNumber = 0;
        }
        MovementTarget = villagers[cloudTargetNumber].transform.position;
        MovementTarget.y = 50;
    }

    void MoveCloud()
    {
        cloud.transform.position = Vector3.MoveTowards(cloud.transform.position, MovementTarget, (float)0.1);
    }

    void DropRain()
    {
        if (RaindropCooldown < 0)
        {
            Vector3 DropPosition = Random.insideUnitSphere * 10;
            DropPosition += cloud.transform.position;
            RaindropCooldown = 0.01;
            Instantiate(RainDrop, DropPosition, Quaternion.identity);
        }
    }
}