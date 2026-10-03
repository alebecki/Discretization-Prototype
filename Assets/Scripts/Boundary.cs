using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D otherObj) 
    {
        Debug.Log(otherObj.gameObject.name);
        GameManager.Instance.EndGame("Game over, enemy escaped!");
    }
}
