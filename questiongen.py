from qgtools import phrases
from qgtools import __fix_middle, __fix_answer, __get_text_from_website
from qgtools import __sufficient_answer, __sufficient_middle, __no_wildcard_contains_forbidden
import sys
import re
import timeit

def rearrange_sentence(sentence):
    if sentence.count(', ') == 1:
        sentence1, sentence2 = sentence[sentence.index(', ')+len(', '):], sentence[:sentence.index(', ')]
        sentence2 = ', ' + sentence2[0].lower() + sentence2[1:]
        sentence = sentence1 + sentence2
        if sentence.startswith('and '):
            sentence = sentence.replace('and ', '')
    return sentence

def split_into_sentences(text):
    caps = "([A-Z])"
    prefixes = "(Mr|St|Mrs|Ms|Dr)[.]"
    suffixes = "(Inc|Ltd|Jr|Sr|Co)"
    starters = "(Mr|Mrs|Ms|Dr|He\s|She\s|It\s|They\s|Their\s|Our\s|We\s|But\s|However\s|That\s|This\s|Wherever)"
    acronyms = "([A-Z][.][A-Z][.](?:[A-Z][.])?)"
    websites = "[.](com|net|org|io|gov)"

    text = " " + text + "  "
    text = text.replace("\n"," ")
    text = re.sub(prefixes, "\\1<prd>", text)
    text = re.sub(websites, "<prd>\\1", text)
    if "Ph.D" in text: text = text.replace("Ph.D.","Ph<prd>D<prd>")
    text = re.sub("\s" + caps + "[.] "," \\1<prd> ", text)
    text = re.sub(acronyms+" "+starters,"\\1<stop> \\2", text)
    text = re.sub(caps + "[.]" + caps + "[.]" + caps + "[.]","\\1<prd>\\2<prd>\\3<prd>", text)
    text = re.sub(caps + "[.]" + caps + "[.]","\\1<prd>\\2<prd>", text)
    text = re.sub(" " + suffixes + "[.] " + starters, " \\1<stop> \\2", text)
    text = re.sub(" " + suffixes + "[.]", " \\1<prd>", text)
    text = re.sub(" " + caps + "[.]"," \\1<prd>", text)
    if "”" in text: text = text.replace(".”", "”.")
    if "\"" in text: text = text.replace(".\"", "\".")
    if "!" in text: text = text.replace("!\"", "\"!")
    if "?" in text: text = text.replace("?\"", "\"?")
    text = text.replace(".", ".<stop>")
    text = text.replace("?", "?<stop>")
    text = text.replace("!", "!<stop>")
    text = text.replace("<prd>", ".")
    text = text.replace("^  ", "")
    text = text.replace("  ", " <stop>")
    text = text.replace(" , ", ", ")
    sentences = text.split("<stop>")
    sentences = sentences[:-1]
    sentences = [s.strip() for s in sentences]
    return sentences

def text_to_question(sentence):
    for phrase in phrases:
        addQA = False
        is_wild_card = False
        search = ' ' + phrase + ' '
        if phrase.startswith('REGEX:'):
            is_wild_card = True
            regex = ' ' + phrase.replace('REGEX:', '') + ' '
            search = re.compile(regex).search(sentence)
            if search:
                search = search.group()
                if __no_wildcard_contains_forbidden(search):
                    middle, answer = sentence.split(search)[:2]
                    answer = __fix_answer(answer, cutoffs=False)
                    middle = __fix_middle(middle, lower=False)
                    question = middle + search
                    question = question.strip() + '?'
                    addQA = True
                    # question = '*** ' + question
        elif search in sentence:
            intro, end = phrases[phrase]
            middle, answer = sentence.split(search)[:2]
            answer = __fix_answer(answer)
            middle = __fix_middle(middle)
            addQA = True
            question = intro + ' ' + middle + ' ' + end
            question = question.strip() + '?'
        if addQA:
            """
            from qgtools import __middle_starts_forbidden, __middle_endswith_forbidden, __middle_contains_broken_clause, __middle_contains_broken_clause, forbidden_middle
            if 'is described by' in sentence:
                print(sentence)
                middle = middle.lower()
                print(middle)
                print(not __middle_endswith_forbidden(middle), not __middle_starts_forbidden(middle), (is_wild_card or not __middle_contains_broken_clause(middle)), (is_wild_card or __no_middle_contains_forbidden(middle)), not middle.isdigit(), middle.count(',') < 2, middle not in forbidden_middle)
                print(answer)
                print(__sufficient_answer(answer.lower()))
                exit()
            """
            if __sufficient_middle(middle.lower(), wildcard=is_wild_card) and __sufficient_answer(answer.lower()) and (question[0].isdigit() or question[0].isupper()):
                return question, answer

def text_to_questions(text, verbose=False, returnQADict=True, returnQuestions=False, returnAnswers=False):
    text = split_into_sentences(text)
    num = 0
    questions, answers, qaDict = set(), set(), dict()
    for sentence in text:
        result = text_to_question(sentence)
        if result:
            num += 1
            question, answer = result
            if question in qaDict:
                continue
            if returnQuestions:
                questions.add(question)
            if returnAnswers:
                answers.add(answer)
            if returnQADict:
                qaDict[question] = answer
            if verbose:
                print(result)
    if verbose:
        print('Number of questions:', num)
    result = []
    if returnQADict:
        result.append(qaDict)
    if returnQuestions:
        result.append(questions)
    if returnAnswers:
        result.append(answers)
    return tuple(result)

def main():
    if len(sys.argv) == 2:
        arg = sys.argv[1]

        start = timeit.default_timer()
        if arg.startswith('http'):
            text = __get_text_from_website(arg)
        else:
            file = open(arg, 'r')
            text = file.read().strip()
            file.close()
        stop = timeit.default_timer()
        rdl_time = stop-start
        start = timeit.default_timer()
        text_to_questions(text, verbose=True)
        stop = timeit.default_timer()
        qa_time = stop-start
        print('Read/download data time: {} sec'.format(rdl_time))
        print('Generate QAs time: {} sec'.format(qa_time))
    else:
        raise AttributeError('file name or URL must be passed as an argument\n(e.g. python3 {0} input.txt) or\n(e.g. python3 {0} https://en.wikipedia.org/wiki/DNA)'.format(sys.argv[0]))

if __name__ == "__main__":
    main()
