namespace AbstractFactoryAuto
{
    #region FactoryInterface

    public interface IAutoFactory
    {
        IEngine CreateEngine();
        IBody CreateBody();
        ISalon CreateSalon();
        IWheels CreateWheels();
    }

    #endregion

    #region AutoPartsInterfaces

    public interface ISalon
    {
        int SeatsNumber { get; }
        Color Color { get; }
        SalonMaterial Material { get; }
    }

    public interface IBody
    {
        Color Color { get; }
        BodyMaterial Material { get; }
    }

    public interface IEngine
    {
        int Capacity { get; }
        EngineType Type { get; }
    }

    public interface IWheels
    {
        int WheelsCount { get; }
        double DiskDiameter { get; }
        double Width { get; }
        WheelsType Type { get; }
    }

    #endregion
}
