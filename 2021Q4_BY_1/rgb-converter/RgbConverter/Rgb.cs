using System;

namespace RgbConverter
{
    public static class Rgb
    {
        /// <summary>
        /// Gets hexadecimal representation source RGB decimal values.
        /// </summary>
        /// <param name="red">The valid decimal value for red colour for RGB is in the range 0-255.</param>
        /// <param name="green">The valid decimal value for green colour for RGB is in the range 0-255.</param>
        /// <param name="blue"> The valid decimal value for blue colour for RGB is in the range 0-255.</param>
        /// <returns>Returns hexadecimal representation source RGB decimal values.</returns>
        public static string GetHexRepresentation(int red, int green, int blue)
        {
            // Setting colour value in range 0..255.
            static void ColourValueRange(ref int colour)
            {
                if (colour > 255)
                {
                    colour = 255;
                }
                else if (colour < 0)
                {
                    colour = 0;
                }
            }

            // Converting int value to string type of hexadecimal number.
            static string IntToHexConverter(int value)
            {
                // Hexadecimal value of range 0..255 presents by two sign hexadecimal number.
                char[] hexValueArray = new char[2];
                int charArrayCounter = 0;
                while (value != 0)
                {
                    int temp = 0;

                    // Calculating a remainder after division value by 16 which significant for hexadecimal number.
                    temp = value % 16;
                    
                    // Calculating significant for hexadecimal number remainder after division value by 16.
                    if (temp < 10)
                    {
                        // Explicit casting of int value to char type.
                        hexValueArray[charArrayCounter] = (char)(temp + 48);
                        charArrayCounter++;
                    }
                    else
                    {
                        // Explicit casting of int value to char type.
                        hexValueArray[charArrayCounter] = (char)(temp + 55);
                        charArrayCounter++;
                    }

                    value /= 16;
                }

                string hexString = string.Empty;

                // Reversing elements of hexValueArray in case two signs number.
                if (charArrayCounter == 2)
                {
                    hexString += hexValueArray[1];
                    hexString += hexValueArray[0];
                }

                // One sing number handling.
                else if (charArrayCounter == 1)
                {
                    hexString += "0";
                    hexString += hexValueArray[0];
                }
                else if (charArrayCounter == 0)
                {
                    hexString = "00";
                }

                return hexString;
            }

            ColourValueRange(ref red);
            ColourValueRange(ref green);
            ColourValueRange(ref blue);

            string result = IntToHexConverter(red) + IntToHexConverter(green) + IntToHexConverter(blue);
            return result;
        }
    }
}
