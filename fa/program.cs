using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
  public class State
  {
    public string Name;
    public Dictionary<char, State> Transitions;
    public bool IsAcceptState;
  }


  public class FA1
  {
    public FA1()
    {
        a.Transitions['0'] = b;
        a.Transitions['1'] = e;
        b.Transitions['0'] = d;
        b.Transitions['1'] = c;
        c.Transitions['0'] = d;
        c.Transitions['1'] = c;
        d.Transitions['0'] = d;
        d.Transitions['1'] = d;   
        e.Transitions['0'] = c;
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

    State InitialState = a;
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
    public static State e = new State()
    {
        Name = "e",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
  }

  public class FA2
  {
    public FA2()
    {
        a.Transitions['0'] = c;
        a.Transitions['1'] = b;
        b.Transitions['0'] = d;
        b.Transitions['1'] = a;
        c.Transitions['0'] = a;
        c.Transitions['1'] = d;
        d.Transitions['0'] = b;
        d.Transitions['1'] = c;              
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

    State InitialState = a;
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
  }

  public class FA3
  {
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

    State InitialState = a;
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
  }

  class Program
    {
        static void Main(string[] args)
        {
            String s = "0101";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);
        }
    }
}
