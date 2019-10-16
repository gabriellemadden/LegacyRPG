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
        Debug.Log("Buttons: " + bu + " Map: " + ma + " Splash: " + sp);
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
        Debug.Log("Buttons: " + bu + " Map: " + ma + " Splash: " + sp);

    }

    //void Start()
    //{
    //    moveTimer = moveTime;
    //    oldMousePos = Input.mousePosition;
    //}


    //void Update()
    //{
    //    //if mouse moves, want image to move. if mouse STOPS, want timer to run. 
    //    if (Mathf.Approximately(Input.GetAxis("Mouse X"), 0.0f) ||
    //        Mathf.Approximately(Input.GetAxis("Mouse Y"), 0.0f))
    //    {
    //        moveTimer -= Time.deltaTime;
    //        if (moveTimer < 0)
    //            moveTimer = 0;
    //    }
    //    else moveTimer = moveTime;

    //    Vector3 mousePos = Input.mousePosition;
    //    if (mousePos != oldMousePos) posOldRelative = mousePos - oldMousePos;

    //    scale = scalingFactor * moveTimer;

    //    if (posOldRelative.magnitude > 10.0f) posOldRelative = posOldRelative.normalized*10;

    //    Vector3 currentTransform = new Vector3(0, 0, 0);
    //    currentTransform.x = splash.transform.position.x + posOldRelative.x * scale - 625;
    //    currentTransform.y = (splash.transform.position.y + posOldRelative.y * scale - 350)*1.25f;
    //    //Debug.Log("Transform = " + currentTransform.x.ToString() + ", " + currentTransform.y.ToString());
    //    if (Mathf.Abs(currentTransform.x) < maxTransform 
    //        && Mathf.Abs(currentTransform.y) < maxTransform)
    //    {
    //        splash.transform.position += (posOldRelative) * scale;
    //        map.transform.position += (posOldRelative) * scale * 2;
    //        buttons.transform.position += (posOldRelative) * scale * 3;
    //    }

    //    oldMousePos = mousePos;
    //}

    Vector3 MakePositive (Vector3 vec)
    {
        if (vec.x < 0) vec.x *= -1;
        if (vec.y < 0) vec.y *= -1;
        if (vec.z < 0) vec.z *= -1;
        return vec;
    }
}

