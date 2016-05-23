using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    float Vertical, Horizontal, MouseX, MouseY;
    Vector3 direction;
    GameObject cameraObject;
    CharacterController characterController;

    public float Speed = 1f; 
    public bool InvertMouse;
	// Use this for initialization
	void Start () {
        cameraObject = gameObject.GetComponentInChildren<Camera>().gameObject;
        characterController = gameObject.GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        GetInputs();
        cameraObject.transform.Rotate(MouseY,0f,0f);
        transform.Rotate(0f,MouseX,0f);
        direction.z = Vertical;
        direction.x = Horizontal;
        direction  = transform.rotation * direction;
        characterController.Move(direction * Speed * Time.deltaTime);
	}
    void GetInputs() {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        MouseX = Input.GetAxis("Mouse X");
        MouseY = InvertMouse ? Input.GetAxis("Mouse Y"): -1f * Input.GetAxis("Mouse Y");
    }
}
