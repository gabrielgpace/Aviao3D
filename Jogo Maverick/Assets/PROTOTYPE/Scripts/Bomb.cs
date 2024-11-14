using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject particulas;
    
    void Start()
    {
        startPosition();
    }

    private void startPosition()
    {
        transform.position = new Vector3(0,-5,0);
        transform.Rotate(0,0,180);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Chao"))
        {
            Destroy(gameObject);
            particulas.SetActive(true);
            //EXPLODE
        }
    }
}
