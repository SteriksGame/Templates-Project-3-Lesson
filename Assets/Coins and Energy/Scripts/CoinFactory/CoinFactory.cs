using UnityEngine;

[CreateAssetMenu(fileName = "CoinFactory", menuName = "Factory/CoinFactory")]
public class CoinFactory : ScriptableObject
{
    [SerializeField] private Coin _coinPrefab;

    public Coin Get()
    {
        Coin coin = Instantiate(_coinPrefab);
        return coin;
    }
}
