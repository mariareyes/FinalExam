using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {
    float speed = 3.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W) == true)//forward
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.A) == true)//left
        {
            transform.Rotate(0, 2f, 0);

        }
        else if (Input.GetKey(KeyCode.S) == true)//back
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);

        }
        else if (Input.GetKey(KeyCode.D) == true)//right
        {
            transform.Rotate(0, -2f, 0);

        }
    }
}
