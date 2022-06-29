namespace Calculator.StaticData
{
    public static partial class Operators
    {
        public class Operator
        {
            public readonly char Name;
            public readonly int Priority;

            public Operator(char name = default, int priority = 0)
            {
                Name = name;
                Priority = priority;
            }

            public static bool operator ==(Operator operator1, Operator operator2)
            {
                return operator1.Name == operator2.Name;
            }

            public static bool operator !=(Operator operator1, Operator operator2)
            {
                return operator1.Name != operator2.Name;
            }

            public static bool operator ==(char operator1, Operator operator2)
            {
                return operator1 == operator2.Name;
            }

            public static bool operator !=(char operator1, Operator operator2)
            {
                return operator1 != operator2.Name;
            }

            public override bool Equals(object obj)
            {
                return obj is Operator operator1 &&
                       Name == operator1.Name &&
                       Priority == operator1.Priority;
            }

            public override int GetHashCode()
            {
                int hashCode = 112134431;
                hashCode = hashCode * -1521134295 + Name.GetHashCode();
                hashCode = hashCode * -1521134295 + Priority.GetHashCode();
                return hashCode;
            }
        }
    }
}
