using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFIrstScript : MonoBehaviour {
    private void Awake() {
        Debug.Log("Awake Called");
    }

    // Start is called before the first frame update
    void Start() {
        Debug.Log("Start Called");
    }

    // Update is called once per frame
    void Update() {
        Debug.LogWarning("Update Called");
    }

    private void LateUpdate() {
        Debug.Log("LateUpdate Called");
    }
}
