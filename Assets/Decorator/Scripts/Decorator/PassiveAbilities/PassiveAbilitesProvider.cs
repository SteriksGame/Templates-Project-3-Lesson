using System;

public class PassiveAbilitesProvider : StatDecorator
{
    private PassiveAbilitiesTypes _passiveAbilities;

    private const int DOP_VALUE = 2;

    public PassiveAbilitesProvider(IStatProvider statProvider, PassiveAbilitiesTypes passiveAbilities) : base(statProvider)
    {
        _passiveAbilities = passiveAbilities;
    }

    public override Stat StatCalculation()
    {
        switch (_passiveAbilities)
        {
            case PassiveAbilitiesTypes.Persistent:
                _provider.Stat += new Stat(DOP_VALUE, 0, 0);
                break;

            case PassiveAbilitiesTypes.Flexible:
                _provider.Stat += new Stat(0, 0, DOP_VALUE);
                break;

            case PassiveAbilitiesTypes.Smart:
                _provider.Stat += new Stat(0, DOP_VALUE, 0);
                break;

            default:
                throw new ArgumentException(nameof(_passiveAbilities));
        }

        return _provider.StatCalculation();
    }
}