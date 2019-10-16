using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAnimator : MonoBehaviour
{
    public GameObject layer0, layer1, layer2, layer3, canvas;
    public float scalingFactor = 0.1f;
    public float maxTransform = 125.0f;

    public float moveTime = 1.0f;
    float moveTimer;
    float scale;
    Vector3 oldMousePos;
    Vector3 posOldRelative;

    Vector3 l0, l1, l2, l3, mouse, can;
    public float layerOneOffset_Y;

    void Start()
    {
        can = canvas.transform.position;
        l0 = layer0.transform.position + can;
        l1 = layer1.transform.position + can;
        l2 = layer2.transform.position + can;
        l3 = layer3.transform.position + can;
    }

    void FixedUpdate()
    {
        mouse = Input.mousePosition;
        if (!(mouse.x <= 0 || mouse.x > Screen.width - 1))
        {
            mouse.x -= Screen.width / 2;
            l0.x = (mouse.x * scalingFactor * 8);
            l1.x = (mouse.x * scalingFactor * 4);
            l2.x = (mouse.x * scalingFactor * 2);
            l3.x = (mouse.x * scalingFactor * 1);
        }
        if (!(mouse.y <= 0 || mouse.x > Screen.height - 1))
        {
            mouse.y -= Screen.height / 2;
            l0.y = (mouse.y * scalingFactor * 8);
            l1.y = (mouse.y * scalingFactor * 4) + layerOneOffset_Y;
            l2.y = (mouse.y * scalingFactor * 2);
            l3.y = (mouse.y * scalingFactor * 1);
        }
        layer0.transform.position = l0 + can;
        layer1.transform.position = l1 + can;
        layer2.transform.position = l2 + can;
        layer3.transform.position = l3 + can;

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

    Vector3 MakePositive(Vector3 vec)
    {
        if (vec.x < 0) vec.x *= -1;
        if (vec.y < 0) vec.y *= -1;
        if (vec.z < 0) vec.z *= -1;
        return vec;
    }
}

