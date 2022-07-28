using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float speedMovementEnemy;
    public int health;

    private Rigidbody2D enemyRB;
    private Vector2 movement;
    
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }            

    private void FixedUpdate()
    {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemyRB.rotation = angle;
        direction.Normalize();
        movement = direction;
        transform.Translate(direction * speedMovementEnemy * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
