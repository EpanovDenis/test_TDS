using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public GameObject deathZone;
    public int amountDeathZone;
    public float radiusDeathZone;
    
    public GameObject decelerationZone;
    public int amountDecelerationZone;
    public float radiusDecelerationZone;    

    public float distanseToObject;

    public MeshCollider ground;

    private float x, y;
    private bool check;
    private Vector2 spawnPosition;        

    private void Awake()
    {
        SpawnZones();
    }       
    /// <summary>
    /// ����� ������������ ��������� ���������� �� �������� � ���������� �������������.
    /// </summary>
    /// <returns>Vector2</returns>
    private Vector2 GenerateRandomPoint()
    {
        x = Random.Range(ground.transform.position.x - Random.Range(0, ground.bounds.extents.x), ground.transform.position.x + Random.Range(0, ground.bounds.extents.x));
        y = Random.Range(ground.transform.position.y - Random.Range(0, ground.bounds.extents.y), ground.transform.position.y + Random.Range(0, ground.bounds.extents.y));
        spawnPosition = new Vector2(x,y);

        return spawnPosition;       
    }

    /// <summary>
    /// ����� ����������� ���������� Vector2, ������ ������, ��������� �� �������� �������� � ����������� ����� �� � ���� ����� ���������� ������.
    /// </summary>
    /// <param name="spawnposition"></param>
    /// <param name="radiusObject"></param>
    /// <param name="distanceToObject"></param>
    /// <returns>bool</returns>
    private bool CheckPosition(Vector2 spawnposition, float radiusObject, float distanceToObject)
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(spawnposition, radiusObject + distanceToObject);

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

    /// <summary>
    /// ����� ����������� ���� � �������������� � ���������� �����, � ����������� �� �� ���������� � �������.
    /// </summary>
    private void SpawnZones()
    {
        for (int i = 0; i < amountDeathZone; i++)
        {
            GenerateRandomPoint();
            check = CheckPosition(spawnPosition, radiusDeathZone, distanseToObject);
            if (check == false)
            {
                Debug.Log("����� �������");
                amountDeathZone++;
                GenerateRandomPoint();
            }
            else
            {
                Instantiate(deathZone, spawnPosition, Quaternion.identity);
            }

        }

        for (int i = 0; i < amountDecelerationZone; i++)
        {
            GenerateRandomPoint();
            CheckPosition(spawnPosition, radiusDecelerationZone, distanseToObject);
            if (check == false)
            {
                Debug.Log("����� �������");
                amountDecelerationZone++;
                GenerateRandomPoint();
            }
            else
            {
                Instantiate(decelerationZone, spawnPosition, Quaternion.identity);
            }
        }
    }
}
