using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>()?.AddCoins();
        }

        Destroy(gameObject);
    }

}
