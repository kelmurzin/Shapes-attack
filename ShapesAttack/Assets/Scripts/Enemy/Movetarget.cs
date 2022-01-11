using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movetarget : MonoBehaviour
{
    private Transform target;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if (target != null)
        {

            var direction = target.position - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        }
}
