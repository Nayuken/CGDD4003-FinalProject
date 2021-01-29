using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer : MonoBehaviour
{
    public int playerHP = 40;
    int damage = 10;

    void Start()
    {
        print (playerHP);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Enemy")
        {
            playerHP -= damage;
        }
    }

    private void OnGUI()
    {

        GUI.Label(new Rect(40, 60, 100, 100), "health : " + playerHP);
    }
}
