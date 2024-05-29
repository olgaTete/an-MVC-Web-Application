namespace MyFirstWebApp.Models
{
    public class TempUtility
    {
        public static string Temperature(float temperature, string scale)
        {
            if (scale == "Fahrenheit")
            {
                // Convert Fahrenheit to Celsius
                temperature = (temperature - 32) * 5 / 9;
            }

            if (temperature >= 38.0)
            {
                return "You have a fever.";
            }
            else if (temperature < 35.0)
            {
                return "You have hypothermia.";
            }
            else
            {
                return "Your temperature is normal.";
            }
        }
    }
}
