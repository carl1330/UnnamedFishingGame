using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Transform movePoint;
    public Sprite playerUp;
    public Sprite playerDown;
    public Sprite playerLeft;
    public Sprite playerRight;
    public SpriteRenderer spriteRenderer;
    public LayerMask whatStopsMovement;
    public ScriptableObject script;

    void playerSprint()
    {
        if (!Input.GetKey(KeyCode.LeftShift))
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, 1.5f * moveSpeed * Time.deltaTime);
    }

    void playerMovement()
    {
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (Input.GetAxisRaw("Horizontal") < 0)
                    spriteRenderer.sprite = playerLeft;
                else
                    spriteRenderer.sprite = playerRight;

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }


            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (Input.GetAxisRaw("Vertical") < 0)
                    spriteRenderer.sprite = playerDown;
                else
                    spriteRenderer.sprite = playerUp;

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
        }
    }

    void playerCamera()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    } 

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //Makes the camera follow the player
        playerCamera();

        //Checks if player is running or not
        playerSprint();

        //If the player has reached movePoint, movePoint is then allowed to move.
        playerMovement();

        if(Input.GetKeyDown("space"))
        {

        }
    }
}

