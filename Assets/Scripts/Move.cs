using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Left,
    Right,
}

public class Move : MonoBehaviour
{

    public ParticleSystem[] explosions;
    public bool isSolid;
    public float speedModifier = 100f;
    private Vector3 moveDir;
    public Direction dir;
    public GameObject player;

    void Awake() 
    {
        player = GameObject.Find("player");
        isSolid = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (dir)
        {
            case Direction.Up:
                moveDir = Vector3.up;
                break;
            case Direction.Down:
                moveDir = Vector3.down;
                break;
            case Direction.Left:
                moveDir = Vector3.left;
                break;
            case Direction.Right:
                moveDir = Vector3.right;
                break;
        }
        this.transform.position += moveDir / speedModifier;
    }

    public void OnTriggerExit2D(Collider2D otherObj) 
    {
        if (otherObj.gameObject.tag.Equals("Wall")) 
        {
            isSolid = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D otherObj) 
    {
        int playerDir = player.GetComponent<PlayerController>().playerDir;
        if (otherObj.gameObject.tag.Equals("Shield")) 
        {
            if(playerDir == 1 && dir == Direction.Down)
            {
                Die();
            }
            if (playerDir == 2 && dir == Direction.Left)
            {
                Die();
            }
            if (playerDir == 3 && dir == Direction.Up)
            {
                Die();
            }
            if (playerDir == 4 && dir == Direction.Right)
            {
                Die();
            }
        }        

        if (otherObj.gameObject.tag.Equals("Wall") && isSolid == true) 
        {
            Die();
        }
    }

    public void Die() 
    {
        foreach(ParticleSystem partSys in explosions) 
            partSys.Play();
        
        //GameManager.Instance.ShakeCam();

        Destroy(this.transform.gameObject.GetComponent<SpriteRenderer>());
        Destroy(this.transform.gameObject.GetComponent<Rigidbody2D>());
        Destroy(this.transform.gameObject.GetComponent<BoxCollider2D>());
        Destroy(this.gameObject, 1f); 
    }
}
