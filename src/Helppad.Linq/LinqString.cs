using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Helppad.Linq
{
    /// <summary>
    /// The set of the method to extend the <see cref="IEnumerable{String}"/> linq api.
    /// </summary>
    public static class LinqString
    {
        /// <summary>
        /// Determines whether the beginning of element string in this enumerable instance 
        /// matches the specified string.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="term">The target text term, this argument define the basic condition or role to evaluate.</param>
        /// <returns></returns>
        public static IEnumerable<string> StartsWith(this IEnumerable<string> enumerable, string term)
        {
            return enumerable.Where(s => s.StartsWith(term));
        }

        /// <summary>
        /// Determines whether the beginning of element string in this enumerable instance 
        /// matches the specified string.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="term">The target text term, this argument define the basic condition or role to evaluate.</param>
        /// <param name="comparison"></param>
        /// <returns></returns>
        public static IEnumerable<string> StartsWith(this IEnumerable<string> enumerable, string term, StringComparison comparison)
        {
            return enumerable.Where(s => s.StartsWith(term, comparison));
        }

        /// <summary>
        /// Determines whether the beginning of element string in this enumerable instance 
        /// matches the specified string.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="term">The target text term, this argument define the basic condition or role to evaluate.</param>
        /// <param name="ignoreCase"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static IEnumerable<string> StartsWith(this IEnumerable<string> enumerable, string term, bool ignoreCase, CultureInfo culture)
        {
            return enumerable.Where(s => s.StartsWith(term, ignoreCase, culture));
        }

        /// <summary>
        /// Return true when the beginning of all string elements in this enumerable instance 
        /// matches the specified string.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="term">The target text term, this argument define the basic condition or role to evaluate.</param>
        /// <returns></returns>
        public static bool AllStartsWith(this IEnumerable<string> enumerable, string term)
        {
            return enumerable.All(s => s.StartsWith(term));
        }

        /// <summary>
        /// Return true when the beginning of all string elements in this enumerable instance 
        /// matches the specified string.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="term">The target text term, this argument define the basic condition or role to evaluate.</param>
        /// <param name="comparison"></param>
        /// <returns></returns>
        public static bool AllStartsWith(this IEnumerable<string> enumerable, string term, StringComparison comparison)
        {
            return enumerable.All(s => s.StartsWith(term, comparison));
        }

        /// <summary>
        /// Return true when the beginning of all string elements in this enumerable instance 
        /// matches the specified string.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="term">The target text term, this argument define the basic condition or role to evaluate.</param>
        /// <param name="ignoreCase"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static bool AllStartsWith(this IEnumerable<string> enumerable, string term, bool ignoreCase, CultureInfo culture)
        {
            return enumerable.All(s => s.StartsWith(term, ignoreCase, culture));
        }

        /// <summary>
        /// Apply Where operand in all string element indicating 
        /// whether a specified substring occurs.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="term">The target text term, this argument define the basic condition or role to evaluate.</param>
        /// <returns></returns>
        public static IEnumerable<string> Contains(this IEnumerable<string> enumerable, string term)
        {
            return enumerable.Where(s => s.Contains(term));
        }

        /// <summary>
        ///  Returns a true or false if a specified substring occurs within any string elements.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="term">The target text term, this argument define the basic condition or role to evaluate.</param>
        /// <returns></returns>
        public static bool AnyContains(this IEnumerable<string> enumerable, string term)
        {
            return enumerable.Where(s => s.Contains(term)).Any();
        }

        /// <summary>
        /// Returns a true or false if a specified substring occurs within all string elements.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="term">The target text term, this argument define the basic condition or role to evaluate.</param>
        /// <returns></returns>
        public static bool AllContains(this IEnumerable<string> enumerable, string term)
        {
            return enumerable.All(s => s.Contains(term));
        }

        /// <summary>
        /// Returns a true or false if a specified substring occurs within all string elements.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="term">The target text term, this argument define the basic condition or role to evaluate.</param>
        /// <returns></returns>
        public static IEnumerable<string> EndsWith(this IEnumerable<string> enumerable, string term)
        {
            return enumerable.Where(s => s.EndsWith(term));
        }

        /// <summary>
        /// Return true when the end of all string elements in this enumerable instance 
        /// matches the specified string.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="term">The target text term, this argument define the basic condition or role to evaluate.</param>
        /// <param name="comparison"></param>
        /// <returns></returns>
        public static IEnumerable<string> EndsWith(this IEnumerable<string> enumerable, string term, StringComparison comparison)
        {
            return enumerable.Where(s => s.EndsWith(term, comparison));
        }

        /// <summary>
        /// Return true when the end of all string elements in this enumerable instance 
        /// matches the specified string.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="term">The target text term, this argument define the basic condition or role to evaluate.</param>
        /// <param name="ignoreCase"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static IEnumerable<string> EndsWith(this IEnumerable<string> enumerable, string term, bool ignoreCase, CultureInfo culture)
        {
            return enumerable.Where(s => s.EndsWith(term, ignoreCase, culture));
        }

        /// <summary>
        /// Return true when the end of all string elements in this enumerable instance 
        /// matches the specified string.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="term">The target text term, this argument define the basic condition or role to evaluate.</param>
        /// <returns></returns>
        public static bool AllEndsWith(this IEnumerable<string> enumerable, string term)
        {
            return enumerable.All(s => s.EndsWith(term));
        }

        /// <summary>
        /// Return true if the all string element ends with the term.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="term">The target text term, this argument define the basic condition or role to evaluate.</param>
        /// <param name="comparison"></param>
        /// <returns></returns>
        public static bool AllEndsWith(this IEnumerable<string> enumerable, string term, StringComparison comparison)
        {
            return enumerable.All(s => s.EndsWith(term, comparison));
        }

        /// <summary>
        ///  Return true if the all string element ends with the term.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="term">The target text term, this argument define the basic condition or role to evaluate.</param>
        /// <param name="ignoreCase"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static bool AllEndsWith(this IEnumerable<string> enumerable, string term, bool ignoreCase, CultureInfo culture)
        {
            return enumerable.All(s => s.EndsWith(term, ignoreCase, culture));
        }

        /// <summary>
        ///  Return true if the all string element ends with the term.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="set"></param>
        /// <returns></returns>
        public static IEnumerable<string> WithoutChars(this IEnumerable<string> enumerable, char[] set)
        {
            return enumerable.Where(s => s.Where(c => set.Contains(c)).Any() is false);
        }

        /// <summary>
        /// Apply a filter base on regular expression.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="term">The target text term, this argument define the basic condition or role to evaluate.</param>
        /// <returns></returns>
        public static IEnumerable<string> MatchWith(this IEnumerable<string> enumerable, string term)
        {
            return enumerable.Where(s => Regex.IsMatch(s, term));
        }

        /// <summary>
        /// Apply a filter base on regular expression.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static IEnumerable<string> MatchWith(this IEnumerable<string> enumerable, Regex expression)
        {
            return enumerable.Where(s => expression.IsMatch(s));
        }

        /// <summary>
        /// Apply a split operation base on char separation.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static IEnumerable<string> SplitWith(this IEnumerable<string> enumerable, params char[] token)
        {
            return enumerable.Select(s => s.Split(token)).SelectMany(x => x);
        }

        /// <summary>
        /// Apply a split operation base on char separation.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="token"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IEnumerable<string> SplitWith(this IEnumerable<string> enumerable, char[] token, int count)
        {
            return enumerable.Select(s => s.Split(token, count)).SelectMany(x => x);
        }

        /// <summary>
        /// Apply a split operation base on char separation.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="token"></param>
        /// <param name="count"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IEnumerable<string> SplitWith(this IEnumerable<string> enumerable, char[] token, int count, StringSplitOptions options)
        {
            return enumerable.Select(s => s.Split(token, count, options)).SelectMany(x => x);
        }

        /// <summary>
        /// Apply a split operation base on char separation.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="token"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IEnumerable<string> SplitWith(this IEnumerable<string> enumerable, char[] token, StringSplitOptions options)
        {
            return enumerable.Select(s => s.Split(token, options)).SelectMany(x => x);
        }

        /// <summary>
        /// Apply a split operation base on regular expression.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static IEnumerable<string> SplitWith(this IEnumerable<string> enumerable, Regex expression)
        {
            return enumerable.Select(s => expression.Split(s)).SelectMany(x => x);
        }

        /// <summary>
        /// Apply a split operation base on regular expression.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="expression"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IEnumerable<string> SplitWith(this IEnumerable<string> enumerable, Regex expression, int count)
        {
            return enumerable.Select(s => expression.Split(s, count)).SelectMany(x => x);
        }

        /// <summary>
        /// Convert all string element in lower case.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <returns></returns>
        public static IEnumerable<string> LowerAll(this IEnumerable<string> enumerable)
        {
            return enumerable.Select(s => s.ToLower());
        }

        /// <summary>
        ///  Convert all string element in upper case.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <returns></returns>
        public static IEnumerable<string> UpperAll(this IEnumerable<string> enumerable)
        {
            return enumerable.Select(s => s.ToUpper());
        }

        /// <summary>
        /// Make a string instance from <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <returns></returns>
        public static string MakeString(this IEnumerable<char> enumerable)
        {
            return new string(enumerable.ToArray());
        }

        /// <summary>
        /// Make a string instance from an enumerable string.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <param name="term">The target text term, this argument define the basic condition or role to evaluate.</param>
        /// <returns></returns>
        public static string Join(this IEnumerable<string> enumerable, string term)
        {
            return string.Join(term, enumerable);
        }

        /// <summary>
        /// Make a string instance from an enumerable string by space.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <returns></returns>
        public static string JoinBySpace(this IEnumerable<string> enumerable)
        {
            return string.Join(" ", enumerable);
        }

        /// <summary>
        /// Make a string instance from an enumerable string by break line.
        /// </summary>
        /// <param name="enumerable">The target enumerable that contain string instances.</param>
        /// <returns></returns>
        public static string JoinByLine(this IEnumerable<string> enumerable)
        {
            return string.Join(Environment.NewLine, enumerable);
        }
    }
}
