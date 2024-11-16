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
    private int _quantidadeCombustivel;
    [SerializeField] private TMP_Text _textoMoeda;

    // BOMBA
    [SerializeField] private GameObject bombPrefab;
    
    // COMBUSTIVEL
    public Slider fuelSlider;
    public float fuelDecreaseRate = 1f;
    public float fuelIncreaseAmount = 20f;

    // BOOST
    public float boostSpeed = 10f;
    public float boostDuration = 2f;

    void Start()
    {
        _quantidadeMoeda = 0;
        originalSpeed = speed;
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropBomb();
        }
        _textoMoeda.SetText(_quantidadeMoeda.ToString());

        if (fuelSlider.value > 0)
        {
            fuelSlider.value -= fuelDecreaseRate * Time.deltaTime;
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        
        // UP
        if (Input.GetKey(KeyCode.W))
            transform.Rotate(0, 0, -rotationSpeedUpDown * Time.deltaTime);
        
        // DOWN
        if (Input.GetKey(KeyCode.S))
            transform.Rotate(0, 0, rotationSpeedUpDown * Time.deltaTime);
        
        // LEFT
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(rotationSpeedRightLeft * Time.deltaTime, 0, 0);
        
        // RIGHT
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(-rotationSpeedRightLeft * Time.deltaTime, 0, 0);
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
            fuelSlider.value = Mathf.Min(fuelSlider.maxValue, fuelSlider.value + fuelIncreaseAmount);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Boost"))
        {
            StartCoroutine(ActivateBoost());
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Alvo"))
        {
            Debug.Log("Voce ganhou!");
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
