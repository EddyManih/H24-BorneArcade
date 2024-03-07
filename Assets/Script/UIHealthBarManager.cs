using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIHealthBarManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] HealthManagerSO healthManagerSO;

    private void Start()
    {
        ChangeSliderValue(healthManagerSO.health);
    }

    private void OnEnable()
    {
        healthManagerSO.healthChangeEvent.AddListener(ChangeSliderValue);
    }

    private void OnDisable()
    {
        healthManagerSO.healthChangeEvent.RemoveListener(ChangeSliderValue);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            healthManagerSO.DecreaseHealth(10);
        }
    }

    private float ConvertIntToFloatDecimal(int amount)
    {
        return (float)amount / 100;
    }

    public void ChangeSliderValue(int amount)
    {
        slider.value = ConvertIntToFloatDecimal(amount);
    }
}
