using System;
using System.Collections.Generic;

namespace FiniteAutomata
{
    public class State
    {
        public string Name { get; set; }
        public Dictionary<char, State> Transitions { get; set; }
        public bool IsAcceptState { get; set; }
    }

    public class FiniteAutomaton
    {
        public State InitialState { get; set; }

        public FiniteAutomaton(State initialState)
        {
            InitialState = initialState;
        }

        public bool? Run(IEnumerable<char> input)
        {
            State current = InitialState;
            foreach (var symbol in input)
            {
                if (!current.Transitions.ContainsKey(symbol))
                    return null;

                current = current.Transitions[symbol];
            }
            return current.IsAcceptState;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = "0101";

            State fa1_a = new State() { Name = "a", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            State fa1_b = new State() { Name = "b", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            State fa1_c = new State() { Name = "c", IsAcceptState = true,  Transitions = new Dictionary<char, State>() };
            State fa1_d = new State() { Name = "d", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            State fa1_e = new State() { Name = "e", IsAcceptState = false, Transitions = new Dictionary<char, State>() };

            fa1_a.Transitions['0'] = fa1_b;
            fa1_a.Transitions['1'] = fa1_e;
            fa1_b.Transitions['0'] = fa1_d;
            fa1_b.Transitions['1'] = fa1_c;
            fa1_c.Transitions['0'] = fa1_d;
            fa1_c.Transitions['1'] = fa1_c;
            fa1_d.Transitions['0'] = fa1_d;
            fa1_d.Transitions['1'] = fa1_d;
            fa1_e.Transitions['0'] = fa1_c;
            fa1_e.Transitions['1'] = fa1_e;

            FiniteAutomaton fa1 = new FiniteAutomaton(fa1_a);
            bool? result1 = fa1.Run(input);
            Console.WriteLine("Result for FA1: " + result1);

            State fa2_a = new State() { Name = "a", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            State fa2_b = new State() { Name = "b", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            State fa2_c = new State() { Name = "c", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            State fa2_d = new State() { Name = "d", IsAcceptState = true,  Transitions = new Dictionary<char, State>() };

            fa2_a.Transitions['0'] = fa2_c;
            fa2_a.Transitions['1'] = fa2_b;
            fa2_b.Transitions['0'] = fa2_d;
            fa2_b.Transitions['1'] = fa2_a;
            fa2_c.Transitions['0'] = fa2_a;
            fa2_c.Transitions['1'] = fa2_d;
            fa2_d.Transitions['0'] = fa2_b;
            fa2_d.Transitions['1'] = fa2_c;

            FiniteAutomaton fa2 = new FiniteAutomaton(fa2_a);
            bool? result2 = fa2.Run(input);
            Console.WriteLine("Result for FA2: " + result2);

            State fa3_a = new State() { Name = "a", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            State fa3_b = new State() { Name = "b", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            State fa3_c = new State() { Name = "c", IsAcceptState = true,  Transitions = new Dictionary<char, State>() };

            fa3_a.Transitions['0'] = fa3_a;
            fa3_a.Transitions['1'] = fa3_b;
            fa3_b.Transitions['0'] = fa3_a;
            fa3_b.Transitions['1'] = fa3_c;
            fa3_c.Transitions['0'] = fa3_c;
            fa3_c.Transitions['1'] = fa3_c;

            FiniteAutomaton fa3 = new FiniteAutomaton(fa3_a);
            bool? result3 = fa3.Run(input);
            Console.WriteLine("Result for FA3: " + result3);
        }
    }
}
