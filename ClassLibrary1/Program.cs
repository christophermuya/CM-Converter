using System.Windows;
using Compute;

namespace Controller {
    public class Program {

        public static string InfoDisplay(int index) {
            switch(index) {
                case 0:
                    return "CM-Converter is a tool that convert from any base " +
                        "to any other base.\n \n A number system is a way to represent " +
                        "numbers. We are used to using the \n" + "\u2022" + " Base-10 (decimal) " +
                        ". \n \nOther common number systems " +
                        "include: \n"+"\u2022"+ " Base-16 (hexadecimal) \n" + "\u2022" + 
                        " Base-8 (octal) \n" + "\u2022" + " Base-2 (binary).";
                case 1:
                    return "The decimal numeral system is the standard system for denoting integer and non-integer numbers. " +
                        "It is the extension to non-integer numbers of the Hindu–Arabic numeral system." +
                        " 0,1,2,3,4,5,6,7,8,9";
                case 2:
                    return "In mathematics and digital electronics, " +
                        "a binary number is a number expressed in the base-2 numeral system " +
                        "or binary numeral system, " +
                        "which uses only two symbols: \nTypically 0 (zero) and 1 (one). " +
                        "\n\nThe base-2 numeral system is a positional notation with a radix of 2. " +
                        "Each digit is referred to as a bit.";
                case 3:
                    return "In mathematics and computing, hexadecimal (also base 16, or hex) is " +
                        "a positional numeral system with a radix, or base, of 16.\n\n It uses sixteen distinct symbols," +
                        " most often the symbols 0–9 to represent values zero to nine, " +
                        "and \nA, B, C, D, E, F \n(or alternatively a, b, c, d, e, f) to represent values ten to fifteen.";
                case 4:
                    return "The octal numeral system, or oct for short, is the base-8 number system, " +
                        "and uses the digits\n \n 0 to 7. " +
                        "Octal numerals can be made from binary numerals by grouping " +
                        "consecutive binary digits into groups of three (starting from the right).";
            }
            return "";
        }

        public static string Convert(int from, int to, string data) {
            //checking
            if(from == 0 || to == 0) {
                MessageBox.Show("You need to select a number system","No number system selected");
                return "";
            }
            else if(from ==  to) {
                MessageBox.Show("The result will be the same buddy! Change the selected number system to convert to","Invalid input");
                return "";
            }
            else if(string.IsNullOrEmpty(data)) {
                MessageBox.Show("You need to enter an number","Missing number to convert");
                return "";
            }
            else {
                data = data.Replace(" ","");
            }

            switch(from) {
                case 1: from = 10;
                    break;
                case 2: from = 2;
                    break;
                case 3: from = 16;
                    break;
                case 4: from =  8;
                    break;
                default: return "select a number system to convert from";
            }

            switch(to) {
                case 1:
                    to = 10;
                    break;
                case 2:
                    to = 2;
                    break;
                case 3:
                    to = 16;
                    break;
                case 4:
                    to = 8;
                    break;
                default:
                    return "select a number system to convert to";
            }

            return Calculate.ConvertThis(from, to, data);           
        }

    }
}
