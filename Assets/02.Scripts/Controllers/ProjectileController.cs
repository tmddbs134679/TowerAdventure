using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : BaseController
{
    CreatureController _owner;
    public SkillBase Skill;
    Vector2 _spawnPos;
    Vector3 _dir = Vector3.zero;
    Vector3 _target = Vector3.zero;
    Rigidbody2D _rigid;

    Coroutine _coDotDamage;

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        ObjectType = Define.EOBJECTTPYE.PROJECTILE;
        return true;
    }
    public void SetInfo(CreatureController owner, Vector2 position, Vector2 dir, Vector2 target, SkillBase skill)
    {
        _owner = owner;
        _spawnPos = position;
        _dir = dir;
        Skill = skill;
        _rigid = GetComponent<Rigidbody2D>();
        _target = target;
        transform.localScale = Vector3.one * Skill.SkillData.ScaleMultiplier;

        switch (skill.SkillType)
        {
            case Define.ESKILLTYPE.FIREBALL:
                StartCoroutine(CoFireBall(_spawnPos, _target, true));
                break;
            
        }

    }

    IEnumerator CoFireBall(Vector2 spawnPos, Vector3 target, bool isFollow = false)
    {
        float flightTime = 1.0f; // 투사체가 도달하는 데 걸리는 시간
        float gravity = Mathf.Abs(Physics.gravity.y);

        // 시작 위치와 타겟 위치 보정 (약간 위로 들어올림)
        Vector3 start = spawnPos + Vector2.up * 1.0f;
        Vector3 end = target + Vector3.up * 1.0f;

        Vector3 displacement = end - start;
        Vector3 displacementXZ = new Vector3(displacement.x, 0, displacement.z);

        float horizontalDistance = displacementXZ.magnitude;
        float verticalDistance = displacement.y;

        // 수평 속도
        float vx = horizontalDistance / flightTime;

        // 수직 속도 (vy) 계산
        float vy = (verticalDistance + 0.5f * gravity * flightTime * flightTime) / flightTime;

        // 방향 벡터 (수평)
        Vector3 directionXZ = displacementXZ.normalized;

        // 최종 속도 벡터
        Vector3 velocity = directionXZ * vx;
        velocity.y = vy;

        //// 투사체 생성
        //GameObject projectile = Instantiate(projectilePrefab, start, Quaternion.LookRotation(directionXZ));
        //Rigidbody rb = projectile.GetComponent<Rigidbody>();

        Rigidbody rb = GetComponent<Rigidbody>();
        // 투사체 속도 설정
        if (rb != null)
        {
            rb.velocity = velocity;
        }

        yield return null; // 필요한 경우 추가 로직 삽입
    }
}
