using System;
using System.Globalization;
using System.Text;

#pragma warning disable S2368

namespace MorseCodeTranslator
{
    public static class Translator
    {
        public static string TranslateToMorse(string message)
        {
            // #1. Implement the method using StringBuilder, and MorseCodes.CodeTable array.
            StringBuilder result = new StringBuilder();
            WriteMorse(MorseCodes.CodeTable, message, result, '.', '-', ' ');
            return result.ToString();
        }

        public static string TranslateToText(string morseMessage)
        {
            // #2. Implement the method using StringBuilder, and MorseCodes.CodeTable array.
            StringBuilder result = new StringBuilder();
            WriteText(MorseCodes.CodeTable, morseMessage, result, '.', '-', ' ');
            return result.ToString();
        }

        public static void WriteMorse(char[][] codeTable, string message, StringBuilder morseMessageBuilder, char dot = '.', char dash = '-', char separator = ' ')
        {
            // #3. Implement the method.
            if (codeTable == null)
            {
                throw new ArgumentNullException(nameof(codeTable), "codeTable cannot be null.");
            }
            else if (morseMessageBuilder == null)
            {
                throw new ArgumentNullException(nameof(morseMessageBuilder), "morseMessageBuilder cannot cannot be null.");
            }
            else if (message == null)
            {
                throw new ArgumentNullException(nameof(message), "Message cannot be null.");
            }

            // Matching every sing in the message
            for (int msgIndex = 0; msgIndex < message.Length; msgIndex++)
            {
                // with every row in the codeTable.
                for (int codeTableIndex = 0; codeTableIndex < codeTable.Length; codeTableIndex++)
                {
                    // When signs are equal appending signs of morse code to the Stringbuilder instance.
                    if (MorseCodes.CodeTable[codeTableIndex][0] == char.ToUpper(message[msgIndex], CultureInfo.InvariantCulture))
                    {
                        morseMessageBuilder.Append(MorseCodes.CodeTable[codeTableIndex][1..]);
                        morseMessageBuilder.Append(" ");
                    }
                }
            }

            // Changing default signs of morse code to the method defined ones.
            if (morseMessageBuilder.Length > 0)
            {
                morseMessageBuilder.Remove(morseMessageBuilder.Length - 1, 1);
                if (dot != '.')
                {
                    morseMessageBuilder.Replace('.', dot);
                }

                if (dash != '-')
                {
                    morseMessageBuilder.Replace('-', dash);
                }

                if (separator != ' ')
                {
                    morseMessageBuilder.Replace(' ', separator);
                }
            }
        }

        public static void WriteText(char[][] codeTable, string morseMessage, StringBuilder messageBuilder, char dot = '.', char dash = '-', char separator = ' ')
        {
            // #4. Implement the method.
            if (codeTable == null)
            {
                throw new ArgumentNullException(nameof(codeTable), "codeTable cannot be null.");
            }
            else if (messageBuilder == null)
            {
                throw new ArgumentNullException(nameof(messageBuilder), "messageBuilder cannot be null.");
            }
            else if (morseMessage == null)
            {
                throw new ArgumentNullException(nameof(morseMessage), "morseMessage cannot be null.");
            }

            // Changing default signs of morse code to the method defined ones.
            StringBuilder morseMessageTranslator = new StringBuilder(morseMessage);
            if (separator != ' ')
            {
                morseMessageTranslator.Replace(separator, ' ');
            }

            if (dot != '.')
            {
                morseMessageTranslator.Replace(dot, '.');
            }

            if (dash != '-')
            {
                morseMessageTranslator.Replace(dash, '-');
            }

            morseMessage = morseMessageTranslator.ToString();

            // Splitting the message to strings which represent letters.
            string[] morseMessageLetters = morseMessage.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Matching rows in the morseMessageLetters array
            for (int msgIndex = 0; msgIndex < morseMessageLetters.Length; msgIndex++)
            {
                // with rows in the MorseCodes.CodeTable.
                for (int codeTableIndex = 0; codeTableIndex < MorseCodes.CodeTable.Length; codeTableIndex++)
                {
                    // Matching the first sign in the morseMessageLetters row with the second sing in the MorseCodes.CodeTable.
                    if (morseMessageLetters[msgIndex][0] == MorseCodes.CodeTable[codeTableIndex][1] &&
                        morseMessageLetters[msgIndex].Length == MorseCodes.CodeTable[codeTableIndex].Length - 1)
                    {
                        // If the signs match and length of the morseMessageLetter is one sign append the letter to
                        // result Stringbuilding instance.
                        if (morseMessageLetters[msgIndex].Length == 1)
                        {
                            messageBuilder.Append(MorseCodes.CodeTable[codeTableIndex][0]);
                        }

                        // Matching the other sings in the row.
                        for (int signInRowIndex = 2; signInRowIndex < MorseCodes.CodeTable[codeTableIndex].Length; signInRowIndex++)
                        {
                            // If signs does not match breack the loop.
                            if (morseMessageLetters[msgIndex][signInRowIndex - 1] != MorseCodes.CodeTable[codeTableIndex][signInRowIndex])
                            {
                                break;
                            }

                            // If all signs matching appending the letter.
                            else if (signInRowIndex == MorseCodes.CodeTable[codeTableIndex].Length - 1)
                            {
                                messageBuilder.Append(MorseCodes.CodeTable[codeTableIndex][0]);
                            }
                        }
                    }
                }
            }
        }
    }
}
