using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] private GameObject[] Item;
    
    public void generateLoot()
    {
        GameObject randomprefab = Item[Random.Range(0, Item.Length)];
        var range = Random.Range(0f, 150f);
        if (20f > range)
                    Instantiate(randomprefab, transform.position, Quaternion.identity);
        
    }
}