using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : BaseController
{
    CreatureController _owner;
    public SkillBase Skill;
    Vector3 _spawnPos;
    Vector3 _dir = Vector3.zero;
    Vector3 _target = Vector3.zero;
    Rigidbody _rigid;

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
    public void SetInfo(CreatureController owner, Vector3 position, Vector3 dir, Vector3 target, SkillBase skill)
    {
        _owner = owner;
        _spawnPos = position;
        _dir = dir;
        Skill = skill;
        _rigid = GetComponent<Rigidbody>();
        _target = target;
        transform.localScale = Vector3.one * Skill.SkillData.ScaleMultiplier;

        switch (skill.SkillType)
        {
            case Define.ESKILLTYPE.Fireball:
                Fireball(_spawnPos, _target);
                break;
            
        }

    }

    public void Fireball(Vector3 spawnPos, Vector3 target)
    {
        float gravity = Mathf.Abs(Physics.gravity.y);
        float flightTime = 1.7f;

        Vector3 displacement = target - spawnPos;
        Vector3 displacementXZ = Vector3.ProjectOnPlane(displacement, Vector3.up);

        float horizontalDistance = displacementXZ.magnitude;
        float verticalDistance = displacement.y;

        float vx = horizontalDistance / flightTime;
        float vy = (verticalDistance + 0.5f * gravity * flightTime * flightTime) / flightTime;

        Vector3 directionXZ = displacementXZ.normalized;
        Vector3 velocity = directionXZ * vx;
        velocity.y = vy;

        if (TryGetComponent(out Rigidbody rb))
        {
            rb.velocity = velocity;
            rb.useGravity = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Skill.SkillData.IsExplosive)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                if (TryGetComponent(out Rigidbody rb))
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    rb.isKinematic = true; // 중력 및 힘 비활성화
                }
                StartCoroutine(ExplodeAfterDelay());
            }
        }
      
    }

    private IEnumerator ExplodeAfterDelay()
    {
        GameObject obj = Managers.Resource.Instantiate("LineAttakArea(Circle)", pooling: true);
        obj = Instantiate(obj, GetGroundPosition(), Quaternion.identity);
        obj.GetComponent<AttackArea>().Init(_owner, Skill.SkillData.ExplosionDelay, Skill.SkillData.ExplosionRadius, transform.position);
        //explosionDelay
        yield return new WaitForSeconds(Skill.SkillData.ExplosionDelay);
        Managers.Resource.Destroy(gameObject);

    }

    private Vector3 GetGroundPosition()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 10f))
        {
            return hit.point + Vector3.up * 0.01f;
        }
        return transform.position;
    }

}
