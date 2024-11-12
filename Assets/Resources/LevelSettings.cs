using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "LevelSettings")]
public class LevelSettings : ScriptableObject
{
    public int spawnDelay;
    public int maxHp;
    public int bombChance;
}
