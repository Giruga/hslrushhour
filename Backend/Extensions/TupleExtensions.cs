using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSLRushHour.Backend;
public static class TupleExtensions
{
    public static void Deconstruct<T>(this IList<T> list, out T first, out IList<T> rest) {
        first = list.Count > 0 ? list[0] : default(T)!;
        rest = list.Skip(1).ToList();
    }

    public static void Deconstruct<T>(this IList<T> list, out T first, out T second, out IList<T> rest) {
        first = list.Count > 0 ? list[0] : default(T)!;
        second = list.Count > 1 ? list[1] : default(T)!;
        rest = list.Skip(2).ToList();
    }
}