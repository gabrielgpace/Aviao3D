using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] private float rotationSpeedUpDown = 45f;
    [SerializeField] private float rotationSpeedRightLeft = 70f;

    private int quantidadeMoeda;
    [SerializeField] private TMP_Text textoMoeda;

    void Start()
    {
        quantidadeMoeda = 0;
    }
    void Update()
    {
        Move();
        textoMoeda.SetText(quantidadeMoeda.ToString());
        
    }

    private void Move()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        //UP
        if (Input.GetKey(KeyCode.W))
            transform.Rotate(0, 
                0, 
                -rotationSpeedUpDown * Time.deltaTime);
        //DOWN
        if (Input.GetKey(KeyCode.S))
            transform.Rotate(0, 
                0, 
                rotationSpeedUpDown * Time.deltaTime);
        //LEFT
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(rotationSpeedRightLeft * Time.deltaTime,
                0, 
                0
                );
        //RIGHT
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(-rotationSpeedRightLeft * Time.deltaTime, 
                0, 
                0
                );
    }
    private void OnCollisionEnter(Collider collision)
    {
        if(collision.CompareTag("Moeda"))
        {
            ++quantidadeMoeda;
            
            Destroy(gameObject);

        }
    }
}
