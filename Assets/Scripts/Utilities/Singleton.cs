using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T get;
    void Awake()
    {
        if (get == null)
            get = FindObjectOfType<T>();
        else if (get != FindObjectOfType<T>())
            Destroy(FindObjectOfType<T>());
    }
}
