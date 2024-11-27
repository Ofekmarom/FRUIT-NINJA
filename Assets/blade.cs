using UnityEngine;

public class blade : MonoBehaviour
{
    // prefab for the blades cutting trail
    public GameObject bladeTrailPrefab;
    // minimum speed required to cut
    public float minCuttingVelocity = .001f;

    // boolean to track whether cutting is active
    bool isCutting = false;

    // previous position of the blade
    Vector2 previousPosition;

    // current blade trail object
    GameObject currentBladeTrail;

    // Rigidbody2D and circle collider components
    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circleCollider;

    void Start()
    {
        // Initialize the main camera
        cam = Camera.main;
        // Initialize the Rigidbody2D component
        rb = this.GetComponent<Rigidbody2D>();
        // Initialize the CircleCollider2D component
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        // start cutting when the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        // stop cutting when the left mouse button is released
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        // update the cutting behavior if cutting is active
        if (isCutting)
        {
            UpdateCut();
        }
    }

    void StartCutting()
    {
        // set cutting to active
        isCutting = true;
        // create a new blade trail and put it on the blade
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        // store the initial position
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        // disable the collider at the start of cutting
        circleCollider.enabled = false;
    }

    void StopCutting()
    {
        // set cutting to inactive
        isCutting = false;
        // detach the blade trail from the blade
        currentBladeTrail.transform.SetParent(null);
        // destroy the blade trail after 2 seconds
        Destroy(currentBladeTrail, 2f);
        // disable the collider
        circleCollider.enabled = false;
    }

    void UpdateCut()
    {
        // calculate the new position of the blade based on mouse position
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        // update the blade's position
        this.rb.position = newPosition;

        // calculate the blade's speed
        float velocity = (newPosition - previousPosition).magnitude / Time.deltaTime;
        // enable the collider if the velocity exceeds the minimum cutting velocity
        if (velocity > minCuttingVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            // otherwise, disable the collider
            circleCollider.enabled = false;
        }

        // update the previous position to the current position
        previousPosition = newPosition;
    }
}
