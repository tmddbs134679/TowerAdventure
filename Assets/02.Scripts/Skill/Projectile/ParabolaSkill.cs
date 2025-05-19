using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Skill/ParabolaSkill")]
public class ParabolaSkill : SkillBase
{
    public GameObject projectilePrefab;
    public float flightTime = 1.5f; //  플레이어에게 도달하는 데 걸리는 시간 (조절 가능)

    public override void Active(GameObject caster, Vector3 dir, Action onComplete = null)
    {


        Vector3 start = caster.transform.position + Vector3.up * 1.2f;
        Vector3 target = dir + Vector3.up * 1.0f;

        Vector3 displacement = target - start;
        Vector3 displacementXZ = new Vector3(displacement.x, 0, displacement.z);

        float horizontalDistance = displacementXZ.magnitude;
        float verticalDistance = displacement.y;
        float gravity = Mathf.Abs(Physics.gravity.y);

        //  수평 속도
        float vx = horizontalDistance / flightTime;

        //  수직 속도 (등가수직 운동 공식)
        float vy = (verticalDistance + 0.5f * gravity * flightTime * flightTime) / flightTime;

        //  방향
        Vector3 directionXZ = displacementXZ.normalized;

        Vector3 velocity = directionXZ * vx;
        velocity.y = vy;

        //  투사체 생성 및 발사
        GameObject projectile = Instantiate(projectilePrefab, start, Quaternion.LookRotation(directionXZ));

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = velocity;
        }

        onComplete?.Invoke();
    }
}
