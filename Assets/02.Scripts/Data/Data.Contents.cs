using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;


namespace Data
{
    #region CreatureData
    [Serializable]
    public class CreatureData
    {
        public int DataId;
        public string DescriptionTextID;
        public string PrefabLabel;
        public float Atk;
        public float AtkBonus;
        public float MoveSpeed;
        public float TotalExp;
        public float HpRate;
        public float AtkRate;
        public float MoveSpeedRate;
        public string IconLabel;
        public List<int> SkillTypeList;//InGameSkills를 제외한 추가스킬들
    }

    [Serializable]
    public class CreatureDataLoader : ILoader<int, CreatureData>
    {
        public List<CreatureData> creatures = new List<CreatureData>();
        public Dictionary<int, CreatureData> MakeDict()
        {
            Dictionary<int, CreatureData> dict = new Dictionary<int, CreatureData>();
            foreach (CreatureData creature in creatures)
                dict.Add(creature.DataId, creature);
            return dict;
        }
    }
    #endregion




    #region SkillData
    [Serializable]
    public class SkillData
    {
        public int DataId;
        public string Name;
        public string Description;
        public string AnimName;
        public string PrefabLabel; //프리팹 경로
        public string IconLabel;//아이콘 경로
        public string SoundLabel;// 발동사운드 경로
        public string Category;//스킬 카테고리
        public float CoolTime; // 쿨타임
        public float ProjectileSpacing;// 발사체 사이 간격
        public float Duration; //스킬 지속시간
        public float RecognitionRange;//인식범위
        public string CastingSound; // 시전사운드
        public float AngleBetweenProj;// 발사체 사이 각도
        public float AttackInterval; //공격간격
        public int CastingEffect; // 스킬 발동시 효과
        public string HitSoundLabel; // 히트사운드
        public float ProbCastingEffect; // 스킬 발동 효과 확률
        public int HitEffect;// 적중시 이펙트
        public float ProbHitEffect; // 스킬 발동 효과 확률
        public float ProjRange; //투사체 사거리
        public float MinCoverage; //최소 효과 적용 범위
        public float MaxCoverage; // 최대 효과 적용 범위
        public float RoatateSpeed; // 회전 속도
        public float ProjSpeed; //발사체 속도
        public float ScaleMultiplier;
        public bool IsMove;         //움직이면서 가능한 공격
        public float moveSpeed;
    }
    [Serializable]
    public class SkillDataLoader : ILoader<int, SkillData>
    {
        public List<SkillData> skills = new List<SkillData>();

        public Dictionary<int, SkillData> MakeDict()
        {
            Dictionary<int, SkillData> dict = new Dictionary<int, SkillData>();
            foreach (SkillData skill in skills)
                dict.Add(skill.DataId, skill);
            return dict;
        }
    }
    #endregion


    #region StageData

    [Serializable]
    public class StageData
    {
        public int StageIndex = 1;
        public string StageName;
        public int StageLevel = 1;
        public string MapName;
        //public int StageSkill;

        
    }
    public class StageDataLoader : ILoader<int, StageData>
    {
        public List<StageData> stages = new List<StageData>();

        public Dictionary<int, StageData> MakeDict()
        {
            Dictionary<int, StageData> dict = new Dictionary<int, StageData>();
            foreach (StageData stage in stages)
                dict.Add(stage.StageIndex, stage);
            return dict;
        }
    }

    #endregion
}