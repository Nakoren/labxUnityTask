using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sounds", menuName = "Sounds")]

public class SoundResources : ScriptableObject
{
    public AudioClip stoneHit;
    public AudioClip explosion;
    public AudioClip ambient;
}
