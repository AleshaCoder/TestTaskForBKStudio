using System.Collections.Generic;
using System.Linq;

namespace Calculator.StaticData
{
    public static partial class Operators
    {
        public static Operator LeftParenthesis = new Operator('(', 0);
        public static Operator RightParenthesis = new Operator(')', 1);
        public static Operator Plus = new Operator('+', 2);
        public static Operator Minus = new Operator('-', 3);
        public static Operator UMinus = new Operator('-', 6);
        public static Operator Multyply = new Operator('*', 4);
        public static Operator Division = new Operator('/', 4);
        public static Operator Power = new Operator('^', 5);
        public static Operator Space = new Operator(' ', 5);
        public static Operator Dot = new Operator(',', 5);

        private static List<Operator> _operators = new List<Operator>();

        public static IReadOnlyCollection<Operator> AllOperators => _operators;

        static Operators()
        {
            _operators = new List<Operator>()
            {
                LeftParenthesis,
                RightParenthesis,
                Plus,
                Minus,
                Multyply,
                Division,
                Power,
                Space,
                Dot
            };
        }

        public static bool HasOperatorWith(char c) => AllOperators.Count(oper => oper.Name == c) > 0;

        public static Operator GetOperatorWith(char c) => AllOperators.First(oper => oper.Name == c);

        public static bool TryGetOperatorWith(char c, out Operator oper)
        {
            bool has = HasOperatorWith(c);            
            oper = has ? GetOperatorWith(c) : null;
            return has;
        }
    }
}
