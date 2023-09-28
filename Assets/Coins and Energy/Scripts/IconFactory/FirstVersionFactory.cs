using System;

public class FirstVersionFactory : IconFactory
{
    public FirstVersionFactory(IconsConfig config) : base(config) { }

    public override Icon Get(IconTypes iconTypes)
    {
        switch (iconTypes) 
        {
            case IconTypes.Coin:
                return new FirstVersionCoin(_config.CoinImage);

            case IconTypes.Energy:
                return new FirstVersionEnergy(_config.EnergyImage);

            default:
                throw new ArgumentException(nameof(iconTypes));
        }
    }
}
