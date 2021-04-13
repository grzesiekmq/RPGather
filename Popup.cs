using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] private GameObject shop;

    // Start is called before the first frame update
    private void Start()
    {
    }

    public void ShowShop()
    {
        shop.SetActive(true);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}