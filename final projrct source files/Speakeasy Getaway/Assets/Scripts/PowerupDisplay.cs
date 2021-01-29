using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupDisplay : MonoBehaviour
{
    public Image icon;
    public Sprite[] Powerups;
    public Sprite activeSprite;

    public void Stable()
    {
        activeSprite = Powerups[0];
        icon.sprite = activeSprite;
    }

    public void Switch(int s)
    {
        switch(s)
        {
            case 0:
                activeSprite = Powerups[0];
                icon.sprite = activeSprite;
                break;
            case 1:
                activeSprite = Powerups[1];
                icon.sprite = activeSprite;
                break;
            case 2:
                activeSprite = Powerups[2];
                icon.sprite = activeSprite;
                break;
        }
    }
}
