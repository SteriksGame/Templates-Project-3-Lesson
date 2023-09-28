using System;
using UnityEngine;

public class Bootstap : MonoBehaviour
{
    [Header("Icon view factory:")]
    [SerializeField] private IconConfigTypes _iconConfigTypes;
    [SerializeField] private IconsConfig _iconFirstFactory, _iconSecondFactory;

    [Space]
    [SerializeField] private IconViewSetup _iconInitializer;

    private void Awake() => InitIconView();

    private void InitIconView()
    {
        IconFactory iconFactory;

        switch (_iconConfigTypes)
        {
            case IconConfigTypes.First:
                iconFactory = new FirstVersionFactory(_iconFirstFactory);
                break;

            case IconConfigTypes.Second:
                iconFactory = new SecondVersionFactory(_iconSecondFactory);
                break;

            default:
                throw new ArgumentException(nameof(_iconConfigTypes));
        }

        _iconInitializer.Initialized(iconFactory);
    }
}
