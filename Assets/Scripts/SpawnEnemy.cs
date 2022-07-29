using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject EnemySoldier;
    public GameObject EnemyNimble;
    public GameObject EnemyArmored;

    public MeshCollider ground;
    public LayerMask Camera;

    private float x, y;
    private Vector2 spawnPosition;
    private bool check;
    

    private float startSpawnCD = 2f;
    private float minSpawnCD = .5f;    
    private float stepCD = 10f;
    private float currentStepCD;
    private float reductionStepCD = .1f;
    private float spawnCD;
    private float currentSpawnCD;

    void Start()
    {        
        spawnCD = startSpawnCD;
        currentSpawnCD = spawnCD;
        currentStepCD = stepCD;
    }
        
    void Update()
    {
        spawnCD -= Time.deltaTime;
        currentStepCD -= Time.deltaTime;

        if (spawnCD <= 0)
        {
            SpawnSoldiers();
            spawnCD = currentSpawnCD;
            if (currentStepCD <= 0)
            {
                if (currentSpawnCD <= minSpawnCD)
                {
                    currentSpawnCD = minSpawnCD;
                }
                else
                {
                    currentSpawnCD -= reductionStepCD;
                    currentStepCD = stepCD;
                }
            }
        }    
    }

    
    private Vector2 GenerateRandomPoint()
    {
        x = Random.Range(ground.transform.position.x - Random.Range(0, ground.bounds.extents.x), ground.transform.position.x + Random.Range(0, ground.bounds.extents.x));
        y = Random.Range(ground.transform.position.y - Random.Range(0, ground.bounds.extents.y), ground.transform.position.y + Random.Range(0, ground.bounds.extents.y));
        spawnPosition = new Vector2(x, y);

        return spawnPosition;
    }    

    private bool CheckPosition(Vector2 spawnposition, float radiusObject)
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(spawnposition, radiusObject, Camera);


        if (collider.Length > 0)
        {            
            check = false;
        }
        else
        {            
            check = true;
        }
        return check;
    }

    private void SpawnSoldiers()
    {
        GenerateRandomPoint();        
        check = CheckPosition(spawnPosition, 1f);
        if (check == false)
        {            
            SpawnSoldiers();
        }
        else
        {
            int randomEnemy = Random.Range(0, 100);

            if (randomEnemy <= 10)
            {
                Instantiate(EnemyArmored, spawnPosition, Quaternion.identity);
            }
            else if (randomEnemy <= 40)
            {
                Instantiate(EnemyNimble, spawnPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(EnemySoldier, spawnPosition, Quaternion.identity);
            }
            
        }
    }
}
