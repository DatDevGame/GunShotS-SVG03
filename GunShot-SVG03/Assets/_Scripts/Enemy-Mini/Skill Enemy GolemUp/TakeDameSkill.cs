using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDameSkill : MonoBehaviour
{
    protected int dameGolemUp;
    public LayerMask layer;
    [SerializeField] private float radius;
    protected virtual void Start()
    {
        Destroy(gameObject, 2f);
        dameGolemUp = 5;
    }

    protected virtual void attack()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, radius, layer);

        foreach (Collider2D hitPlayer in hit)
        {
            hitPlayer.GetComponent<StatusPlayer>().ReveiDame(dameGolemUp);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
