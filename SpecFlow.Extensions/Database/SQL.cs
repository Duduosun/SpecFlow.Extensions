using System;

namespace SpecFlow.Extensions.Database
{
    public class SQL
    {
        private SqlLogic? _logical;
        private SqlCompare _compare;
        private string _name;
        private object _value;

        public SQL(SqlCompare compare, string name, object value)
        {
            _logical = null;
            _compare = compare;
            _name = name;
            _value = value;
        }

        public SQL(SqlLogic logical, SqlCompare compare, string name, object value)
        {
            _logical = logical;
            _compare = compare;
            _name = name;
            _value = value;
        }

        public static SQL Criterion(string name, object value, SqlCompare compare = SqlCompare.Equals)
        {
            return new SQL(compare, name, value);
        }

        public static SQL And(string name, object value, SqlCompare compare = SqlCompare.Equals)
        {
            return new SQL(SqlLogic.AND, compare, name, value);
        }

        public static SQL Or(string name, object value, SqlCompare compare = SqlCompare.Equals)
        {
            return new SQL(SqlLogic.OR, compare, name, value);
        }

        public override string ToString()
        {
            return string.Format("{0}{1} {2} {3}", Logical, _name, Compare, (_value is string) ? string.Format("'{0}'", _value) : _value.ToString());
        }

        public string ToStringNotEscaped()
        {
            return string.Format("{0}{1} {2} {3}", Logical, _name, Compare, _value.ToString());
        }

        private string Logical
        {
            get
            {
                switch (_logical)
                {
                    case SqlLogic.AND:
                        return " AND ";

                    case SqlLogic.OR:
                        return " OR ";

                    default:
                        return string.Empty;
                }
            }
        }

        private string Compare
        {
            get
            {
                switch (_compare)
                {
                    case SqlCompare.Equals:
                        return "=";

                    case SqlCompare.Greater:
                        return ">";

                    case SqlCompare.Less:
                        return "<";

                    case SqlCompare.GreaterOrEqual:
                        return ">=";

                    case SqlCompare.LessOrEqual:
                        return "<=";

                    case SqlCompare.NotEqual:
                        return "<>";

                    default:
                        throw new NotSupportedException();
                }
            }
        }
    }

    public enum SqlLogic
    {
        AND, OR
    }

    public enum SqlCompare
    {
        Equals, Greater, Less, GreaterOrEqual, LessOrEqual, NotEqual
    }
}