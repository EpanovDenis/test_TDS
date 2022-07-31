using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speedBullet;
    public float distanceShoot;
    public int damage;
    public ParticleSystem BulletPS;
    public ParticleSystem EnemyPS;

    private Vector2 startPosition;
    private float distance;

    private void Start()
    {
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speedBullet * Time.fixedDeltaTime);
        distance = Vector2.Distance(startPosition, transform.position);

        if (distance >= distanceShoot)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        

        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(EnemyPS, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);                  
        }
        else
        {
            Instantiate(BulletPS, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }
}
