using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public static Transform[] checkp;
    void Awake()
    {
        checkp = new Transform[transform.childCount];
        for (int i = 0; i < checkp.Length; i++)
        {
            checkp[i] = transform.GetChild(i);
        }
    }
}
