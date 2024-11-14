using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    //MOVE
    public float speed = 5f;
    [SerializeField] private float rotationSpeedUpDown = 45f;
    [SerializeField] private float rotationSpeedRightLeft = 70f;

    //UI
    private int quantidadeMoeda;
    [SerializeField] private TMP_Text textoMoeda;

    //BOMBA
    [SerializeField] private GameObject bombPrefab;

    void Start()
    {
        quantidadeMoeda = 0;
    }
    void Update()
    {
        Move();
        textoMoeda.SetText(quantidadeMoeda.ToString());

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Bomb();
        }
        
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Moeda"))
        {
            ++quantidadeMoeda;
            
            Destroy(other.gameObject);

        }
    }

    private void Bomb()
    {
        Instantiate(bombPrefab,transform.position, transform.rotation);
    }
}
