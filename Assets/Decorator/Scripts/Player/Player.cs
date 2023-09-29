using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerConfig _config;

    private RaceTypes _race => _config.Race;
    private SpecificationTypes _specification => _config.Specification;
    private PassiveAbilitiesTypes _passiveAbilities => _config.PassiveAbilities;


    private IStatProvider _statProvider;

    public void Initialized(Stat stat)
    {
        _statProvider = new StatProvider(stat);

        switch (_race)
        {
            case RaceTypes.Orc:
                _statProvider = new OrcStatProvider(_statProvider);
                break;

            case RaceTypes.Elf:
                _statProvider = new ElfStatProvider(_statProvider);
                break;

            case RaceTypes.Human:
                _statProvider = new HumanStatProvider(_statProvider);
                break;

            default:
                throw new ArgumentException(nameof(_race));
        }

        switch (_specification)
        {
            case SpecificationTypes.Barbar:
                _statProvider = new BarbarStatProvider(_statProvider);
                break;

            case SpecificationTypes.Thied:
                _statProvider = new ThiedStatProvider(_statProvider);
                break;

            case SpecificationTypes.Mag:
                _statProvider = new MagStatProvider(_statProvider);
                break;

            default:
                throw new ArgumentException(nameof(_specification));
        }

        switch (_passiveAbilities)
        {
            case PassiveAbilitiesTypes.Persistent:
                _statProvider = new PersistentStatProvider(_statProvider);
                break;

            case PassiveAbilitiesTypes.Flexible:
                _statProvider = new FlexibleStatProvider(_statProvider);
                break;

            case PassiveAbilitiesTypes.Smart:
                _statProvider = new SmartStatProvider(_statProvider);
                break;

            default:
                throw new ArgumentException(nameof(_passiveAbilities));
        }

        _statProvider.CalculationIntellect();
        _statProvider.CalculationPower();
        _statProvider.CalculationAgility();

        ViewStat();
    }

    private void ViewStat()
    {
        Debug.Log("Интеллект: " + _statProvider.Stat.Intellect);
        Debug.Log("Сила: " + _statProvider.Stat.Power);
        Debug.Log("Ловкость: " + _statProvider.Stat.Agility);
    }
}