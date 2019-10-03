using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Speed variable of 8
    [SerializeField] private float _speed = 8.4f;


    // Update is called once per frame
    void Update()
    {
        // translate laser up 
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        if(transform.position.y > 8f)
        {
            Destroy(gameObject);
        }
    }
}
