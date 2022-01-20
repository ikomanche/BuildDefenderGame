using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]private float shootTimerMax;
    private float shootTimer;
    private Enemy targetEnemy;
    private float lookForTargetTimer;
    private float lookForTargetTimerMax = .2f;
    private Vector3 arrowPosition;

    private void Awake()
    {
        arrowPosition = transform.Find("arrowPosition").position;
    }
    private void Update()
    {        
        LookForTargetTimer();
        HandleShooting();
    }

    private void HandleShooting()
    {
        if(targetEnemy == null)
        {
            return;
        }

        shootTimer -= Time.deltaTime;
        if (shootTimer < 0f)
        {
            shootTimer += shootTimerMax;
            ArrowProjectile.Create(arrowPosition, targetEnemy);
        }
    }

    private void LookForTargetTimer()
    {
        lookForTargetTimer -= Time.deltaTime;
        if (lookForTargetTimer < 0f)
        {
            lookForTargetTimer += lookForTargetTimerMax;
            LookForTargets();
        }
    }
    private void LookForTargets()
    {
        float targetMaxRadius = 20f;
        Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(transform.position, targetMaxRadius);

        foreach (Collider2D collider2D in collider2DArray)
        {
            Enemy enemy= collider2D.GetComponent<Enemy>();

            if (enemy != null)
            {
                //enemy!
                if (targetEnemy == null)
                {
                    targetEnemy = enemy;
                }
                else
                {
                    if (Vector3.Distance(transform.position, enemy.transform.position) <
                       Vector3.Distance(transform.position, targetEnemy.transform.position))
                    {
                        targetEnemy = enemy;
                    }
                }
            }
        }
    }
}
