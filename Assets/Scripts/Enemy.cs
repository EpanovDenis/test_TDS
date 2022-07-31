using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;    
    public float speedMovementEnemy;
    public int health;
        
    public int pointForKill;    

    private Rigidbody2D enemyRB;
    private Vector2 movement;

    public GameObject counerScore;
    public Score score;

    private void Awake()
    {
        player = GameObject.Find("Player");
        counerScore = GameObject.Find("MainCamera");
    }

    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();                
    }

    private void Update()
    {
        if (health <= 0)
        {
            score = counerScore.GetComponent<Score>();
            score.AddedScore(pointForKill);
            Destroy(gameObject);            
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Shield.invulnerability == false)
        {
            GameManager.gameOver = true;
        }
    }
}
