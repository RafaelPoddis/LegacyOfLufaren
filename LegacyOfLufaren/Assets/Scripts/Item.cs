using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText; // TextMeshProUGUI para textos na UI
    private static int coinsCount = 0;

    void Start()
    {
        // Se coinsText não foi atribuído no Inspector, busca automaticamente
        if (coinsText == null)
        {
            coinsText = GameObject.Find("COINS").GetComponent<TextMeshProUGUI>();
            UpdateCoinsText();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coinsCount++; // Incrementa o contador de moedas
            UpdateCoinsText(); // Atualiza o texto
            Destroy(gameObject); // Destroi o objeto (moeda)
        }
    }

    private void UpdateCoinsText()
    {
        if (coinsText != null)
        {
            coinsText.text = "COINS " + coinsCount; // Atualiza o texto na UI
        }
    }
}
