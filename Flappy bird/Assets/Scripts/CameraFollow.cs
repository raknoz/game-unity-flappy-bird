using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    // Follow the chicken
    public Transform target;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        //New position of the camera chicken(X), camera(Y), camera(Z), 
        this.transform.position = new Vector3(
            target.position.x, 
            this.transform.position.y,
            this.transform.position.z
            );
    }
}
