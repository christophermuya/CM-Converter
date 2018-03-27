using System;

namespace Compute {
    public class Calculate {
        public static string ConvertThis(int From, int To, string num) {
            try {
                string retVal = Convert.ToString(Convert.ToInt64(num,From),To);
                return retVal.ToUpper();
            }
            catch(System.OverflowException) {
                return "your input number is too long";
            }
            catch(Exception) {
                return "There is an error, check the format of your input";
            }        
        }        
    }
}
