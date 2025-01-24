using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionWander : FSMAction
{
    [Header("Config")]
    [SerializeField] private float speed;
    [SerializeField] private float wanderTime;
    [SerializeField] private Vector2 moveRange;

    private Vector3 movePosition;
    private float timer;

    private void Start()
    {
        GetNewDestination();
    }

    public override void Act()
    {
        timer -= Time.deltaTime;
        Vector3 moveDirection = (movePosition - transform.position).normalized;
        Vector3 movement = moveDirection * (speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePosition) >= 0.5f)
        {
            transform.Translate(movement);
        }

        if (timer <= 0)
        {
            GetNewDestination();
            timer = wanderTime;
        }
    }

    private void GetNewDestination()
    {
        float randomX = Random.Range(-moveRange.x, moveRange.x);
        float randomY = Random.Range(-moveRange.y, moveRange.y);
        movePosition = transform.position + new Vector3 (randomX, randomY);
    }

    private void OnDrawGizmosSelected()
    {
        if (moveRange != Vector2.zero)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(transform.position, moveRange * 2f);
            Gizmos.DrawLine(transform.position, movePosition);
        }
    }
}
