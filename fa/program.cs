using System;
using System.Collections.Generic;

namespace fans
{
    // Определяем класс состояния
    public class State
    {
        public string Name { get; set; }
        public bool IsAcceptState { get; set; }
        public Dictionary<char, State> Transitions { get; set; }
    }

    // Определяем класс конечного автомата FA1
    public class FA1
    {
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State c = new State()
        {
            Name = "c",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State d = new State()
        {
            Name = "d",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public static State e = new State()
        {
            Name = "e",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        static State InitialState = a;

        public FA1()
        {
            a.Transitions['0'] = c;
            a.Transitions['1'] = b;
            b.Transitions['0'] = d;
            b.Transitions['1'] = b;
            c.Transitions['0'] = e;
            c.Transitions['1'] = d;
            d.Transitions['0'] = e;
            d.Transitions['1'] = d;
            e.Transitions['0'] = e;
            e.Transitions['1'] = e;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    // Определяем класс конечного автомата FA2
    public class FA2
    {
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State c = new State()
        {
            Name = "c",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public static State d = new State()
        {
            Name = "d",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        static State InitialState = a;

        public FA2()
        {
            a.Transitions['0'] = b;
            a.Transitions['1'] = d;
            b.Transitions['0'] = a;
            b.Transitions['1'] = c;
            c.Transitions['0'] = d;
            c.Transitions['1'] = b;
            d.Transitions['0'] = c;
            d.Transitions['1'] = a;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    // Определяем класс конечного автомата FA3
    public class FA3
    {
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State c = new State()
        {
            Name = "c",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        static State InitialState = a;

        public FA3()
        {
            a.Transitions['0'] = a;
            a.Transitions['1'] = b;
            b.Transitions['0'] = a;
            b.Transitions['1'] = c;
            c.Transitions['0'] = c;
            c.Transitions['1'] = c;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String s = "011111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);

            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine(result2);

            FA3 fa3 = new FA3();
            bool? result3 = fa3.Run(s);
            Console.WriteLine(result3);
        }
    }
}
