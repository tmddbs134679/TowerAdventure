using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EENEMYTYPE
{
    DEFAULT,
}

[CreateAssetMenu(menuName = "Sound/EnemySoundData")]
public class EnemySoundData : ScriptableObject
{
    public EENEMYTYPE monsterType;
    public AudioClip damage;
    public AudioClip die;
    public AudioClip move;
}
