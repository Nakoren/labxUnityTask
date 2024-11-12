using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    static public int bestScore = 0;
    static public int lastScore = 0;
    static bool newBest = false;
    
    static public bool NewBest
    {
        get
        {
            if (newBest)
            {
                newBest = false;
                return true;
            }
            return false;
        }
        set
        {
            newBest = value;
        }
    }
}
