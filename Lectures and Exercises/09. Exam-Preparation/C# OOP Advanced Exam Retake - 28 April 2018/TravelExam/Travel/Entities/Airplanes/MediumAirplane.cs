namespace Travel.Entities.Airplanes
{
	public class MediumAirplane : Airplane
	{
        private const int MediumAirplaneSeats = 10;
        private const int MediumAirplaneBags = 14;

        public MediumAirplane()
			: base(MediumAirplaneSeats, MediumAirplaneBags)
		{
		}
	}
}