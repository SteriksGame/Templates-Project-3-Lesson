using UnityEngine;
using UnityEngine.UI;

public class IconViewSetup : MonoBehaviour
{
    [SerializeField] private Image _imageCoin;
    [SerializeField] private Image _imageEnergy;

    private IconFactory _iconFactory;

    public void Initialize(IconFactory iconFactory)
    {
        _iconFactory = iconFactory;

        SetIcon();
    }

    public void SetIcon()
    {
        _imageCoin.sprite = _iconFactory.Get(IconTypes.Coin).SpriteIcon;
        _imageEnergy.sprite = _iconFactory.Get(IconTypes.Energy).SpriteIcon;
    }
}
