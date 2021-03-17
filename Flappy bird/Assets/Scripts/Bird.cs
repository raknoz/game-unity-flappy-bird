using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour {

    public float speed = 2;
    public float force = 300;

    // Start is called before the first frame update
    void Start() {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update() {
        //Jump with space bar
        if (Input.GetKeyDown(KeyCode.Space) /* Space bar*/
            || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) /* touch on the screen */
            || Input.GetMouseButtonDown(0) /* Mouse click */ ) {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
        }
    }

    //Resolve collisions betwend rigid elements
    void OnCollisionEnter2D(Collision2D collision) {
        //Reset Level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
