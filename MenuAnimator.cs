using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimator : MonoBehaviour
{
    public GameObject buttons;
    public GameObject map;
    public GameObject splash;
    public GameObject canvas;
    public float scalingFactor = 0.1f;
    public float maxTransform = 125.0f;

    public float moveTime = 1.0f;
    float moveTimer;
    float scale;
    Vector3 oldMousePos;
    Vector3 posOldRelative;

    Vector3 bu, ma, sp, mouse, can;

    void Start()
    {
        can = canvas.transform.position;
        bu = buttons.transform.position + can;
        ma = map.transform.position + can;
        sp = splash.transform.position + can;
        //Debug.Log("Buttons: " + bu + " Map: " + ma + " Splash: " + sp);
    }

    void FixedUpdate()
    {
        mouse = Input.mousePosition;
        if(!(mouse.x <=0 || mouse.x > Screen.width - 1))
        {
            mouse.x -= Screen.width / 2;
            bu.x = (mouse.x * scalingFactor * 1);
            ma.x = (mouse.x * scalingFactor * 2);
            sp.x = (mouse.x * scalingFactor * 3);
        }
        if (!(mouse.y <= 0 || mouse.x > Screen.height - 1))
        {
            mouse.y -= Screen.height / 2;
            bu.y = (mouse.y * scalingFactor * 1);
            ma.y = (mouse.y * scalingFactor * 2);
            sp.y = (mouse.y * scalingFactor * 3);
        }
        buttons.transform.position = bu + can;
        map.transform.position = ma + can;
        splash.transform.position = sp + can;
        //Debug.Log("Buttons: " + bu + " Map: " + ma + " Splash: " + sp);

    }
}

