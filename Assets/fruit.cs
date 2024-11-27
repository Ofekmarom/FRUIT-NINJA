using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruit : MonoBehaviour
{
    // prefab for the sliced fruit object
    public GameObject fruitSlicedPrefab;
    // initial force to launch the fruit
    public float startForce = 15f;

    // reference to the fruit's rigidbody
    Rigidbody2D rb;

    // start is called once before the first update execution after the monobehaviour is created
    void Start()
    {
        // get the rigidbody component attached to the fruit
        rb = this.GetComponent<Rigidbody2D>();
        // apply an upward force to the fruit to launch it
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    // called when the fruit's collider enters a trigger collider
    void OnTriggerEnter2D(Collider2D col)
    {
        // check if the collider belongs to the blade
        if (col.tag == "blade")
        {
            // calculate the direction from the blade to the fruit
            Vector3 direction = (col.transform.position - transform.position).normalized;

            // create a rotation based on the direction
            Quaternion rotation = Quaternion.LookRotation(direction);

            // instantiate the sliced fruit at the current position with the calculated rotation
            GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
            // destroy the sliced fruit object after 3 seconds
            Destroy(slicedFruit, 3f);
            // destroy the original fruit object immediately
            Destroy(gameObject);
        }
    }
}
