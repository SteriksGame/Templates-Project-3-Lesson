using System;

public class SecondVersionFactory : IconFactory
{
    public SecondVersionFactory(IconsConfig config) : base(config) { }

    public override Icon Get(IconTypes iconTypes)
    {
        switch (iconTypes)
        {
            case IconTypes.Coin:
                return new SecondVersionCoin(_config.CoinImage);

            case IconTypes.Energy:
                return new SecondVersionEnergy(_config.EnergyImage);

            default:
                throw new ArgumentException(nameof(iconTypes));
        }
    }
}