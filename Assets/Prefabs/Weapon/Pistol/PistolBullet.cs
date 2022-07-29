using UnityEngine;

public class PistolBullet : MonoBehaviour
{    
    public float speedBullet;
    public int damage;
    public ParticleSystem BulletPS;
    public ParticleSystem EnemyPS;
        
    void Update()
    {
        transform.Translate(Vector2.right * speedBullet * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        

        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(EnemyPS, transform.position, Quaternion.identity);

            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            
            if (collision.gameObject.GetComponent<Enemy>().health <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
        else
        {
            Instantiate(BulletPS, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }
}
