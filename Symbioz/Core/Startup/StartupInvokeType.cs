namespace Symbioz.Core.Startup
{
    public enum StartupInvokeType
    {
        Config = 0,
        Base = 1,
        Sql = 2,
        Internal = 3,
        Others = 4,
        Cyclics = 5,
        End = 6
    }
}
