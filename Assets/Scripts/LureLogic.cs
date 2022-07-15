using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LureLogic : MonoBehaviour
{
    public GameObject fishingCollider;
    public PlayerController player;
    public SpinFishing control;
    public bool bounce = true;
    public float force = 2;
    public float forceInitial;
    private void Start()
    {
        forceInitial = force;
    }
    // Start is called before the first frame update
    private void Update()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        moveFishingCollider();
    }

    void moveFishingCollider()
    {
        if(player.dir==PlayerController.Dir.LEFT)
        {
            fishingCollider.transform.position = new Vector2(player.transform.position.x - 50.5f, player.transform.position.y - 0.5f);
        }
        if (player.dir == PlayerController.Dir.RIGHT)
        {
            fishingCollider.transform.position = new Vector2(player.transform.position.x + 50.5f, player.transform.position.y - 0.5f);
        }
        if (player.dir == PlayerController.Dir.DOWN)
        {
            fishingCollider.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - control.power * 0.8f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "FishingCollider" && bounce)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-GetComponent<Rigidbody2D>().velocity.x - 0.2f,force), ForceMode2D.Impulse);
            GetComponent<Rigidbody2D>().gravityScale = 0.9f;
            force -= 0.4f;
        }
        if (force <= 0)
        {
            bounce = false;
            force = forceInitial;
        }
            
    }
}
