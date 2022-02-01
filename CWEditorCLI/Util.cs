using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    class Util
    {

         public static bool IsInsideCircle(int cX, int cY, int sX, int sY, float radius)
        {
            double dx = cX - sX,
                  dy = cY - sY;
            double distance_squared = dx * dx + dy * dy;
            return distance_squared < radius * radius;
        }

        public static bool IsOutOfBounds(int x, int y, int width, int height)
        {
            return (x >= width || y >= height || x < 0 || y < 0);
        }


        /// <summary>
        /// Min inclusive, Max Inclusive
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static double Clamp(double value, double min, double max)
        {
            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }

            return value;
        }

        /// <summary>
        /// Min inclusive, Max Inclusive
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int Clamp(int value, int min, int max)
        {
            if (value < min)
            {
                return min;
            }
            else if(value > max)
            {
                return max;
            }

            return value;
        }
    }
}
