using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 1;
   void OnCollisionEnter(Collision col)
    {
        //int PlayerHP = col.getComponent<PlayerController>().currentHealth--;
        if(col.gameObject.tag.Equals("Player"))
        {
            col.gameObject.GetComponent<PlayerController>().currentHealth--;
            col.gameObject.GetComponent<PlayerUI>().currentHealth--;

            //Destroy(col.gameObject);
        }
    }
}
