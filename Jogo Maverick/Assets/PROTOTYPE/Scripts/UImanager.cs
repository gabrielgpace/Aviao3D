using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    [SerializeField] private Transform airplaneHeigh;
    [SerializeField] private TMP_Text airplaneHeighTxt;
    [SerializeField] private GameObject airPlaneHeighWarning;
    
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
        airplaneHeighTxt.SetText(airplaneHeigh.localPosition.y.ToString("0") + "m");
        
        if (airplaneHeigh.position.y > 100)
        {
            airPlaneHeighWarning.SetActive(true);
        }
        else
        {
            airPlaneHeighWarning.SetActive(false);
        }
    }
}
