using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform target;
    public Transform pivot;
    [SerializeField] float rotationSpeed = 2f;
    void Update()
    {
        Vector3 direction = target.position - pivot.position;

        direction.y = 0;
        
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        pivot.rotation = Quaternion.Slerp(pivot.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }
}
