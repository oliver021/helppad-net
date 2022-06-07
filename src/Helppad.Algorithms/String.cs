using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Helppad.Algorithms
{
    /// <summary>
    /// This class contains string algorithms.
    /// </summary>
    public class String
    {
        /// <summary>
        /// This method returns the number the occurs of one character in a string.
        /// </summary>
        /// <param name="str">The string to search.</param>
        /// <param name="c">The character to search for.</param>
        /// <returns>The number of times the character occurs in the string.</returns>
        public static int Count(string str, char c)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                {
                    count++;
                }
            }

            // return the number of times the character occurs in the string
            return count;
        }

        /// <summary>
        /// This method returns the number the occurs of one string in a string.
        /// </summary>
        /// <param name="str">The string to search.</param>
        /// <param name="substr">The string to search for.</param>
        /// <returns>The number of times the string occurs in the string.</returns>
        public static int Count(string str, string substr)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str.Substring(i, substr.Length) == substr)
                {
                    count++;
                }
            }

            // return the number of times the string occurs in the string
            return count;
        }

        /// <summary>
        /// This method returns every word that are adjacent to each other in a string.
        /// </summary>
        /// <param name="str">The string to search.</param>
        /// <param name="word">The word to search for pairs.</param>
        /// <returns>A string containing every word that are adjacent to each other in the string.</returns>
        
        public static string[] GetAdjacentWords(string str, string word)
        {
            string[] words = str.Split(' ');
            string[] adjacentWords = new string[words.Length];
            int index = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == word)
                {
                    adjacentWords[index] = words[i];
                    index++;
                    if (i + 1 < words.Length)
                    {
                        adjacentWords[index] = words[i + 1];
                        index++;
                    }

                    if (i - 1 >= 0)
                    {
                        adjacentWords[index] = words[i - 1];
                        index++;

                    }

                }
            }
            
            // return the words that are adjacent to each other in the string
            return adjacentWords;
        }

        /// <summary>
        /// Encodes a string using the Caesar cipher.
        /// </summary>
        /// <param name="str">The string to encode.</param>
        /// <param name="key">The key to use for the cipher.</param>
        /// <returns>The encoded string.</returns>
        public static string CaesarCipher(string str, int key)
        {
            string encoded = "";
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (char.IsLetter(c))
                {
                    if (char.IsUpper(c))
                    {
                        encoded += (char)(((c - 'A') + key) % 26 + 'A');
                    }
                    else
                    {
                        encoded += (char)(((c - 'a') + key) % 26 + 'a');
                    }
                }
                else
                {
                    encoded += c;
                }
            }

            // return the encoded string
            return encoded;
        }

        /// <summary>
        /// Decodes a string using the Caesar cipher.
        /// </summary>
        /// <param name="str">The string to decode.</param>
        /// <param name="key">The key to use for the cipher.</param>
        /// <returns>The decoded string.</returns>
        public static string CaesarCipher(string str, int key, bool decrypt)
        {
            string decoded = "";
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (char.IsLetter(c))
                {
                    if (char.IsUpper(c))
                    {
                        decoded += (char)(((c - 'A') - key) % 26 + 'A');
                    }
                    else
                    {
                        decoded += (char)(((c - 'a') - key) % 26 + 'a');
                    }

                }
                else
                {
                    decoded += c;
                }
            }

            // return the decoded string
            return decoded;
        }

        /// <summary>
        /// Encodes a string using the Vigenere cipher.
        /// </summary>
        /// <param name="str">The string to encode.</param>
        /// <param name="key">The key to use for the cipher.</param>
        /// <returns>The encoded string.</returns>
        public static string VigenereCipher(string str, string key)
        {
            string encoded = "";
            int keyIndex = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (char.IsLetter(c))
                {
                    if (char.IsUpper(c))
                    {
                        encoded += (char)(((c - 'A') + (key[keyIndex] - 'A')) % 26 + 'A');
                        keyIndex++;
                        if (keyIndex >= key.Length)
                        {
                            keyIndex = 0;
                        }

                    }
                    else
                    {
                        encoded += (char)(((c - 'a') + (key[keyIndex] - 'A')) % 26 + 'a');

                        keyIndex++;
                        if (keyIndex >= key.Length)
                        {
                            keyIndex = 0;
                        }
                    }
                }
                else
                {
                    encoded += c;
                }
            }

            // return the encoded string
            return encoded;
        }

        /// <summary>
        /// Decodes a string using the Vigenere cipher.
        /// </summary>
        /// <param name="str">The string to decode.</param>
        /// <param name="key">The key to use for the cipher.</param>
        /// <returns>The decoded string.</returns>
        public static string VigenereCipher(string str, string key, bool decrypt)
        {
            string decoded = "";
            int keyIndex = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (char.IsLetter(c))
                {
                    if (char.IsUpper(c))
                    {
                        decoded += (char)(((c - 'A') - (key[keyIndex] - 'A')) % 26 + 'A');
                        keyIndex++;
                        if (keyIndex >= key.Length)
                        {
                            keyIndex = 0;
                        }
                    }
                    else
                    {
                        decoded += (char)(((c - 'a') - (key[keyIndex] - 'A')) % 26 + 'a');
                        keyIndex++;
                        if (keyIndex >= key.Length)
                        {
                            keyIndex = 0;

                        }
                    }
                }
                else
                {
                    decoded += c;
                }
            }

            // return the decoded string
            return decoded;
        }

        /// <summary>
        /// Encodes a string using the Atbash cipher.
        /// </summary>
        /// <param name="str">The string to encode.</param>
        /// <returns>The encoded string.</returns>
        public static string AtbashCipher(string str)
        {
            string encoded = "";

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (char.IsLetter(c))
                {
                    if (char.IsUpper(c))
                    {
                        encoded += (char)('Z' - (c - 'A'));
                    }
                    else
                    {
                        encoded += (char)('z' - (c - 'a'));
                    }

                }
                else
                {
                    encoded += c;
                }
            }

            // return the encoded string
            return encoded;
        }

        /// <summary>
        /// Decodes a string using the Atbash cipher.
        /// </summary>
        /// <param name="str">The string to decode.</param>
        /// <returns>The decoded string.</returns>
        public static string AtbashCipher(string str, bool decrypt)
        {
            string decoded = "";

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];

                if (char.IsLetter(c))
                {
                    if (char.IsUpper(c))
                    {
                        decoded += (char)('A' + ('Z' - c));

                    }

                    else
                    {
                        decoded += (char)('a' + ('z' - c));
                    }

                }
                else
                {
                    decoded += c;
                }

            }

            // return the decoded string
            return decoded;
        }

        /// <summary>
        /// Encodes a string using the RailFence cipher.
        /// </summary>
        /// <param name="str">The string to encode.</param>
        /// <param name="key">The key to use for the cipher.</param>
        /// <returns>The encoded string.</returns>
        public static string RailFenceCipher(string str, int key)
        {
            string encoded = "";
            int keyIndex = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (char.IsLetter(c))
                {
                    if (keyIndex % 2 == 0)
                    {
                        encoded += c;
                    }
                    else
                    {
                        encoded += '-';

                    }

                    keyIndex++;

                }
                else
                {
                    encoded += c;
                }
            }
            // return the encoded string
            return encoded;
        }

        /// <summary>
        /// Decodes a string using the RailFence cipher.
        /// </summary>
        /// <param name="str">The string to decode.</param>
        /// <param name="key">The key to use for the cipher.</param>
        /// <returns>The decoded string.</returns>
        public static string RailFenceCipher(string str, int key, bool decrypt)
        {
            string decoded = "";
            int keyIndex = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];

                if (char.IsLetter(c))
                {
                    if (keyIndex % 2 == 0)
                    {
                        decoded += c;
                    }
                    else
                    {
                        decoded += '-';

                    }
                    keyIndex++;
                }
                else
                {
                    decoded += c;
                }
            }

            // return the decoded string
            return decoded;
        }

        /// <summary>
        /// Protect html source against XSS attacks.
        /// </summary>
        /// <param name="str">The string to protect.</param>
        /// <returns>The protected string.</returns>
        public static string XSSProtect(string str)
        {
            string result = "";

            // replace any html tags with their html entity equivalents
            result = str.Replace("<", "&lt;");
            result = result.Replace(">", "&gt;");

            // replace any single quotes with their html entity equivalents
            result = result.Replace("'", "&#39;");

            // replace any double quotes with their html entity equivalents
            result = result.Replace("\"", "&quot;");

            // replace any ampersands with their html entity equivalents
            result = result.Replace("&", "&amp;");

            // return the protected string
            return result;
        }

        /// <summary>
        /// Take every word in a string and reverse it and join it back together.
        /// </summary>
        /// <param name="str">The string to reverse.</param>
        /// <returns>The reversed string.</returns>
        public static string ReverseWords(string str)
        {
            string[] words = str.Split(' ');
            string result = "";
            
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                string reversed = new string(word.Reverse().ToArray());
                result += reversed + " ";
            }

            // return the reversed string
            return result;
        }

        /// <summary>
        /// Clear all malicious character or code from a string.
        /// </summary>
        /// <param name="str">The string to clear.</param>
        /// <param name="badChars">The bad chars.</param>
        /// <returns>The cleared string.</returns>
        public static string Clear(string str, char[] badChars)
        {
            string result = "";

            // loop through each character in the string
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];

                // check if the character is in the bad characters array
                bool badChar = badChars.Contains(c);

                // if the character is not in the bad characters array
                if (!badChar)
                {
                    // add the character to the result
                    result += c;
                }
            }

            // return the cleared string
            return result;
        }

        /// <summary>
        /// Clear all tags from html source.
        /// </summary>
        /// <param name="str">The string to clear.</param>
        /// <returns>The cleared string.</returns>
        public static string ClearTags(string str)
        {
            // using regex to remove all html tags
            string result = Regex.Replace(str, @"<[^>]*>", string.Empty);

            // return the cleared string
            return result;
        }

        /// <summary>
        /// Return true if the string is a valid email address.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <returns>True if the string is a valid email address.</returns>
        public static bool IsEmail(string str)
        {
            // using regex to check if the string is a valid email address
            
            bool result = Regex.IsMatch(str, @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");

            // return true if the string is a valid email address
            return result;
        }

        /// <summary>
        /// Return true if the string is a valid phone number.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <returns>True if the string is a valid phone number.</returns>
        public static bool IsPhone(string str)
        {
            // using regex to check if the string is a valid phone number
            bool result = Regex.IsMatch(str, @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");

            // return true if the string is a valid phone number
            return result;
        }

        /// <summary>
        /// Return true if the string is a valid URL.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <returns>True if the string is a valid URL.</returns>
        public static bool IsURL(string str)
        {
            // using regex to check if the string is a valid URL

            bool result = Regex.IsMatch(str, @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$");

            // return true if the string is a valid URL
            return result;
        }

        /// <summary>
        /// Return true if the string is a valid IP address.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <returns>True if the string is a valid IP address.</returns>
        public static bool IsIP(string str)
        {
            // using regex to check if the string is a valid IP address

            bool result = Regex.IsMatch(str, @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$");

            // return true if the string is a valid IP address
            return result;
        }

        /// <summary>
        /// Return true if the string is a valid credit card number.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <returns>True if the string is a valid credit card number.</returns>
        public static bool IsCreditCard(string str)
        {
            // using regex to check if the string is a valid credit card number

            bool result = Regex.IsMatch(str, @"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$");

            // return true if the string is a valid credit card number
            return result;
        }

        /// <summary>
        /// Return true if the string is a palindrome.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <returns>True if the string is a palindrome.</returns>
        public static bool IsPalindrome(string str)
        {
            // using regex to check if the string is a palindrome

            bool result = Regex.IsMatch(str, @"^(?:\w+\W*){1,}$");

            // return true if the string is a palindrome
            return result;
        }

        /// <summary>
        /// Return true if not has redundant characters.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <returns>True if not has redundant characters.</returns>
        public static bool IsUnique(string str)
        {
            // use distinct to get the distinct characters in the string
            string distinct = new string(str.Distinct().ToArray());

            // return true if the string has the same number of characters as distinct characters
            return str.Length == distinct.Length;
        }

        /// <summary>
        /// Return true if the string is a strong password.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <returns>True if the string is a strong password.</returns>
        public static bool IsStrongPassword(string str)
        {
            // using regex to check if the string is a strong password
            
            bool result = Regex.IsMatch(str, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");

            // return true if the string is a strong password
            return result;
        }

        /// <summary>
        /// Return true if every word in the string are repeated at least x times.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <param name="occurs">The minimum number of times a word must be repeated.</param>
        /// <returns>True if every word in the string are repeated at least x times.</returns>
        public static bool IsRepeated(string str, int occurs = 2)
        {
            // validate the occurs parameter: it must be greater than 1
            if (occurs < 2)
            {
                // throw an exception if occurs is less than 2
                // is logic 'cause is obvious that occurs can't be less than 2
                throw new ArgumentException("The parameter occurs must be greater than 1.");
            }

            // split the string into an array of words
            string[] words = str.Split(' ');

            // use a dictionary to store the words and their occurrences
            Dictionary<string, int> dict = new Dictionary<string, int>();

            // loop through the words in the array
            foreach (string word in words)
            {
                // if the word is already in the dictionary, increment the occurrence
                if (dict.ContainsKey(word))
                {
                    dict[word]++;
                }
                // otherwise add the word to the dictionary with an occurrence of 1
                else
                {
                    dict.Add(word, 1);
                }
            }

            // compare the number of occurrences of each word to the minimum number of occurrences
            return dict.All(x => x.Value >= occurs);
        }

        /// <summary>
        /// Get most the top common words in the string.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <param name="top">The number of top common words to get.</param>
        /// <returns>The top common words in the string with their occurrences.</returns>
        public static Dictionary<string, int> GetTopCommonWords(string str, int top = 5)
        {
            // validate the top parameter: it must be greater than 1
            if (top < 1)
            {
                // throw an exception if top is less than 1
                // top less than 1 doesn't make sense
                
                throw new ArgumentException("The parameter top must be greater than 1.");
            }

            // split the string into an array of words
            string[] words = str.Split(' ');

            // use a dictionary to store the words and their occurrences
            Dictionary<string, int> dict = new Dictionary<string, int>();

            // loop through the words in the array
            foreach (string word in words)
            {
                // if the word is already in the dictionary, increment the occurrence

                if (dict.ContainsKey(word))
                {
                    dict[word]++;

                }

                // otherwise add the word to the dictionary with an occurrence of 1
                else
                {
                    dict.Add(word, 1);
                }

            }

            // return the top common words in the string with their occurrences
            return dict.OrderByDescending(x => x.Value)
            .Take(top)
            .ToDictionary(x => x.Key, x => x.Value);
        }

        /// <summary>
        /// Given a word, find the phrases that precede and succeed it.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <param name="word">The word to find.</param>
        /// <param name="phaseLen">The length of the phase.</param>
        /// <returns>
        /// The phrases that precede and succeed the word.
        /// A dictionary with phrases.
        /// [key] = Array -> phrases
        /// </returns>
        public static Dictionary<string, string[]> GetPhrases(string str, string word, int phaseLen = 3)
        {
            // validate the phaseLen parameter: it must be greater than 1
            if (phaseLen < 1)
            {
                // throw an exception if phaseLen is less than 1
                // phaseLen less than 1 doesn't make sense

                throw new ArgumentException("The parameter phaseLen must be greater than 1.");
            }

            // validate the word parameter: it must be in the string
            if (!str.Contains(word))
            {
                // throw an exception if word is not in the string

                throw new ArgumentException("The parameter word must be in the string.");
            }

            // split the string into an array of words
            string[] words = str.Split(' ');

            // use a dictionary to store the phrases and their occurrences
            var dict = new Dictionary<string, string[]>();

            // loop through the words in the array
            for (int i = 0; i < words.Length; i++)
            {
                // if the word is the same as the word to find
                if (words[i] == word)
                {
                    // loop through the words in the array
                    for (int j = i - phaseLen; j <= i + phaseLen; j++)
                    {
                        // if the word is in the array
                        if (j >= 0 && j < words.Length)
                        {
                            // if the word is not the same as the word to find
                            if (words[j] != word)
                            {
                                // if the word is not already in the dictionary
                                if (!dict.ContainsKey(words[j]))
                                {
                                    // add the word to the dictionary with an empty array
                                    dict.Add(words[j], new string[] { });
                                }

                                // add the word to the array of the word in the dictionary
                                dict[words[j]] = dict[words[j]].Append(words[j]).ToArray();
                            }
                        }
                    }
                }
            }

            // return the phrases that precede and succeed the word
            return dict.ToDictionary(x => x.Key, x => x.Value.ToString().Split(' '));
        }

        /// <summary>
        /// Given a string, return the words that start with the letter $x.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <param name="letter">The letter to check.</param>
        /// <returns>The words with their occurs.</returns>
        public static Dictionary<string, int> GetWordsStartingWithLetter(string str, char letter)
        {
            // split the string into an array of words
            string[] words = str.Split(' ');

            // use a dictionary to store the words and their occurrences
            var dict = new Dictionary<string, int>();

            // loop through the words in the array
            foreach (string word in words)
            {
                // if the word starts with the letter
                if (word[0] == letter)
                {
                    // if the word is already in the dictionary, increment the occurrence
                    if (dict.ContainsKey(word))
                    {
                        dict[word]++;
                    }

                    // otherwise add the word to the dictionary with an occurrence of 1
                    else
                    {
                        dict.Add(word, 1);
                    }
                }
            }

            // return the number of words that start with the letter $x
            return dict;
        }

        /// <summary>
        /// Given two strings, return the words that are in both strings.
        /// </summary>
        /// <param name="str1">The first string to check.</param>
        /// <param name="str2">The second string to check.</param>
        /// <returns>The words that are in both strings.</returns>
        public static Dictionary<string, int> GetWordsInBothStrings(string str1, string str2)
        {
            // split the string into an array of words
            string[] words1 = str1.Split(' ');
            string[] words2 = str2.Split(' ');

            // use a dictionary to store the words and their occurrences
            var dict = new Dictionary<string, int>();

            // loop through the words in the array
            foreach (string word in words1)
            {
                // if the word is already in the dictionary, increment the occurrence
                if (dict.ContainsKey(word))
                {
                    dict[word]++;
                }

                // otherwise add the word to the dictionary with an occurrence of 1
                else
                {
                    dict.Add(word, 1);
                }

            }

            // loop through the words in the array
            foreach (string word in words2)
            {
                // if the word is already in the dictionary, increment the occurrence
                if (dict.ContainsKey(word))
                {
                    dict[word]++;
                }

                // otherwise add the word to the dictionary with an occurrence of 1
                else
                {
                    dict.Add(word, 1);
                }
            }

            // return the words that are in both strings
            return dict.Where(x => x.Value == 2).ToDictionary(x => x.Key, x => x.Value);
        }

        /// <summary>
        /// Given two terms compute Levenshtein distance
        /// </summary>
        /// <param name="term1">The first term.</param>
        /// <param name="term2">The second term.</param>
        /// <returns>The Levenshtein distance.</returns>
        public static int ComputeLevenshteinDistance(string term1, string term2)
        {
            // validate the parameters: they must not be null
            if (term1 == null || term2 == null)
            {
                // throw an exception if the parameters are null

                throw new ArgumentNullException("The parameters term1 and term2 must not be null.");
            }

            // validate the parameters: they must not be empty
            if (term1 == string.Empty || term2 == string.Empty)
            {
                // throw an exception if the parameters are empty

                throw new ArgumentException("The parameters term1 and term2 must not be empty.");
            }

            // get the length of the first term
            int term1Len = term1.Length;

            // get the length of the second term
            int term2Len = term2.Length;

            // create a matrix to store the Levenshtein distance
            int[,] matrix = new int[term1Len + 1, term2Len + 1];

            // loop through the rows of the matrix
            for (int i = 0; i <= term1Len; i++)
            {
                // loop through the columns of the matrix
                for (int j = 0; j <= term2Len; j++)
                {
                    // if the row is 0 or the column is 0
                    if (i == 0 || j == 0)
                    {
                        // set the value of the cell to 1
                        matrix[i, j] = 1;

                        // if the row is not 0 and the column is 0
                    }
                    else if (term1[i - 1] == term2[j - 1])
                    {
                        // set the value of the cell to the value of the cell above plus 1
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;

                        // if the row is not 0 and the column is not 0 and the characters are not the same
                    }
                    else
                    {
                        // set the value of the cell to the value of the cell above plus 1
                        matrix[i, j] = System.Math.Max(matrix[i - 1, j], matrix[i, j - 1]);

                        // if the row is not 0 and the column is not 0 and the characters are not the same
                    }

                    // if the row is not 0 and the column is not 0 and the characters are not the same
                    if (i > 0 && j > 0 && term1[i - 1] != term2[j - 1])
                    {
                        // set the value of the cell to the value of the cell above plus 1
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;

                        // if the row is not 0 and the column is not 0 and the characters are not the same
                    }
                }
            }

            // return the value of the bottom right cell
            return matrix[term1Len, term2Len];
        }
    }
}