using UnityEngine;

public class SpawnBonus : MonoBehaviour
{        
    public GameObject[] weaponBonus;
    public static GameObject activeWeapon;
    private float startSpawnWeaponTimer = 10f;
    private float spawnWeaponTimer;

    public GameObject[] gainBonus;
    private float startSpawnGiantTimer = 27f;
    private float spawnGiantTimer;


    public MeshCollider ground;
    public LayerMask mainCamera;

    private float x, y;
    private Vector2 spawnPosition;
    private bool check;        

    private void Start()
    {
        spawnWeaponTimer = startSpawnWeaponTimer;
        spawnGiantTimer = startSpawnGiantTimer;
    }

    void Update()
    {
        spawnWeaponTimer -= Time.deltaTime;
        spawnGiantTimer -= Time.deltaTime;
        SpawnWeaponBonus();
        SpawnGiantBonus();
    }

    private Vector2 GenerateRandomPoint()
    {
        x = Random.Range(ground.transform.position.x - Random.Range(0, ground.bounds.extents.x), ground.transform.position.x + Random.Range(0, ground.bounds.extents.x));
        y = Random.Range(ground.transform.position.y - Random.Range(0, ground.bounds.extents.y), ground.transform.position.y + Random.Range(0, ground.bounds.extents.y));
        spawnPosition = new Vector2(x, y);

        return spawnPosition;
    }

    private bool CheckPosition(Vector2 spawnposition)
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(spawnposition, 1f, mainCamera);


        if (collider.Length > 0)
        {
            check = true;
        }
        else
        {
            check = false;
        }
        return check;
    }

    private void SpawnWeaponBonus()
    {       
        if (spawnWeaponTimer <= 0 )
        {
            GenerateRandomPoint();            
            check = CheckPosition(spawnPosition);

            if (check == false)
            {               
                SpawnWeaponBonus();
            }
            else
            {
                int randomWeapon = Random.Range(0, weaponBonus.Length);
                
                if (weaponBonus[randomWeapon].name == activeWeapon.name)
                {                    
                    SpawnWeaponBonus();
                }
                else
                {
                    Instantiate(weaponBonus[randomWeapon], spawnPosition, Quaternion.identity);
                }                
            }
            spawnWeaponTimer = startSpawnWeaponTimer;
        }                   
    }

    private void SpawnGiantBonus()
    {
        if (spawnGiantTimer <= 0)
        {
            GenerateRandomPoint();
            check = CheckPosition(spawnPosition);

            if (check == false)
            {
                SpawnGiantBonus();
            }
            else
            {
                int randomGiant = Random.Range(0, gainBonus.Length);
                Instantiate(gainBonus[randomGiant], spawnPosition, Quaternion.identity);
            }
            spawnGiantTimer = startSpawnGiantTimer;
        }
    }
}
