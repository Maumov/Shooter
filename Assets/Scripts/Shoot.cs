using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    Camera camera;
    bool fire1;

    Ray ray;
    RaycastHit hit;
    // Use this for initialization
    void Start()
    {

        camera = gameObject.GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        if (fire1)
        {
            Fire();
        }

    }
    void GetInputs()
    {
        fire1 = Input.GetButtonDown("Fire1");
    }
    void Fire()
    {
        ray = camera.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f));
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Shooted " + hit.collider.name);
            Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();
            if (rb != null) {
                rb.AddForce(ray.direction * 15f,ForceMode.Impulse);
            }
        }
        else {
            Debug.Log("Miss");
        }
        
    }
}
