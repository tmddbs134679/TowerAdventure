using System.Collections;
using UnityEngine;

public class BombProjectile : MonoBehaviour
{
    [SerializeField] private float explosionDelay;
    [SerializeField] private float explosionRadius;
    [SerializeField] private GameObject areaPrefab;
    private bool hasLanded = false;

    protected void OnTriggerEnter(Collider other)
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (hasLanded) return;

        hasLanded = true;
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        StartCoroutine(ExplodeAfterDelay());
    }

    private IEnumerator ExplodeAfterDelay()
    {
        areaPrefab = Instantiate(areaPrefab, GetGroundPosition(), Quaternion.identity);
        areaPrefab.GetComponent<AttackArea>().Init(explosionDelay, explosionRadius, transform.position);

        yield return new WaitForSeconds(explosionDelay);
        //Explode();
    }

    //private void Explode()
    //{
    //    Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);
    //    foreach (var hit in hits)
    //    {
    //        if (hit.TryGetComponent<Health>(out var health) &&
    //            hit.TryGetComponent<Faction>(out var targetFaction))
    //        {
    //            if (targetFaction.faction != this.OwnerFaction)
    //            {
    //                health.DealDamage(attacker, damage);
    //            }
    //        }
    //    }

    //    Destroy(gameObject);
    //}

    private Vector3 GetGroundPosition()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 10f))
        {
            return hit.point + Vector3.up * 0.01f; 
        }
        return transform.position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}