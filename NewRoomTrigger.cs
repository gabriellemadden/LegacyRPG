using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NewRoomTrigger : MonoBehaviour
{
    float alphaTime = 0.4f;
    float alphaTimer;
    public bool inRoom;
    public bool autoAlpha = true;
    public GameObject roomToEnter;
    public Tilemap roomToEnterTiles;
    public GameObject roomToExit;
    public Tilemap roomToExitTiles;
    public GameObject exitMat;
    NewRoomTrigger roomToExitTrigger;
    GameObject[] childrenEnter;
    GameObject[] childrenExit;
    bool inRoomActive = true;
    Room room;

    AlphaController roomToEnterAlpha;
    AlphaController roomToExitAlpha;

    void Start()
    {
        alphaTimer = 0;
        roomToEnterAlpha = roomToEnter.GetComponent<AlphaController>();
        roomToExitAlpha = roomToExit.GetComponent<AlphaController>();
        roomToExitTrigger = exitMat.GetComponent<NewRoomTrigger>();
        if (!inRoom)
        {
            roomToEnterAlpha.setAlpha(0.0f);
            Color newColor = roomToEnterTiles.color;
            newColor.a = 0.0f;
            roomToEnterTiles.color = newColor;
        }
        childrenEnter = new GameObject[roomToEnter.transform.childCount];
        childrenExit = new GameObject[roomToExit.transform.childCount];
        for (int i = 0; i < roomToEnter.transform.childCount; i++)
        {
            childrenEnter[i] = roomToEnter.transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < roomToExit.transform.childCount; i++)
        {
            childrenExit[i] = roomToExit.transform.GetChild(i).gameObject;
        }
        room = roomToEnter.GetComponent<Room>();
        if (room != null && room.startRoom)
        {
            foreach (GameObject child in childrenExit)
            {
                child.SetActive(false);
            }
            exitMat.SetActive(true);
        }
    }

    void Update()
    {
        if (room != null && room.startRoom) return;
        if (inRoom && alphaTimer > 0)
        {
            //set the entered room active before changing alpha
            if (!inRoomActive)
            {
                foreach (GameObject child in childrenEnter)
                {
                    child.SetActive(inRoom);
                }
                inRoomActive = true;
            }

            float newRoomAlpha = 1 - alphaTimer / alphaTime;
            if (newRoomAlpha < 0) newRoomAlpha = 0;
            else if (newRoomAlpha > 1) newRoomAlpha = 1;
            float oldRoomAlpha = alphaTimer / alphaTime;
            if (oldRoomAlpha < 0) oldRoomAlpha = 0;

            Color newColor = roomToEnterTiles.color;
            newColor.a = newRoomAlpha;
            roomToEnterTiles.color = newColor;
            newColor = roomToExitTiles.color;
            newColor.a = oldRoomAlpha;
            roomToExitTiles.color = newColor;
            roomToEnterAlpha.setAlpha(newRoomAlpha);
            roomToExitAlpha.setAlpha(oldRoomAlpha);
            alphaTimer -= Time.deltaTime;

            //set the exited room inactive after changing alpha
            if (alphaTimer < 0)
            {
                foreach (GameObject child in childrenExit)
                {
                    child.SetActive(false);
                }
                //make rooms true alpha values
                roomToExitAlpha.setAlpha(0.0f);
                newColor = roomToEnterTiles.color;
                newColor.a = 0.0f;
                roomToExitTiles.color = newColor;

                roomToEnterAlpha.setAlpha(1.0f);
                newColor = roomToEnterTiles.color;
                newColor.a = 1.0f;
                roomToEnterTiles.color = newColor;


                exitMat.SetActive(true);
                alphaTimer = 0;
            }
        }
        else if (!inRoom && alphaTimer != alphaTime)
        {
            alphaTimer = alphaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController controller = collision.GetComponent<PlayerController>();
        if (controller != null)
        {
            inRoom = true;
            inRoomActive = false;
            roomToExitTrigger.inRoom = false;
            if (room != null && room.startRoom)
                room.startRoom = false;
        }
    }

} 
