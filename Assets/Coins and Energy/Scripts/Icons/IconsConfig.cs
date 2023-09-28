using UnityEngine;

[CreateAssetMenu(fileName = "IconsConfig", menuName = "Factory/IconsConfig")]
public class IconsConfig : ScriptableObject
{
    [SerializeField] private Sprite _coinImage;
    [SerializeField] private Sprite _energyImage;

    public Sprite CoinImage => _coinImage;
    public Sprite EnergyImage => _energyImage;
}
