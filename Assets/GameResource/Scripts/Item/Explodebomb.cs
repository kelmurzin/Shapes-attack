using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodebomb : MonoBehaviour
{
   public GameObject bomb;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "EnemyBoss")
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

    private void Start() => StartCoroutine(c_Blinking(GetComponent<SpriteRenderer>()));
    
    IEnumerator c_Blinking(SpriteRenderer image)
    {
        Color c = image.color;
        float alpha = 1.0f;

        while (true)
        {
            c.a = Mathf.MoveTowards(c.a, alpha, Time.deltaTime);
            image.color = c;

            if (c.a == alpha)
            {
                if (alpha == 1.0f)
                    alpha = 0.3f;
                else
                    alpha = 1.0f;
            }

            yield return null;
        }
    }
}