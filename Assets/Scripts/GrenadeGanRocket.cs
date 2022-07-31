using UnityEngine;

public class GrenadeGanRocket : MonoBehaviour
{
    public Rigidbody2D rocketRB;
    public float speedRocket;
    public int damage;

    private Vector2 startPosition;
    private Vector2 mousePosition;
    private Vector2 target;

    public ParticleSystem BulletPS;
    public ParticleSystem EnemyPS;

    private void Start()
    {
        rocketRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float angle = Mathf.Atan2(Weapon.target.y, Weapon.target.x) * Mathf.Rad2Deg;
        rocketRB.rotation = angle;        
        transform.position = Vector2.MoveTowards(transform.position, Weapon.target, speedRocket * Time.fixedDeltaTime);

        if (Vector2.Distance(transform.position, Weapon.target) <= 0)
        {
            Collider2D[] explosion = Physics2D.OverlapCircleAll(transform.position, 2f);

            if (explosion.Length > 0)
            {
                for (int i = 0; i < explosion.Length; i++)
                {
                    if (explosion[i].gameObject.tag == "Enemy")
                    {
                        Instantiate(EnemyPS, transform.position, Quaternion.identity);
                        explosion[i].gameObject.GetComponent<Enemy>().TakeDamage(damage);
                    }
                    else
                    {
                        Instantiate(BulletPS, transform.position, Quaternion.identity);
                    }
                }
            }

            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {       
        Destroy(gameObject);
    }
}
