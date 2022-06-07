namespace Helppad.Tree{
     /// <summary>
    /// Tries.
    /// In computer science, a **trie**, also called digital tree and sometimes 
    /// radix tree or prefix tree
    /// is a kind of search structure for strings, designed to map
    /// strings to other strings. It supports efficient prefix queries,
    /// such as finding the longest prefix of a given string that is also a
    /// prefix of another string.
    /// </summary>
    public class Tries
    {
        /// <summary>
        /// The root node.
        /// </summary>
        private TrieNode _root;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tries"/> class.
        /// </summary>
        public Tries(){
            _root = new TrieNode('*');
        }

        /// <summary>
        /// Adds the specified word.
        /// </summary>
        /// <param name="word">Word.</param>
        public void Add(string word){
            _root.Add(word);
        }

        /// <summary>
        /// Determines whether this instance contains the specified word.
        /// </summary>
        /// <returns><c>true</c> if this instance contains the specified word; otherwise, <c>false</c>.</returns>
        /// <param name="word">Word.</param>
        public bool Contains(string word){
            return _root.Contains(word);
        }

        /// <summary>
        /// Removes the specified word.
        /// </summary>
        /// <param name="word">Word.</param>
        public void Remove(string word){
            _root.Remove(word[0]);

            if(word.Length > 1){
                _root.Remove(word.Substring(1));
            }
        }

        /// <summary>
        /// Check if complete word exists in Trie.
        /// </summary>
        /// <returns><c>true</c>, if word exists, <c>false</c> otherwise.</returns>
        /// <param name="word">Word.</param>
        public bool IsWord(string word){
            var node = _root.GetChild(word[0]);

            if(node == null){
                return false;
            }

            if(word.Length == 1){
                return node.IsWord;
            }

            return node.IsWord && node.Contains(word.Substring(1));
        }

        /// <summary>
        /// Suggest next characters. given a prefix, return the set of all characters that
        /// could follow that prefix in the trie.
        /// </summary>
        /// <returns>The words.</returns>
        /// <param name="prefix">Prefix.</param>
        public List<string> SuggestWords(string prefix){
            var node = _root.GetChild(prefix[0]);

            if(node == null){
                return new List<string>();
            }

            if(prefix.Length == 1){
                return node.SuggestWords();
            }

            return node.SuggestWords(prefix.Substring(1));
        }
    }

    /// <summary>
    /// Trie node.
    /// This is a node of a Trie that stores a character and a list of children.
    /// </summary>
    public class TrieNode{
        public char Value;

        public Dictionary<char, TrieNode> Children;

        public bool IsWord  = false;

        public TrieNode(char value){
            Value = value;
            Children = new Dictionary<char, TrieNode>();
        }

        public void Add(string word){
            if(string.IsNullOrEmpty(word)){
                return;
            }

            var firstChar = word[0];
            var rest = word.Substring(1);

            if(!Children.ContainsKey(firstChar)){
                Children.Add(firstChar, new TrieNode(firstChar));
            }

            Children[firstChar].Add(rest);
        }

        /// <summary>
        /// Returns true if the word is in the trie
        /// </summary>
        public bool Contains(string word){
            if(string.IsNullOrEmpty(word)){
                return false;
            }

            return Children.ContainsKey(word[0]) && Children[word[0]].Contains(word.Substring(1));
        }

        /// <summary>
        /// Get child node by char
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public TrieNode GetChild(char c){
            if(Children.ContainsKey(c)){
                return Children[c];
            } else {
                return null;
            }
        }
        

        /// <summary>
        /// Remove word from trie
        /// </summary>
        /// <param name="charToRemove"></param>
        public void Remove(char charToRemove){
           
            /// get node by first char
            var node = GetChild(charToRemove);

            if(node == null || node.Children.Count > 0 || node.IsWord){
                return;
            } else {
                /// remove node
                Children.Remove(charToRemove);
            }
        }
    }
}