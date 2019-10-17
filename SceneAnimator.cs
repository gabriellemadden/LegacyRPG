using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAnimator : MonoBehaviour
{
    public GameObject layer0, layer1, layer2, layer3, canvas;
    public float scalingFactor = 0.1f;

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
}

