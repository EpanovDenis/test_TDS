using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{    
    [SerializeField] private float speedBullet;
    [SerializeField] private ParticleSystem BulletPS;    
        
    void Update()
    {
        transform.Translate(Vector2.right * speedBullet * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(BulletPS, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
