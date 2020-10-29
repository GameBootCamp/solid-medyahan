using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float mouseSensitivity = 100f;

    private float rotX;
    private float rotY;

    private float minX = -60;
    private float maxX = 60;

    void Update()
    {
        rotX -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        rotY += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;

        rotX = Mathf.Clamp(rotX, minX, maxX);
        transform.GetChild(0).localRotation = Quaternion.Euler(rotX, 0, 0);
        
        transform.localRotation = Quaternion.Euler(0, rotY, 0);
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.3f);
    }
}
