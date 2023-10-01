using System;

public class SpecificationProvider : StatDecorator
{
    private SpecificationTypes _specification;

    private const int DOP_VALUE = 3;

    public SpecificationProvider(IStatProvider statProvider, SpecificationTypes specification) : base(statProvider)
    {
        _specification = specification;
    }

    public override Stat StatCalculation()
    {
        switch (_specification)
        {
            case SpecificationTypes.Barbar:
                _provider.Stat += new Stat(DOP_VALUE, 0, 0);
                break;

            case SpecificationTypes.Thied:
                _provider.Stat += new Stat(0, 0, DOP_VALUE);
                break;

            case SpecificationTypes.Mag:
                _provider.Stat += new Stat(0, DOP_VALUE, 0);
                break;

            default:
                throw new ArgumentException(nameof(_specification));
        }

        return _provider.StatCalculation();
    }
}
