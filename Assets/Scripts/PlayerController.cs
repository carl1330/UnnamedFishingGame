using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    enum Dir{
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    public float moveSpeed;
    public Transform movePoint;
    public Sprite playerUp;
    public Sprite playerDown;
    public Sprite playerLeft;
    public Sprite playerRight;
    public SpriteRenderer spriteRenderer;
    public LayerMask whatStopsMovement;
    private Dir dir;

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

        //Generate a fish by pressing space
        if(Input.GetKeyDown("space"))
        {
            checkIfPlayerCanFish();
        }
      
    }

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
                {
                    dir = Dir.LEFT;
                    spriteRenderer.sprite = playerLeft;
                }
                else
                {
                    dir = Dir.RIGHT;
                    spriteRenderer.sprite = playerRight;
                }

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }

            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (Input.GetAxisRaw("Vertical") < 0)
                {
                    dir = Dir.DOWN;
                    spriteRenderer.sprite = playerDown;
                }
                else
                {
                    dir = Dir.UP;
                    spriteRenderer.sprite = playerUp;
                }

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

    void checkIfPlayerCanFish()
    {
        Collider2D left = Physics2D.OverlapCircle(transform.position + Vector3.left, 0.2f);
        Collider2D right = Physics2D.OverlapCircle(transform.position + Vector3.right, 0.2f);
        Collider2D up = Physics2D.OverlapCircle(this.transform.position + Vector3.up, 0.2f);
        Collider2D down = Physics2D.OverlapCircle(this.transform.position + Vector3.down, 0.2f);
        switch (dir)
        {
            case Dir.LEFT:
                if (left != null)
                    playerFish(left.tag);
                break;
            case Dir.RIGHT:
                if (right != null)
                    playerFish(right.tag);
                break;
            case Dir.UP:
                if (up != null)
                    playerFish(up.tag);
                break;
            case Dir.DOWN:
                if (down == null)
                    playerFish(down.tag);
                break;
        }
    }

    void playerFish(string bodyOfWater)
    {
        FishableFishes fishes = GameObject.FindGameObjectWithTag(bodyOfWater).GetComponent<FishableFishes>();
        var whichFish = Random.Range(0,fishes.fishes.Length);
        Object.Instantiate(fishes.fishes[whichFish], this.transform);
    }
}

