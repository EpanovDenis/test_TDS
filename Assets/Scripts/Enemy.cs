using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public LayerMask enemySpawn;
    public float speedMovementEnemy;
    public int health;

    private Rigidbody2D enemyRB;
    private Vector2 movement;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();                
    }   

    private void FixedUpdate()
    {
        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemyRB.rotation = angle;        
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speedMovementEnemy * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
