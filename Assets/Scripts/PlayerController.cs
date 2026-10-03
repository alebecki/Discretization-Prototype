using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject shield;
    private KeyCode lastInput;
    public int playerDir;

    void Start() 
    {
        this.transform.position = GridManager.Instance.GetGridPos(1,1);
        shield.transform.position = this.transform.position + new Vector3(0f, 0.75f, 0f);
        playerDir = 1;
    }

    void Update() 
    {
        MovePlayer();
        MoveShield();
    }

    public void MoveShield() 
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && lastInput != KeyCode.UpArrow) 
        {
            lastInput = KeyCode.UpArrow;
            //transform.Rotate(0, 0, 180);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            shield.transform.position = this.transform.position + new Vector3(0f, 0.75f, 0f);
            playerDir = 1;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && lastInput != KeyCode.DownArrow) 
        {
            lastInput = KeyCode.DownArrow;
            //transform.Rotate(0, 0, 90);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            shield.transform.position = this.transform.position + new Vector3(0f, -0.75f, 0f);
            playerDir = 3;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && lastInput != KeyCode.RightArrow) 
        {
            lastInput = KeyCode.RightArrow;
            //transform.Rotate(0, 0, 90);
            transform.rotation = Quaternion.Euler(0, 0, 90);
            shield.transform.position = this.transform.position + new Vector3(0.75f, 0f, 0f);
            playerDir = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && lastInput != KeyCode.LeftArrow) 
        {
            lastInput = KeyCode.LeftArrow;
            //transform.Rotate(0, 0, -90);
            transform.rotation = Quaternion.Euler(0, 0, 90);
            shield.transform.position = this.transform.position + new Vector3(-0.75f, 0f, 0f);
            playerDir = 4;
        }
    }
    
    public void MovePlayer() 
    {
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            if (CanMoveCheck(transform.position + Vector3.up))
                transform.position += Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            if (CanMoveCheck(transform.position + Vector3.left))
                transform.position += Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            if (CanMoveCheck(transform.position + Vector3.down))
                transform.position += Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            if (CanMoveCheck(transform.position + Vector3.right))
                transform.position += Vector3.right;
        }
    }

    private bool CanMoveCheck(Vector3 newPos) 
    {
        if (newPos.x < 2 && newPos.x > -1 && newPos.y > -1 && newPos.y < 2) 
            return true;
        else
            return false;
        // if (newPos > )
    }
}
