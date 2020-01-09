using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtTime : MonoBehaviour
{
    public float Time = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        // Time 시간이 경과한 후 자동으로 사라짐
        Destroy(gameObject, Time);
    }
}
