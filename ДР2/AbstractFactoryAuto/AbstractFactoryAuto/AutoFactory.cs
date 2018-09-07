namespace AbstractFactoryAuto
{

    #region BMW

    public class BMW_Factory : IAutoFactory
    {
        public IBody CreateBody()
        {
            return new BMW_Body();
        }

        public ISalon CreateSalon()
        {
            return new BMW_Salon();
        }

        public IEngine CreateEngine()
        {
            return new BMW_Engine();
        }

        public IWheels CreateWheels()
        {
            return new BMW_Wheels();
        }
    }

    public class BMW_Wheels : IWheels
    {
        public int WheelsCount => 3; // =)
        public double DiskDiameter => 50;
        public double Width => 5;
        public WheelsType Type => WheelsType.Summer;
    }

    public class BMW_Engine : IEngine
    {
        public int Capacity => 85;
        public EngineType Type => EngineType.Petrol;
    }

    public class BMW_Salon : ISalon
    {
        public int SeatsNumber => 5;
        public Color Color => Color.Beige;
        public SalonMaterial Material => SalonMaterial.Velour;
    }

    public class BMW_Body : IBody
    {
        public Color Color => Color.Black;
        public BodyMaterial Material => BodyMaterial.Steel;
    }

    #endregion

    #region AUDI

    public class AUDI_Factory : IAutoFactory
    {
        public IBody CreateBody()
        {
            return new AUDI_Body();
        }

        public ISalon CreateSalon()
        {
            return new AUDI_Salon();
        }

        public IEngine CreateEngine()
        {
            return new AUDI_Engine();
        }

        public IWheels CreateWheels()
        {
            return new AUDI_Wheels();
        }
    }

    public class AUDI_Wheels : IWheels
    {
        public int WheelsCount => 4;
        public double DiskDiameter => 60;
        public double Width => 6;
        public WheelsType Type => WheelsType.Winter;
    }

    public class AUDI_Engine : IEngine
    {
        public int Capacity => 90;
        public EngineType Type => EngineType.Electric;
    }

    public class AUDI_Salon : ISalon
    {
        public int SeatsNumber => 4;
        public Color Color => Color.Black;
        public SalonMaterial Material => SalonMaterial.Leather;
    }

    public class AUDI_Body : IBody
    {
        public Color Color => Color.Blue;
        public BodyMaterial Material => BodyMaterial.Aluminum;
    }

    #endregion
}
