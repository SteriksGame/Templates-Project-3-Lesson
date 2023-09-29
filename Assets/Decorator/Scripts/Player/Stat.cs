using System;

public class Stat
{
    private int _power;
    private int _intellect;
    private int _agility;

    public Stat(int power, int intellect, int agility)
    {
        Power = power;
        Intellect = intellect;
        Agility = agility;
    }

    public int Power 
    { 
        get { return _power; }
        private set
        {
            if(value < 0)
                throw new ArgumentOutOfRangeException(nameof(_power));

            _power = value;
        }
    }
    public int Intellect 
    {
        get { return _intellect; }
        private set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(_intellect));

            _intellect = value;
        }
    }
    public int Agility 
    {
        get { return _agility; }
        private set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(_agility));

            _agility = value;
        }
    }

    public static Stat operator +(Stat stats1, Stat stats2)
    {
        return new Stat(
            stats1.Power + stats2.Power, 
            stats1.Intellect + stats2.Intellect, 
            stats1.Agility + stats2.Agility);
    }

    public static Stat operator *(Stat stats1, Stat stats2)
    {
        return new Stat(
            stats1.Power * stats2.Power,
            stats1.Intellect * stats2.Intellect,
            stats1.Agility * stats2.Agility);
    }
}
