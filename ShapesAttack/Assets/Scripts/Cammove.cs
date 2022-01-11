using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cammove : MonoBehaviour
{
    [SerializeField] private float _leftLimit;
    [SerializeField] private float _rightLimit;
    [SerializeField] private float _bottomLimit;
    [SerializeField] private float _topLimit;
    Transform player;
    
    void Start()
    {
        player = FindObjectOfType<PlayerMove>().transform;
    }

    
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, _leftLimit, _rightLimit),
        Mathf.Clamp(transform.position.y, _bottomLimit, _topLimit),
        transform.localPosition.z);
    }
}
