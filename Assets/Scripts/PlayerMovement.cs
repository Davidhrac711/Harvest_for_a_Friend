using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float dashSpeed = 15f;      
    public float dashLength = 0.2f;    
    public float dashCooldown = 1f;    

    private float activeMoveSpeed;     
    private float dashCounter;        //èas zpatky
    private float dashCoolCounter;    //èekání 

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        activeMoveSpeed = moveSpeed;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (dashCoolCounter > 0)   //odpoèet 
        {
            dashCoolCounter -= Time.deltaTime;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && dashCoolCounter <= 0 && dashCounter <= 0)
        {
            activeMoveSpeed = dashSpeed; // Zvednu rychlost na maximum
            dashCounter = dashLength;    // Zapnu odpoèet samotného úskoku
        }

        // Øešení probíhajícího Dashe
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            // (dobìhli jsme)
            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;     
                dashCoolCounter = dashCooldown;
            }
        }
    }

    void FixedUpdate()
    {
        // Fyzikální pohyb postavy s normalizací
        rb.MovePosition(rb.position + movement.normalized * activeMoveSpeed * Time.fixedDeltaTime);
    }
}
