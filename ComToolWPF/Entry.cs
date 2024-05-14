using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComToolWPF
{
    internal class Entry
    {
        public string Priority { get; set; }
        public string Pole { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public Entry(string _priority, string _pole, string _question, string _answer = "")
        {
            Priority = _priority;
            Pole = _pole;
            Question = _question;
            Answer = _answer;
        }
    }
}
