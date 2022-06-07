using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Helppad
{

    /// <summary>
    /// This class contains string helper methods.
    /// </summary>
    public static class String
    {
        /// <summary>
        /// this parse words in camel case
        /// </summary>
        /// <param name="text">the camel case words to split</param>
        /// <returns>the splitted words</returns>
        public static string[] SplitCamelCase(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string[] { };
            }else{
                return __ParseCamelCase(text).ToArray();
            }

            // generator for the split
            static IEnumerable<string> __ParseCamelCase(string text){
                string currentWord = string.Empty;
                foreach (var c in text)
                {
                // if the current char is a letter with a capital letter
                    if (char.IsUpper(c))
                    {
                        yield return currentWord;
                    }else{
                        currentWord += c;
                    }
                }
            }
        }

        /// <summary>
        /// this method join array of words in camel case
        /// </summary>
        /// <param name="words">the words to join</param>
        /// <returns>the joined words</returns>
        public static string JoinCamelCase(string[] words)
        {
            return string.Join("", words.Select((x, i) => i > 0 ? char.ToUpper(x[0]) + x.Substring(1) : x));
        }

        /// <summary>
        /// This method parse a string dash case to camel case.
        /// </summary>
        /// <param name="text">The string to parse.</param>
        /// <returns>The parsed string.</returns>
        public static string ParseDashCaseToCamelCase(string text)
        {
            // split the string
            string[] words = text.Split('-');

            // join the words
            return JoinCamelCase(words);
        }

        /// <summary>
        /// This method parse a string camel case to dash case.
        /// </summary>
        /// <param name="text">The string to parse.</param>
        /// <returns>The parsed string.</returns>
        public static string ParseCamelCaseToDashCase(string text)
        {
            // split the string
            string[] words = SplitCamelCase(text);

            // join the words
            return string.Join("-", words);
        }

        /// <summary>
        /// This method parse a Pascal case string to camel case.
        /// </summary>
        /// <param name="text">The string to parse.</param>
        /// <returns>The parsed string.</returns>
        public static string ParsePascalCaseToCamelCase(string text)
        {
            // parse pasasl case to camel case
            return char.ToLower(text[0]) + text.Substring(1);
        }

        /// <summary>
        /// This method parse a camel case string to Pascal case.
        /// </summary>
        /// <param name="text">The string to parse.</param>
        /// <returns>The parsed string.</returns>
        public static string ParseCamelCaseToPascalCase(string text)
        {
            // parse camel case to Pascal case
            return char.ToUpper(text[0]) + text.Substring(1);
        }

        /// <summary>
        /// This method parse a underscore case string to camel case.
        /// </summary>
        /// <param name="text">The string to parse.</param>
        /// <returns>The parsed string.</returns>
        public static string ParseUnderscoreCaseToCamelCase(string text)
        {
            // split the string
            string[] words = text.Split('_');

            // join the words
            return JoinCamelCase(words);
        }

        /// <summary>
        /// This method parse a camel case string to underscore case.
        /// </summary>
        /// <param name="text">The string to parse.</param>
        /// <returns>The parsed string.</returns>
        public static string ParseCamelCaseToUnderscoreCase(string text)
        {
            // split the string
            string[] words = SplitCamelCase(text);

            // join the words
            return string.Join("_", words);
        }

        /// <summary>
        /// This method parse ConnectionString to Dictionary.
        /// </summary>
        /// <param name="text">The string to parse.</param>
        /// <returns>The parsed string.</returns>
        public static Dictionary<string, string> ParseConnectionString(string text)
        {
            // split the string
            string[] words = text.Split(';');

            // join the words,
            // NOTE: the key can be empty, just it's true value
            return words.Select(x => x.Split('='))
            .ToDictionary(x => x[0], x => x.Length < 2 ? "true" : x[1]);
        }

        /// <summary>
        /// Convert a dictionary to ConnectionString.
        /// </summary>
        /// <param name="dictionary">The dictionary to convert.</param>
        /// <returns>The converted string.</returns>
        public static string ToConnectionString(Dictionary<string, string> dictionary)
        {
            // join the words
            return string.Join(";", dictionary.Select(x => $"{x.Key}={x.Value}"));
        }

        /// <summary>
        /// This method render simple mustache template.
        /// </summary>
        /// <param name="template">The template to render.</param>
        /// <param name="data">The data to render.</param>
        /// <returns>The rendered template.</returns>
        public static string RenderMustacheTemplate(string template, Dictionary<string, string> data)
        {
            // find all mustache tags use regex
            var matches = System.Text.RegularExpressions.Regex.Matches(template, @"\{\{(.*?)\}\}");

            // render the template
            foreach (Match match in matches)
            {
                // get the tag
                string tag = match.Groups[1].Value;

                // get the value
                string value = data.ContainsKey(tag) ? data[tag] : string.Empty;

                // replace the tag
                template = template.Replace($"{{{tag}}}", value);
            }

            // return the rendered template
            return template;
        }
    }
}