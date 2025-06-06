using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.TextCore.Text;


[Serializable]
public class GameData
{
    public int UserLevel = 1;
    public string UserName = "Player";

    public int Gold = 0;
    public int Dia = 0;


    public bool BGMOn = true;
    public bool EffectSoundOn = true;
    public ContinueData ContinueInfo = new ContinueData();
    public StageData CurrentStage = new StageData();

}

[Serializable]
public class MissionInfo
{
    public int Progress;
    public bool IsRewarded;

}

[Serializable]
public class ContinueData
{
    public bool isContinue { get { return SavedBattleSkill.Count > 0; } }
    public int PlayerDataId;
    public float Hp;
    public float MaxHp;
    public float MaxHpBonusRate = 1;
    public float HealBonusRate = 1;
    public float HpRegen;
    public float Atk;
    public float AttackRate = 1;
    public float Def;
    public float DefRate;
    public float MoveSpeed;
    public float MoveSpeedRate = 1;
    public float TotalExp;
    public int Level = 1;
    public float Exp;
    public float CriRate;
    public float CriDamage = 1.5f;
    public float DamageReduction;
    public int KillCount;

    public Dictionary<Define.ESKILLTYPE, int> SavedBattleSkill = new Dictionary<Define.ESKILLTYPE, int>();

    public int WaveIndex;
    public void Clear()
    {
        // 각 변수의 초기값 설정
        PlayerDataId = 0;
        Hp = 0f;
        MaxHp = 0f;
        MaxHpBonusRate = 1f;
        HealBonusRate = 1f;
        HpRegen = 0f;
        Atk = 0f;
        AttackRate = 1f;
        Def = 0f;
        DefRate = 0f;
        MoveSpeed = 0f;
        MoveSpeedRate = 1f;
        TotalExp = 0f;
        Level = 1;
        Exp = 0f;
        CriRate = 0f;
        CriDamage = 1.5f;
        DamageReduction = 0f;

        KillCount = 0;

        SavedBattleSkill.Clear();

    }
}
public class GameManager : GenericSingleton<GameManager>
{
    public GameData _gameData = new GameData();
    public Vector2 JoystickDir { get; set; } = Vector2.zero;

    public ContinueData ContinueInfo
    {
        get { return _gameData.ContinueInfo; }
        set
        {
            _gameData.ContinueInfo = value;
        }
    }
}
