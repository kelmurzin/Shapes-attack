using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

public ControlType controlType;

public Joystick joystick;

    public enum ControlType
{
    PC,Android
}
 
    private Rigidbody2D rb;
    public Camera cam;
    
    public static float  moveSpeed;
    
    Vector2 movement;
    Vector2 mousePos;
            
    [Header("Ограничение передвижения")]
    [SerializeField] private int max_x;
    [SerializeField] private int min_x;
    [SerializeField] private int max_y;
    [SerializeField] private int min_y;   
    
    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();               
        moveSpeed = 6f;
        Time.timeScale = 1;
    }

    private void Update()
    {
               /*if(Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 0f;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Time.timeScale = 1f;
        }*/
        {
            if (this.transform.position.x > max_x)
                this.transform.position = new Vector3(max_x, this.transform.position.y, this.transform.position.z);

            if (this.transform.position.x < min_x)
                this.transform.position = new Vector3(min_x, this.transform.position.y, this.transform.position.z);//Ограничение передвижения 
            if (this.transform.position.y > max_y)
                this.transform.position = new Vector3(this.transform.position.x, max_y, this.transform.position.z);
            if (this.transform.position.y < min_y)
                this.transform.position = new Vector3(this.transform.position.x, min_y, this.transform.position.z);
        }

        if (controlType == ControlType.PC)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Verticale");
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }

        if(controlType == ControlType.Android)
        {
            movement.x = joystick.Horizontal;
            movement.y = joystick.Vertical;
        }        
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);        
    }
        
}    