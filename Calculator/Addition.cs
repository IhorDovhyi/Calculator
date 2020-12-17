using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Addition : IObserver
    {
        public void Update(ref string subject)
        {
            string pattern = @"\-?\d+[\,\.]?\d*\+\d+[\,\.]?\d*";
            Regex regex = new Regex(pattern);
            while (regex.IsMatch(subject))
            {
                string matchStr = "";
                string[] stringsNumbToAdd;
                MatchCollection matchesAdd = regex.Matches(subject);
                foreach (var sub in matchesAdd)
                {
                        matchStr = regex.Match(subject).ToString();
                        stringsNumbToAdd = regex.Match(subject).ToString().Split('+');
                        double toRerurn = Convert.ToDouble((stringsNumbToAdd[0].Replace('.', ','))) + Convert.ToDouble((stringsNumbToAdd[1].Replace('.', ',')));
                        subject = subject.Replace(matchStr, toRerurn.ToString());
                }
            }
        }
    }
}
