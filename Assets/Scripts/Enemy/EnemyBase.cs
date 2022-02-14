using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] private float speed;    
    [SerializeField] protected GameObject health;
    [SerializeField] private int hp;
    [SerializeField] protected int pointEnemy;
    private Transform target;

    protected virtual void Start()
    {
        health.SetActive(false);
        target =
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {

        if (target != null)
        {

            transform.position =
                Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }

    }
}