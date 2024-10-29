using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool_swapper : MonoBehaviour
{
    public GameObject[] Tools;
    public GameObject[] ToolsAtScene;

    public void Swap()
    {
        for (int i = 0; i < ToolsAtScene.Length; i++)
        {
            int RandToolNumber = Random.Range(0, Tools.Length);
            GameObject newGO = Instantiate(Tools[RandToolNumber], ToolsAtScene[i].transform.position, ToolsAtScene[i].transform.rotation, ToolsAtScene[i].transform.parent);
            Destroy(ToolsAtScene[i]);
            ToolsAtScene[i] = newGO;
        }
    }
}
