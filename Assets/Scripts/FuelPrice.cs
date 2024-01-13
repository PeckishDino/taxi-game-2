using UnityEngine;
using TMPro;

public class FuelPrice : MonoBehaviour
{
    public float fuelPrice = 0f;
    public TextMeshPro priceText;

    // Start is called before the first frame update
    void Start()
    {
        fuelPrice = Random.Range(1.0f, 1.5f);
        fuelPrice = RoundToTwoDecimalPlaces(fuelPrice);
        priceText.text = "Fuel Price\n£" + fuelPrice.ToString("F2") + "/L";
    }

    public float RoundToTwoDecimalPlaces(float number)
    {
        return Mathf.Round(number * 100) / 100f;
    }
}
