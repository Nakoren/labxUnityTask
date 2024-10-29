using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBLogger : MonoBehaviour
{
    private void Awake()
    {
        Log("Enabled");
    }

    private void OnEnable()
    {
        Log("Enabled");
    }

    private void Start()
    {
        Log("Started");
    }

    private void FixedUpdate()
    {

    }

    private void Update()
    {
        
    }
    private void LateUpdate()
    {
        
    }

    private void OnDisable()
    {
        Log("Disabled");
    }
    private void OnDestroy()
    {
        Log("Destroyed");
    }

    private void Log(string msg)
    {
        Debug.Log($"{gameObject.name}: msg: {msg} on: {Time.frameCount}");
    }
}
