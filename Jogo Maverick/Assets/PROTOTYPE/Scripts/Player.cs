using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] private float rotationSpeedUpDown = 45f;
    [SerializeField] private float rotationSpeedRightLeft = 45f;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        //UP
        if (Input.GetKey(KeyCode.W))
            transform.Rotate(0, 0, -rotationSpeedUpDown * Time.deltaTime);
        //DOWN
        if (Input.GetKey(KeyCode.S))
            transform.Rotate(0, 0, rotationSpeedUpDown * Time.deltaTime);
        //LEFT
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0,-rotationSpeedRightLeft * Time.deltaTime, 0);
        //RIGHT
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0,rotationSpeedRightLeft * Time.deltaTime, 0);
    }
}
