using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionAttackRange : FSMDecision
{
    [Header("Config")]
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask playerMask;

    private EnemyBrain enemy;

    public override bool Decide()
    {
        return PlayerInAttackRange();
    }

    private void Awake()
    {
        enemy = GetComponent<EnemyBrain>();
    }

    private bool PlayerInAttackRange()
    {
        if (enemy.Player == null) return false;
        Collider2D playerCollider = Physics2D.OverlapCircle(enemy.transform.position, attackRange, playerMask);
        if (playerCollider != null )
        {
            return true;
        }

        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
