using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Subtraction : IObserver
    {
        public void Update(ref string subject)
        {
            string pattern = @"\-?\d+[\,\.]?\d*\-\d+[\,\.]?\d*";
            Regex regex = new Regex(pattern);
            while(regex.IsMatch(subject))
            {
                string matchStr = "";
                string[] stringsNumbToSub;
                MatchCollection matchesSub = regex.Matches(subject);
                foreach (var sub in matchesSub)
                {
                        matchStr = sub.ToString();
                        stringsNumbToSub = regex.Match(subject).ToString().Split('-');
                        double toRerurn = Convert.ToDouble((stringsNumbToSub[0].Replace('.', ','))) - Convert.ToDouble((stringsNumbToSub[1].Replace('.', ',')));
                        subject = subject.Replace(matchStr, toRerurn.ToString());
                }
            }
        }
    }
}
