using System;

namespace WindData
{
    public class Calculate
    {
        /* Helper function that converts degrees to radians to be used with Math.Cos and Math.Sin
         * 
         */
        public static double ConvertDegreeToRadian(double degrees)
        {
            return (Math.PI / 180) * degrees;
        }

        /* Calculates Longitudinal Wind Velocity Component
         * 
         * Params:
         * Vw: Wind Velocity
         * wind_angle: Angle of wind against vessel
         */
        public static double LongitudinalWindVelocity(double Vw, double wind_angle)
        {
            var radians = ConvertDegreeToRadian(wind_angle);
            return Vw * Math.Cos(radians);
        }

        /* Calculates Transverse Wind Velocity Component
         * 
         * Params:
         * Vw: Wind Velocity
         * wind_angle: Angle of wind against vessel
         */
        public static double TransverseWindVelocity(double Vw, double wind_angle)
        {
            var radians = ConvertDegreeToRadian(wind_angle);
            return Vw * Math.Sin(radians);
        }

        /* Calculates Longitudinal Wind Moment Component
         * 
         * Params:
         * AwL: Windage Area Longitue
         * VwL: Longitudinal Wind Velocity
         * zL: Centre of Longitudinal Windage Area
         */
        public static double LongitudinalWindMoment(double AwL, double VwL, double zL)
        {
            return AwL * zL * VwL;
        }

        /* Calculates Longitudinal Wind Moment Component
        * 
        * Params:
        * AwL: Windage Area Longitue
        * VwL: Longitudinal Wind Velocity
        * zL: Centre of Longitudinal Windage Area
        */
        public static double TransverseWindMoment(double AwT, double VwT, double zT)
        {
            return AwT * zT * VwT;
        }
    }
}
