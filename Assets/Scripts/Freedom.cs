using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Freedom
{
    public static bool f = true;
    public static GameObject player;
    public static float minDistance;
    public static bool cekDistance(GameObject obj)
    {
        return Vector3.Distance(player.transform.position, obj.transform.position) > minDistance;
    }
}
