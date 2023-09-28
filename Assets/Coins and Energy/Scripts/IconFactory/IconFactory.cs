public abstract class IconFactory
{
    protected IconsConfig _config;

    public IconFactory(IconsConfig config) => _config = config;

    public abstract Icon Get(IconTypes iconTypes);
}