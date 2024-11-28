using UnityEngine;

public class Bussola : MonoBehaviour
{
    [SerializeField] private Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.target != null)
            transform.LookAt(this.target);
    }
}
