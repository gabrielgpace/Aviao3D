using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    // MOVE
    public float speed = 5f;
    private float originalSpeed;
    [SerializeField] private float rotationSpeedUpDown = 45f;
    [SerializeField] private float rotationSpeedRightLeft = 70f;

    // UI
    private int _quantidadeMoeda;
    [SerializeField] private TMP_Text _textoMoeda;

    // MENUS
    public bool gameOver;

    // BOMBA
    [SerializeField] private GameObject bombPrefab;

    // COMBUSTÍVEL
    public Slider fuelSlider;
    public float fuelQuantity;
    public float fuelDecreaseRate = 1f;
    public float fuelIncreaseAmount = 20f;

    // BOOST
    public float boostSpeed = 10f;
    public float boostDuration = 2f;

    void Start()
    {
        _quantidadeMoeda = 0;
        originalSpeed = speed;
        fuelQuantity = fuelSlider.value;
        gameOver = false;
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropBomb();
        }

        _textoMoeda.SetText(_quantidadeMoeda.ToString());

        if (fuelQuantity > 0)
        {
            fuelQuantity -= fuelDecreaseRate * Time.deltaTime;
            fuelQuantity = Mathf.Clamp(fuelQuantity, 0, fuelSlider.maxValue);
            fuelSlider.value = fuelQuantity;
        }
        else
        {
            gameOver = true;
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
        // UP
        if (Input.GetKey(KeyCode.W))
            transform.Rotate(rotationSpeedRightLeft * Time.deltaTime, 0, 0);
        
        // DOWN
        if (Input.GetKey(KeyCode.S))
            transform.Rotate(-rotationSpeedRightLeft * Time.deltaTime, 0, 0);
        
        // LEFT
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, 0, rotationSpeedUpDown * Time.deltaTime);
        
        // RIGHT
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, 0, -rotationSpeedUpDown * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Moeda"))
        {
            _quantidadeMoeda++;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Combustivel"))
        {
            fuelQuantity = Mathf.Min(fuelSlider.maxValue, fuelQuantity + fuelIncreaseAmount);
            fuelSlider.value = fuelQuantity;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Boost"))
        {
            StartCoroutine(ActivateBoost());
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Alvo"))
        {
            Debug.Log("Você ganhou!");
        }
    }

    private void DropBomb()
    {
        Instantiate(bombPrefab, transform.position, transform.rotation);
    }

    private IEnumerator ActivateBoost()
    {
        speed = boostSpeed;
        yield return new WaitForSeconds(boostDuration);
        speed = originalSpeed;
    }
}
