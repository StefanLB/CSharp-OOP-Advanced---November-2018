﻿namespace Travel.Entities.Airplanes
{
	public class LightAirplane : Airplane
	{
        private const int LightAirplaneSeats = 5;
        private const int LightAirplaneBags = 8;

		public LightAirplane()
			: base(LightAirplaneSeats, LightAirplaneBags)
		{
		}
	}
}