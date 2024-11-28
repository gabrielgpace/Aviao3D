using UnityEngine;
using UnityEngine.SceneManagement;
public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject particlePrefab;
    [SerializeField] private float explosionDelay;
    public Camera cameraGameObject;
    private bool _isCameraActive;

    [SerializeField] private Transform bombHeight;
    void Start()
    {
        StartPosition();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Debug.Log("Left Alt");
            _isCameraActive = !_isCameraActive;
            cameraGameObject.enabled = _isCameraActive;;
        }
    }

    private void StartPosition()
    {
        
        transform.Rotate(0,0,180);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Chao") || bombHeight.position.y < 0)
        {
            if (particlePrefab != null)
            {
                GameObject particleObject = Instantiate(particlePrefab, transform.position, Quaternion.identity);
                
                Destroy(particleObject, explosionDelay);
                Destroy(gameObject);
            }
            
        }
        if (collision.CompareTag("Alvo"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Cena "+SceneManager.GetActiveScene().buildIndex);
            Destroy(gameObject);
        }
        
        
    }
}
