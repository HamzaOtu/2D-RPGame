using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAttack : FSMAction
{
    [Header("Config")]
    [SerializeField] private float damage;
    [SerializeField] private float timeBtwAttack;

    private EnemyBrain enemyBrain;
    private float timer;

    private void Awake()
    {
        enemyBrain = GetComponent<EnemyBrain>();
    }

    public override void Act()
    {
        AttackPlayer();
    }

    private void AttackPlayer()
    {
        if (enemyBrain == null) return;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            IDamagable player = enemyBrain.Player.GetComponent<IDamagable>();
            player.TakeDamage(damage);
            timer = timeBtwAttack;
        }
    }
}
