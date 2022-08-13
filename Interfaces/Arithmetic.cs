using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Arithmetic
    {
        public static T Add<T>(T a, T b)
        {
            switch (typeof(T).Name)
            {
                case "Int32":
                    return (T)(object)((int)(object)a + (int)(object)b);
                case "UInt32":
                    return (T)(object)((uint)(object)a + (uint)(object)b);
                case "Int64":
                    return (T)(object)((long)(object)a + (long)(object)b);
                case "UInt64":
                    return (T)(object)((ulong)(object)a + (ulong)(object)b);
                case "Double":
                    return (T)(object)((double)(object)a + (double)(object)b);
                case "BigInteger":
                    return (T)(object)((BigInteger)(object)a + (BigInteger)(object)b);
                default:
                    return default(T);
            }
        }

        public static T Mul<T>(T a, T b)
        {
            switch (typeof(T).Name)
            {
                case "Int32":
                    return (T)(object)((int)(object)a * (int)(object)b);
                case "UInt32":
                    return (T)(object)((uint)(object)a * (uint)(object)b);
                case "Int64":
                    return (T)(object)((long)(object)a * (long)(object)b);
                case "UInt64":
                    return (T)(object)((ulong)(object)a * (ulong)(object)b);
                case "Double":
                    return (T)(object)((double)(object)a * (double)(object)b);
                case "BigInteger":
                    return (T)(object)((BigInteger)(object)a * (BigInteger)(object)b);
                default:
                    return default(T);
            }
        }
    }
}
