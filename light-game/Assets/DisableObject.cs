using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
    public GameObject obj;

    public void Disable()
    {
        obj.SetActive(false);
    }
}
