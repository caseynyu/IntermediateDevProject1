using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public Transform cameraLocation1;
    public Transform cameraLocation2;
    public Transform cameraLocation3;
    public Transform cameraLocation4;
    public Transform cameraLocation5;
    public Transform cameraLocation6;
    public Transform cameraLocation7;
    public Transform cameraLocation8;
    public float smoothTime = 0.50F;
    private Vector3 velocity = Vector3.zero;
    public int cameraChoice = 1;
    public GameManager gameManager;
    void Start()
    {
        gameObject.transform.position = cameraLocation1.position;
    }

    void Update()
    {
        cameraChoice = gameManager.sceneNumber;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cameraChoice = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cameraChoice = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cameraChoice = 3;
            
        }
        switch (cameraChoice)
        {
            case 1:
                transform.position = Vector3.SmoothDamp(transform.position, cameraLocation1.position, ref velocity, smoothTime);
                break;
            case 2:
                transform.position = Vector3.SmoothDamp(transform.position, cameraLocation2.position, ref velocity, smoothTime);
                break;
            case 3:
                transform.position = Vector3.SmoothDamp(transform.position, cameraLocation3.position, ref velocity, smoothTime);
                break;
            case 4:
                transform.position = Vector3.SmoothDamp(transform.position, cameraLocation4.position, ref velocity, smoothTime);
                break;
            case 5:
                transform.position = Vector3.SmoothDamp(transform.position, cameraLocation5.position, ref velocity, smoothTime);
                break;
            case 6:
                transform.position = Vector3.SmoothDamp(transform.position, cameraLocation6.position, ref velocity, smoothTime);
                break;
            case 7:
                transform.position = Vector3.SmoothDamp(transform.position, cameraLocation7.position, ref velocity, smoothTime);
                break;
            case 8:
                transform.position = Vector3.SmoothDamp(transform.position, cameraLocation8.position, ref velocity, smoothTime);
                break;
        }
    }
}
