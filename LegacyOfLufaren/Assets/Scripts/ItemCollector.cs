using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private List<Collider2D> collectedCoins = new List<Collider2D>();
    private bool isCollecting = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (isCollecting)
        {
            for (int i = collectedCoins.Count - 1; i >= 0; i--)
            {
                Collider2D coin = collectedCoins[i];
                if (coin != null)
                {
                    // Move cada moeada para o player
                    coin.transform.position = Vector3.MoveTowards(coin.transform.position, transform.position, 2.7f * Time.deltaTime);

                    // Verifica se a moeda chegou no jogador
                    if(Vector3.Distance(coin.transform.position, transform.position) < 0.1f)
                    {
                        // Remove a moeda da lista e destroi
                        collectedCoins.RemoveAt(i);
                        Destroy(coin.gameObject);
                    }
                }
                else
                {
                    collectedCoins.RemoveAt(i); // Remove moedas nulas para evitar erros
                }
            }
            // Se todas as moedas forem coletadas, para
            if (collectedCoins.Count == 0)
            {
                isCollecting = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            collectedCoins.Add(collision);
            isCollecting = true;
        }
    }
}
