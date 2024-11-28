using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float shotDamage;
    
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (other.CompareTag("Player"))
        {
            player.fuelQuantity -= shotDamage;
            player.fuelQuantity = Mathf.Clamp(player.fuelQuantity, 0, player.fuelSlider.maxValue);
            player.fuelSlider.value = player.fuelQuantity;
            Debug.Log(player.fuelQuantity);
            Destroy(gameObject);
        }
    }
}
