using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
   [SerializeField] public int hp;

    void OnTriggerEnter2D(Collider2D otherObj) 
    {
        if (otherObj.gameObject.GetComponent<Move>() != null && otherObj.gameObject.GetComponent<Move>().isSolid == true) 
        {
            hp -= 1;
        }

        if (hp <= 0) 
        {
            Destroy(this.gameObject);
        }
    }
}
