using UnityEngine;
using System.Collections;

public class ballShoot : MonoBehaviour {
  

    // Sound effect to be played when we click.
    AudioSource _currentSource;

    Ray _lastRayCast;
    float _raycastDistance = 1.0f;


    // Use this for initialization
    void Start()
    {
        _currentSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        

        // Select an object based on mouse click.
        // button 0 is the left mouse button.
        if (Input.GetMouseButtonDown(0) == true)
        {
           Ray clickRay= Camera.main.ScreenPointToRay(Input.mousePosition);
          

            // This stores what we have hit with our raycast.
            RaycastHit hit;

            // Cast the click ray into the world and see what is hit.
            bool didHit = Physics.Raycast(clickRay, out hit);
            if (didHit)
            {
                
                // Grab the GameObject we hit, and store it for later.
                GameObject objectWeHit = hit.transform.gameObject;

                // Check to see if the object we've hit has an AudioSource..
                AudioSource objectWeHitAudio = objectWeHit.GetComponent<AudioSource>();
                if (objectWeHitAudio != null)
                {
                    // If so, play it!
                    objectWeHitAudio.Play();
                }

                // Store the distance of the last raycast.
                _raycastDistance = hit.distance;

                // Apply a force where the ray hit the object.
                if (hit.rigidbody != null)
                {
                   

                    // Spawn an explosion where the ray hit the object.
                    hit.rigidbody.AddExplosionForce(50.0f, hit.point, 10.25f);
                }

                
            }
        }
    }
}
