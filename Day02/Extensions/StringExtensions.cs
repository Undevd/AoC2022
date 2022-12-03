using Day02;
using System;

namespace Day02.Extensions
{
    public static class StringExtensions
    {
        public static Shape ToShape(this string str) => str.ToUpper() switch
        {
            "A" => Shape.Rock,
            "X" => Shape.Rock,
            "B" => Shape.Paper,
            "Y" => Shape.Paper,
            "C" => Shape.Scissors,
            "Z" => Shape.Scissors,
            _ => throw new ArgumentOutOfRangeException(nameof(str), "Not expected")
        };
    }
}
