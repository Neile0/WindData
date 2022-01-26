using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindData
{
    public class Calculate
    {

        /* Calculates Longitudinal Wind Velocity Component
         * 
         * Params:
         * Vw: Wind Velocity
         * wind_angle: Angle of wind against vessel
         */
        public static double LongitudinalWindVelocity(double Vw, double wind_angle)
        {
            return Vw * Math.Cos(wind_angle);
        }

        /* Calculates Transverse Wind Velocity Component
         * 
         * Params:
         * Vw: Wind Velocity
         * wind_angle: Angle of wind against vessel
         */
        public static double TransverseWindVelocity(double Vw, double wind_angle)
        {
            return Vw * Math.Sin(wind_angle);
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
