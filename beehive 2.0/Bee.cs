namespace beehive_2._0
{
    class Bee
    {
        private const double HoneyUnitsConsumedPerMg = 0.25;
        public double WeightMg { get; private set; }

        public Bee(double weightMg)
        {
            WeightMg = weightMg;
        }

        public virtual double HoneyConsumptionRate()
        {
            return WeightMg * HoneyUnitsConsumedPerMg;
        }
    }
}
