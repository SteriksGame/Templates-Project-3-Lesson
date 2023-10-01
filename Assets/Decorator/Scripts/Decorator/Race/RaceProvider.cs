using System;

public class RaceProvider : IStatProvider
{
    private RaceTypes _raceTypes;

    private const int DOP_VALUE = 5;

    public Stat Stat { get; set; }

    public RaceProvider(Stat stat, RaceTypes raceTypes)
    {
        Stat = stat;

        _raceTypes = raceTypes;
    }

    public Stat StatCalculation()
    {
        switch (_raceTypes)
        {
            case RaceTypes.Orc:
                Stat += new Stat(DOP_VALUE, 0, 0);
                break;

            case RaceTypes.Elf:
                Stat += new Stat(0, 0, DOP_VALUE);
                break;

            case RaceTypes.Human:
                Stat += new Stat(0, DOP_VALUE, 0);
                break;

            default:
                throw new ArgumentException(nameof(_raceTypes));
        }

        return Stat;
    }
}
