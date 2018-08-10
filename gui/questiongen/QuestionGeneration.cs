using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace questiongen
{
    class QuestionGeneration
    {
        public int totalQuestions = 0;
        public List<string> questions = new List<string>();
        public List<string> answers = new List<string>();

        public void convertToQuestions(ref string gen, ref string old, bool blanks)
        {
            gen = "";
            old += " ";

            if (!blanks)
            {
                formQuestion(0, " is called ", "What is ", " called?", ref gen, old);
                formQuestion(1, " are called ", "What are ", " called?", ref gen, old);
                formQuestion(2, " was founded in ", "Where/When was ", " founded?", ref gen, old);
                formQuestion(3, " was founded by ", "Who founded ", "?", ref gen, old);
                formQuestion(4, " is found in ", "Where is ", " found?", ref gen, old);
                formQuestion(5, " was born on ", "Where/When was ", " born?", ref gen, old);
                formQuestion(6, " was born in ", "Where/When was ", " born?", ref gen, old);
                formQuestion(7, " died on ", "Where/When did ", " die?", ref gen, old);
                formQuestion(8, " was an ", "Who/What was ", "?", ref gen, old);
                formQuestion(9, " is an ", "Who/What is ", "?", ref gen, old);
                formQuestion(10, " is a ", "Who/What is ", "?", ref gen, old);
                formQuestion(11, " was a ", "Who/What was ", "?", ref gen, old);
                formQuestion(12, " was the ", "Who/What was ", "?", ref gen, old);
                formQuestion(13, " is the ", "Who/What is ", "?", ref gen, old);
                formQuestion(14, " means ", "What does ", " mean?", ref gen, old);
                formQuestion(15, " graduated from ", "Where did ", " graduate from?", ref gen, old);
            }
            formBlank(16, " called ", "", ref gen, old);
            formBlank(17, " is a ", " that", ref gen, old);
            formBlank(18, "The ", " are", ref gen, old);
            formBlank(19, "The ", " is", ref gen, old);

            gen = "Total Questions: " + totalQuestions + gen;
            if (totalQuestions == 0) gen = "\n Sorry. No questions were generated.";
            gen = gen.Replace("\n", Environment.NewLine);
        }

        public bool formBlank(int qNum, string find, string afterFind, ref string gen, string old)
        {
            if (old.StartsWith(find)) return false; // prevent out of index
            string wordQ = "", wordA = "", tempWord = "", tempWord2 = "";
            int pos = 0, temp = 0;
            old = Regex.Replace(old, @" ?\[.*?\]", string.Empty); // removes all text following "[text]" format (used to remove citations)
            old += ".";
            if (old.Contains(find))
            {
                while (old.Contains(find))
                {
                    wordQ = getMatchedString(find, old).First();

                    if (wordQ.Contains("^") || (qNum == 16 && wordQ.Contains(" and called ")))
                    {
                        old = old.Substring(old.IndexOf(find) + find.Length);
                        continue;
                    }

                    while (wordQ.StartsWith(" ")) wordQ = ReplaceFirst(wordQ, " ", "");
                    if (!string.IsNullOrEmpty(wordQ) && char.IsLower(wordQ[0]))
                    {
                        old = old.Substring(old.IndexOf(find) + find.Length);
                        continue;
                    }

                    tempWord = Char.ToLowerInvariant(wordQ[0]) + wordQ.Substring(1);
                    if (tempWord.StartsWith("This"))
                    {
                        old = old.Substring(old.IndexOf(find) + find.Length);
                        continue;
                    }

                    wordA = getMatchedString(find, old).First();

                    if (!afterFind.Equals("") && wordA.Contains(afterFind))
                    {
                        tempWord = wordA.Substring(wordA.IndexOf(afterFind));
                        if (!tempWord.Contains(find))
                            wordA = wordA.Replace(tempWord, "");
                    }

                    pos = wordA.IndexOf(find) + find.Length;
                    tempWord = wordA.Substring(0, pos);
                    wordA = wordA.Replace(tempWord, "");

                    if (wordA.Contains(","))
                    {
                        tempWord = wordA.Substring(wordA.IndexOf(","));
                        wordA = wordA.Replace(tempWord, "");
                    }
                    if (wordA.Contains(")"))
                    {
                        wordA = wordA.Replace(")", "");
                    }
                    wordA = wordA.Replace("\"", "");
                    if(wordA.StartsWith("a "))
                        wordA = ReplaceFirst(wordA, "a ", "");
                    if (wordA.StartsWith("the "))
                        wordA = ReplaceFirst(wordA, "the ", "");
                    if (wordA.Contains("("))
                        wordA = wordA.Replace(wordA.Substring(wordA.IndexOf("(")), "");

                    tempWord = Char.ToLowerInvariant(wordA[0]) + wordA.Substring(1);
                    if (tempWord.StartsWith("it") || tempWord.Contains(" and ") || tempWord.Length > 30)
                    {
                        old = old.Substring(old.IndexOf(find) + find.Length);
                        continue;
                    }

                    wordQ = wordQ.Replace("" + wordA, "____________");
                    if (!afterFind.Equals("") && !wordQ.Substring(wordQ.IndexOf("____________")+12).StartsWith(afterFind))
                    {
                        old = old.Substring(old.IndexOf(find) + find.Length);
                        continue;
                    }

                    if ((qNum != 16) && (wordA.EndsWith("ing")))
                    {
                        old = old.Substring(old.IndexOf(find) + find.Length);
                        continue;
                    }

                    temp = 0;
                    tempWord = wordQ;
                    tempWord2 = "____________";
                    while (tempWord.Contains(tempWord2)) // checks how many times it replaces with ____________
                    {
                        temp++;
                        tempWord = tempWord.Substring(tempWord.IndexOf(tempWord2) + tempWord2.Length);
                    }
                    if (!wordQ.Contains("_") || temp > 1 || wordQ.Length <= 30 || wordQ.StartsWith("This") || wordQ.StartsWith("It"))
                    {
                        old = old.Substring(old.IndexOf(find) + find.Length);
                        continue;
                    }

                    while (wordQ.Contains("\n"))
                    {
                        pos = wordQ.IndexOf("\n");
                        wordQ = wordQ.Substring(pos + 1);
                    }

                    gen += "\n Q: " + wordQ + ".";
                    gen += "\n A: " + wordA;
                    gen += "\n";
                    totalQuestions++;

                    questions.Add(wordQ + ".");
                    answers.Add(wordA);

                    old = old.Substring(old.IndexOf(find) + find.Length);
                }
                
                if (gen.Equals("")) return false;
                return true;
            }
            else
                return false;
        }

        public bool formQuestion(int qNum, string find, string introQ, string concludeQ, ref string gen, string old)
        {
            if (old.StartsWith(find)) return false; // prevent out of index
            string wordQ = "", wordA = "", tempWord = "", originalIntroQ = introQ;
            int pos = 0, length = 0, temp = 0;
            old = Regex.Replace(old, @" ?\[.*?\]", string.Empty); // removes all text following "[text]" format (used to remove citations)
            old = Regex.Replace(old, @" ?\(.*?\)", string.Empty); // removes all text following "(text)" format (used to remove citations)
            if (old.Contains(find))
            {
                while (old.Contains(find))
                {
                    wordQ = getMatchedString(find, old).First();

                    if (wordQ.Contains("^"))
                    {
                        old = old.Substring(old.IndexOf(find) + find.Length);
                        continue;
                    }

                    pos = wordQ.IndexOf(find);
                    wordQ = wordQ.Substring(0, pos);
                    while (wordQ.Contains("\n"))
                    {
                        pos = wordQ.IndexOf("\n");
                        wordQ = wordQ.Substring(pos + 1);
                    }
                    wordQ = wordQ.TrimStart(' ');
                    if (wordQ.Contains(" "))
                    {
                        if (wordQ.IndexOf(" ") <= 3 && !char.IsUpper(wordQ[1]))
                            wordQ = Char.ToLowerInvariant(wordQ[0]) + wordQ.Substring(1); // may need to be removed due to names/places
                    }

                    if (wordQ.Equals(string.Empty)) // prevent from proceeding if wordQ is empty
                    {
                        old = old.Substring(old.IndexOf(find) + find.Length);
                        continue;
                    }

                    tempWord = Char.ToLowerInvariant(wordQ[0]) + wordQ.Substring(1);
                    if (tempWord.Equals("it") || tempWord.Equals("this") || tempWord.Equals("they") || tempWord.Equals("there") || tempWord.EndsWith("who")
                     || tempWord.Equals("he") || tempWord.Equals("she") || tempWord.StartsWith("\"") || (tempWord.StartsWith("in") && !tempWord.Contains(","))
                     || tempWord.EndsWith("place") || tempWord.StartsWith("his") || tempWord.EndsWith("her") || tempWord.EndsWith("and") || tempWord.EndsWith("it")
                     || tempWord.Contains(", and ") || tempWord.EndsWith("of this") || tempWord.EndsWith("which") || tempWord.Equals("these") || tempWord.StartsWith("such")
                     || tempWord.Contains("another") || tempWord.Contains("—") || tempWord.Contains("and when") || tempWord.EndsWith(", this") || tempWord.Contains(", if")
                     || tempWord.StartsWith("but ") || tempWord.StartsWith("of course")

                     || ((qNum >= 8 && qNum <= 13) && (tempWord.Contains("that") || tempWord.Contains("while") || tempWord.StartsWith("due") || tempWord.StartsWith("during")
                                                   || tempWord.StartsWith("from") || tempWord.StartsWith("as") || tempWord.StartsWith("being") || tempWord.Contains("although")
                                                   || tempWord.Contains(", though") || tempWord.Contains("because") || tempWord.Contains("since") || tempWord.EndsWith("he")
                                                   || tempWord.EndsWith("she") || tempWord.EndsWith("such")))
                     || (qNum == 14 && (wordQ.Contains("as"))))
                    {
                        old = old.Substring(old.IndexOf(find) + find.Length);
                        continue;
                    }

                    if (wordQ.Contains(";")) // start question from ';' if wordQ contains it
                    {
                        wordQ = wordQ.Substring(wordQ.IndexOf(";"));
                        wordQ = wordQ.Replace(";", "");
                    }

                    rearrangeQ(ref wordQ, "in", ",");
                    rearrangeQ(ref wordQ, "according", ",");
                    rearrangeQ(ref wordQ, "at the time", ",");
                    rearrangeQ(ref wordQ, "whereas", ",");

                    if (wordQ.EndsWith(",")) // removes comma from end of question selection
                    {
                        tempWord = wordQ.Substring(wordQ.Length - 1);
                        wordQ = wordQ.Replace(tempWord, "");
                    }
                    if (wordQ.Contains(")") && !wordQ.Contains("("))
                        wordQ = wordQ.Replace(")", "");
                    
                    pos = old.IndexOf(find) + find.Length;
                    wordA = old.Substring(pos);
                    length = wordA.IndexOf(".");
                    if (length != -1) wordA = wordA.Substring(0, length);
                    if (wordA.StartsWith("a "))
                    {
                        wordA = old.Substring(pos + 2);
                        length = wordA.IndexOf(".");
                        if (length != -1) wordA = wordA.Substring(0, length);
                    }
                    while (wordA.Contains("\n"))
                    {
                        pos = wordA.IndexOf("\n");
                        wordA = wordA.Substring(0, wordA.IndexOf("\n"));
                    }
                    while (wordA.Contains(";"))
                    {
                        pos = wordA.IndexOf(";");
                        wordA = wordA.Substring(0, wordA.IndexOf(";"));
                    }
                    wordA = wordA.Replace(".", string.Empty); // removes period from answer

                    if (wordA.Equals("stub") || (qNum == 14 && wordA.StartsWith("of")) || ((qNum >= 8 && qNum <= 13) && wordA.StartsWith("subject of")) || wordA.Length < 1)
                    {
                        old = old.Substring(old.IndexOf(find) + find.Length);
                        continue;
                    }

                    if ((qNum >= 8 || qNum <= 13) && (wordQ.StartsWith("a ") || wordQ.StartsWith("the") || wordQ.ToLower().StartsWith("these") || wordQ.Substring(0, (int)(wordQ.Length / 1.5)).Contains("'s")
                                                   || wordQ.Contains("what") || char.IsLower(wordQ[0])))
                        introQ = introQ.Replace("Who/What", "What");
                    else
                        introQ = introQ.Replace("Who/What", "Who/What");

                    if ((qNum == 2 || qNum == 5 || qNum == 6 || qNum == 7) && wordA.Any(char.IsDigit))
                        introQ = introQ.Replace("Where/When", "When");
                    else
                        introQ = introQ.Replace("Where/When", "Where");

                    if (wordQ.Contains(". These"))
                    {
                        tempWord = old;
                        pos = tempWord.IndexOf(". These");
                        tempWord = tempWord.Substring(pos - 175);
                        pos = tempWord.IndexOf(".");
                        tempWord = tempWord.Substring(pos + 2);
                        temp = tempWord.IndexOf(".");
                        tempWord = tempWord.Substring(0, temp + 2);
                        gen += "\n Q: " + tempWord + introQ + wordQ + concludeQ;
                        gen += "\n A: " + wordA;
                        gen += "\n";
                        totalQuestions++;
                    }
                    else
                    {
                        gen += "\n Q: " + introQ + wordQ + concludeQ;
                        gen += "\n A: " + wordA;
                        gen += "\n";
                        totalQuestions++;

                        questions.Add(introQ + wordQ + concludeQ);
                        answers.Add(wordA);
                    }

                    introQ = originalIntroQ;
                    old = old.Substring(old.IndexOf(find) + find.Length);
                }
                if (gen.Equals("")) return false;
                return true;
            }
            return false;
        }

        public List<string> getMatchedString(string match, string input)
        {
            var sentenceList = input.Split(new char[] { '.', '?', '!' });
            var regex = new Regex(match);
            return sentenceList.Where(sentence => regex.Matches(sentence, 0).Count > 0).ToList();
        }

        public string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        public void rearrangeQ(ref string textToRearrange, string startsWith, string endsWith)
        {
            string str = Char.ToLowerInvariant(textToRearrange[0]) + textToRearrange.Substring(1); // lowercase first letter
            if (str.StartsWith(startsWith) && str.Contains(endsWith))
            {
                int pos = str.IndexOf(startsWith);
                int temp = str.IndexOf(endsWith);
                string tempWord = str.Substring(0, temp - pos);
                str = str.Replace(tempWord + ", ", "");
                str += " " + tempWord;
                textToRearrange = str;
            }
        }
    }
}
