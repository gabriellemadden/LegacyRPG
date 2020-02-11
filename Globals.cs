using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public static class Globals
{
    public static bool[] playerKeys = new bool[64];

    public static void WaitForSeconds(int seconds)
    {
        var ts = DateTime.Now + TimeSpan.FromSeconds(seconds);
        do { } while (DateTime.Now < ts);
    }
}