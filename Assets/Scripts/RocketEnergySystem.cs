using UnityEngine;
using Slider = UnityEngine.UI.Slider;


public class RocketEnergySystem : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void UpdateSlider(float value)
    {
        slider.value = value / 100;
    }
}


