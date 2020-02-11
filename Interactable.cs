using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public MainDialog dialog;
    public string message;

    public virtual void Interact()
    {
        dialog.SendThought(message);
    }
}
