using FastConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    public static class Conio
    {

        /// <summary>
        /// The default Cout::Ask Answer colour
        /// </summary>
        public static ColourPair askAnswer = new ColourPair() { First = ConsoleColor.DarkYellow };

        /// <summary>
        /// The default Cout::Question colour
        /// </summary>
        public static ColourPair askQuestion = new ColourPair() { First = ConsoleColor.Yellow };


        public static readonly ColourPair whiteColour = new ColourPair();

        public static string AskLine(string question, ColourPair? questionColour = null, ColourPair? answerColour = null)
        {
            questionColour = questionColour ?? askQuestion;
            answerColour = answerColour ?? askAnswer;

            FConsole.Write(question, questionColour);

            return FConsole.ReadLine(answerColour);
        }

        public static T AskLine<T>(string question, ColourPair? questionColour = null, ColourPair? answerColour = null)
        {
            T val;

            if (!questionColour.HasValue)
                questionColour = askQuestion;

            if (!answerColour.HasValue)
                answerColour = askAnswer;

            string ask = AskLine(question, questionColour, answerColour);
            while (true)
            {
                try
                {
                    val = (T)Convert.ChangeType(ask, typeof(T));
                    break;
                }
                catch (Exception)
                {

                    Console.WriteLine($"Invalid {typeof(T).Name}");
                }
            }

            return val;
        }

        public static string Ask(ColourPair? answerColour = null)
        {
            if (!answerColour.HasValue)
                answerColour = askAnswer;

            return FConsole.ReadLine(answerColour);
        }

        public static T Ask<T>(ColourPair? questionColour = null, ColourPair? answerColour = null)
        {
            answerColour = answerColour ?? askAnswer;

            string ask = Ask(answerColour);
            return (T)Convert.ChangeType(ask, typeof(T));
        }

        public static void Write(string question, ColourPair? colour = null)
        {
            FConsole.Write(question, colour);
        }


        public static string AskLineConfirm(string ask, bool twice, ColourPair? answerColour = null)
        {
            string answer = AskLine(ask, answerColour);
            while (true)
            {
                if (twice)
                {
                    string secondAnswer = AskLine("Write again to confirm:");

                    if (secondAnswer == answer)
                        return answer;
                }
                else
                {
                    AskLine("Are you sure? y/n:");
                    bool invalid = true;
                    while (invalid)
                    {
                        char ch = FConsole.ReadKey(false).KeyChar;
                        if (ch == 'y' || ch == 'Y')
                        {
                            FConsole.WriteLine(ch.ToString(), ColourStyles.yes);
                            return answer;
                        }
                        else if (ch == 'n' || ch == 'N')
                        {
                            invalid = false;
                            FConsole.WriteLine(ch.ToString(), ColourStyles.no);
                            FConsole.WriteLine("Retrying", ColourStyles.warning);
                        }
                    }
                }
            }
        }
    }
}
