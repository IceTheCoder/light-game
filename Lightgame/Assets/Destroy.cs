using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

    public float destroyTime = 3f;

    void Start () {
        Destroy(gameObject, destroyTime);
    }
}
