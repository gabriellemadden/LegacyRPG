using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
	public bool locked;
	public int keyID;

    void Start()
    {
		locked = true;
    }

    public override void Interact()
	{
        if (keyID >= Globals.playerKeys.Length)
        {
            Debug.Log("Invalid keyID (too high)");
        }
        if (locked) {
            if (Globals.playerKeys[keyID]) {
				locked = false;
                Debug.Log("Required key found in inventory.");
                dialog.SendThought("I have the key for this!");

                // wait a few seconds, play unlocking noise

                // display chest inventory
                return;
             }

            Debug.Log("Required key not in inventory.");
            dialog.SendThought(message);
            return;
		}
        // display chest inventory
        Debug.Log("Chest unlocked.");
    }
}
