using UnityEngine;

public class Camera : MonoBehaviour
{
    public float speed = 20f;
    public float rotateSpeed = 60f;

    void Update()
    {
        if (Time.timeScale == 0f) return;

        float x = 0f;
        float y = 0f;
        float z = 0f;

        if (Input.GetKey(KeyCode.LeftArrow)) x = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) x = 1f;

        if (Input.GetKey(KeyCode.UpArrow)) z = 1f;
        if (Input.GetKey(KeyCode.DownArrow)) z = -1f;

        if (Input.GetKey(KeyCode.KeypadPlus)) y = 1f;
        if (Input.GetKey(KeyCode.KeypadMinus)) y = -1f; 

        transform.position += new Vector3(x, y, z) * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f, Space.Self);
        }
    }
}
