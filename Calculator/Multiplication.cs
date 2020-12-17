using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Multiplication : IObserver
    {
        public void Update(ref string subject)
        {
            string pattern = @"\-?\d+[\,\.]?\d*\*\d+[\,\.]?\d*";
            Regex regex = new Regex(pattern);
            while (regex.IsMatch(subject))
            {
                string matchStr = "";
                string[] stringsNumbToMult;
                MatchCollection matchesMult = regex.Matches(subject);
                foreach (var mult in matchesMult)
                {
                        matchStr = mult.ToString();
                        stringsNumbToMult = regex.Match(subject).ToString().Split('*');
                        double toRerurn = Convert.ToDouble((stringsNumbToMult[0].Replace('.', ','))) * Convert.ToDouble((stringsNumbToMult[1].Replace('.', ',')));
                        subject = subject.Replace(matchStr, toRerurn.ToString());
                }
            }
        }
    }
}
