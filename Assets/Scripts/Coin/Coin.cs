using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _costOfCoin;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent<Player>(out Player component))
        {
            collision.collider.GetComponent<Wallet>().Money++;
            Destroy(gameObject);
        }
    }
}
