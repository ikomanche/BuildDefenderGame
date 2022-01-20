using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    private Enemy targetEnemy;

    public static ArrowProjectile Create(Vector3 position,Enemy enemy)
    {
        Transform pfArrowProjectile = Resources.Load<Transform>("pfArrowProjectile");
        Transform arrowTransform = Instantiate(pfArrowProjectile, position, Quaternion.identity);

        ArrowProjectile arrowProjectile= arrowTransform.GetComponent<ArrowProjectile>();
        arrowProjectile.SetTarget(enemy);

        return arrowProjectile;
    }

    private Vector3 lastMoveDir;
    private float timeToDestroy = 3f;

    private void Update()
    {
        Vector3 moveDir;
        if(targetEnemy != null)
        {
            moveDir = (targetEnemy.transform.position - transform.position).normalized;
            lastMoveDir = moveDir;
        }
        else
        {
            moveDir = lastMoveDir;
        }
        
        float moveSpeed = 20f;
        transform.eulerAngles = new Vector3(0, 0, UtilsClass.GetVectorAngle(moveDir));
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        timeToDestroy -= Time.deltaTime;
        if(timeToDestroy < 0f)
        {
            Destroy(gameObject);
        }
    }
    private void SetTarget(Enemy targetEnemy)
    {
        this.targetEnemy = targetEnemy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy != null)
        {
            int damage = 15;
            enemy.GetComponent<HealthSystem>().Damage(damage);
            Destroy(gameObject);
        }
    }
}
