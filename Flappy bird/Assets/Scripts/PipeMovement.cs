using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour {

    // Movement of pipe (0 = static)
    public float speed = 0;

    //Time to invoque SwitchMovement
    public float switchTime = 2;

    //Distance
    private float distanceToDestroy = 32;

    // Start is called before the first frame update
    void Start() {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

        //Every switchTime seconds invoke the method SwitchMovement
        InvokeRepeating("SwitchMovement", 0, switchTime);
    }

    // Update is called once per frame
    void SwitchMovement() {
        GetComponent<Rigidbody2D>().velocity *= -1;
    }

    void Update() {
        //Remove pipes after pass the level

        //Get the position of the camera
		float xcam = Camera.main.transform.position.x;
        // Get the position of the pipe
        float xpipe = this.transform.position.x;

        if (xcam > xpipe + distanceToDestroy) {
            Destroy(this.gameObject);
        }
    }
}
