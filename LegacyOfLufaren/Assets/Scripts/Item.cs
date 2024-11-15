using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private static Text coinsText;
    private static int coinsCount = 0;
    void Start()
    {
        if (coinsText == null)
        {
            coinsText = GameObject.Find("Coins").GetComponent<Text>();
            UpdateCoinsText();
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coinsCount++;
            UpdateCoinsText();
            Destroy(gameObject);
        }
    }

    private void UpdateCoinsText()
    {
        if (coinsText != null)
        {
            coinsText.text = "Coins: " + coinsCount;
        }
    }
}
