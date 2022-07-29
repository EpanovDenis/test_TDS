using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    public float speedMovementPlayer;    
    public float speedRotationPlayer;

    private Rigidbody2D PlayerRB;

    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private Vector2 mousePosition;

    public static float deceleration = 1;

    private void Awake()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
    }   
    
    void Update()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speedMovementPlayer * deceleration;        

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;        
    }

    private void FixedUpdate()
    {
        PlayerRB.MovePosition(PlayerRB.position + moveVelocity * Time.fixedDeltaTime);

        float angel = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;      
        float step = speedRotationPlayer * Time.fixedDeltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, angel), step);
    }    
}
