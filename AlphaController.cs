using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaController : MonoBehaviour
{

    public void setAlpha(float alpha)
    {
        SpriteRenderer[] childRenderers = GetComponentsInChildren<SpriteRenderer>();
        Color newColor;
        foreach (SpriteRenderer child in childRenderers)
        {
            //check whether it has room trigger object; if does, check if auto alpha is set
            NewRoomTrigger triggerScript = child.GetComponentInParent<NewRoomTrigger>();
            if (triggerScript != null && !triggerScript.autoAlpha)
            {
                //do nothing because alpha is manual
            }
            else
            {
                newColor = child.color;
                newColor.a = alpha;
                child.color = newColor;
            }
        }
    }

}
