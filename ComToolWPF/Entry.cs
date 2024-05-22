using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComToolWPF
{
    public enum EPriority
    {
        URGENT,
        TRANQUILLE,
        BLC
    }

    public enum EPole
    {
        CCC,
        IA,
        UI,
        GD
    }

    public class Entry
    {
        public EPriority Priority { get; set; }
        public EPole Pole { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Index { get; private set; }

        public Entry(int _index, EPriority _priority, EPole _pole, string _question, string _answer = "")
        {
            Index = _index;
            Priority = _priority;
            Pole = _pole;
            Question = _question;
            Answer = _answer;
        }
    }
}
