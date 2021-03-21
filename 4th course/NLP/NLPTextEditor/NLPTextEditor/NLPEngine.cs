using edu.stanford.nlp.process;
using edu.stanford.nlp.tagger.maxent;
using java.util;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace NLPTextEditor
{
    public static class NLPEngine
    {
        private static readonly string Path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName 
            + @"\POSTagger\models\wsj-0-18-bidirectional-nodistsim.tagger";

        private static readonly MaxentTagger Tagger = new MaxentTagger(Path);

        public static string TagText(string text)
        {
            var taggedTextBuilder = new StringBuilder();
            var sentences = MaxentTagger.tokenizeText(new java.io.StringReader(text)).toArray();
            foreach (ArrayList sentence in sentences)
            {
                string taggedSentence = Tagger.tagSentence(sentence).ToString();
                string readableSentence = taggedSentence
                    .Trim('[', ']').Replace(", ", " ").Replace('/', '_').Replace("._.", ".") + Environment.NewLine;
                taggedTextBuilder.Append(readableSentence);
            }

            return taggedTextBuilder.ToString();
        }

        public static string TagWord(string word)
        {
            string wordWithTag = Tagger.tagString(word).Trim();
            int underscoreIndex = wordWithTag.IndexOf('_');
            return wordWithTag.Substring(underscoreIndex + 1);
        }

        public static string LemmatizeWord(string word, string tag) => Morphology.lemmaStatic(word, tag);

        public static bool TextIsTagged(string text)
        {
            int firstWordLength = text.IndexOf(' ');
            string firstWord = text.Substring(0, firstWordLength);
            return Regex.IsMatch(firstWord, @"[a-zA-Z-—']*_[a-zA-Z?$]*");
        }
    }
}
