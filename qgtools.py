import re

# Phrases used to reword sentences into questions/answers
phrases = {
    'is called':('What is', 'called'),
    'are called':('What are', 'called'),
    'was founded in':('Where/when was', 'founded'),
    'was founded by':('Who founded', ''),
    'is found in':('Where is', ''),
    'was born on':('Where/when was', 'born'),
    'was born in':('Where/when was', 'born'),
    'died on':('Where/when did', 'die'),
    'was an':('Who/what was', ''),
    'is an':('Who/what is', ''),
    'is a':('Who/what is', ''),
    'was a':('Who/what was', ''),
    'was the':('Who/what was', ''),
    'is the':('Who/what is', ''),
    'graduated from':('Where did', 'graduate from'),
    'are located in':('Where are', 'located in'),
    'is located in':('Where is', 'located in'),
    'contains':('What does', 'contain'),
    'REGEX:is \w+ in':('', ''),
    'REGEX:is \w+ on':('', ''),
    'REGEX:is \w+ during':('', ''),
    'REGEX:is \w+ by':('', ''),
    'REGEX:was \w+ in':('', ''),
    'REGEX:was \w+ on':('', ''),
    'REGEX:was \w+ during':('', ''),
    'REGEX:was \w+ by':('', ''),
    'REGEX:is *[\w+]* *[\w+]* *[\w+]* \w+ed into':('', ''),
    'REGEX:is *[\w+]* *[\w+]* *[\w+]* \w+ed to':('', ''),
    'REGEX:is *[\w+]* *[\w+]* *[\w+]* \w+ed as':('', ''),
    'REGEX:was *[\w+]* *[\w+]* *[\w+]* \w+ed into':('', ''),
    'REGEX:was *[\w+]* *[\w+]* *[\w+]* \w+ed to':('', ''),
    'REGEX:was *[\w+]* *[\w+]* *[\w+]* \w+ed as':('', ''),
    'REGEX:is *[\w+]* *[\w+]* *[\w+]* called':('', ''),
}

# Forbidden question
forbidden_middle = ('it', 'this', 'there', 'he', 'she')

# Forbidden starting substrings in question
forbidden_middle_starts = ('"', '7', '\'', 'and ', 'then ', 'what ', 'there ', 'it ', 'this ', 'he ', 'she ', 'that ', 'i ', 'said ', '-', 'although ', 'not ', 'however', 'another ', 'while ', 'because ')

# Forbidden substrings in question
forbidden_middle_contains = (' - ', ':', ';', 'example', 'which', 'latter', '  ', '\xa0')

# Lowercase words in question
lower_middles = ('the', 'a', 'an', 'this', 'one', 'in', 'on', 'also', 'with', 'from', 'of', 'all', 'each')

# Substrings that forcefully precuts answer short
middle_precutoffs = (';;', ',')

# Substrings that forcefully cuts answer short
answer_cutoffs = ('.', ' which', '(', ';')

# Forbidden substrings in answer
forbidden_answer_contains = (';;', '  ')

# Forbidden clauses at the end of questions
broken_clauses = (', ', 'that ', 'but ')

# Forbidden ending substrings in question
forbidden_middle_ends = ('but', 'and', 'that')

# Forbidden words in wildcard question
wildcard_forbidden = set('not')

def __middle_contains_broken_clause(middle):
    for clause in broken_clauses:
        space_count = 1
        if clause in middle:
            index = middle.index(clause)
            index += len(clause)
            while index < len(middle):
                if middle[index] == ' ':
                    space_count += 1
                index += 1
            if 1 <= space_count <= 2:
                return True
    return False

def __no_middle_contains_forbidden(middle):
    for word in forbidden_middle_contains:
        if word in middle:
            return False
    return True

def __no_wildcard_contains_forbidden(answer):
    for word in forbidden_answer_contains:
        if word in answer:
            return False
    return True

def __no_answer_contains_forbidden(answer):
    for word in forbidden_answer_contains:
        if word in answer:
            return False
    return True

def __middle_starts_forbidden(middle):
    for word in forbidden_middle_starts:
        if middle.startswith(word):
            return True
    return False

def __middle_endswith_forbidden(middle):
    for word in forbidden_middle_ends:
        if middle.endswith(word):
            return True
    return False

def __sufficient_middle(middle, wildcard=False):
    return not __middle_endswith_forbidden(middle) and not __middle_starts_forbidden(middle) and (wildcard or not __middle_contains_broken_clause(middle)) and (wildcard or __no_middle_contains_forbidden(middle)) and not middle.isdigit() and (wildcard or middle.count(',') < 2) and middle not in forbidden_middle

def __sufficient_answer(answer):
    return __no_answer_contains_forbidden(answer)

def __fix_middle(middle, precut=False, lower=True):
    middle = re.sub("[\(\[].*?[\)\]]", "", middle).strip()
    if lower:
        for word in lower_middles:
            if middle.lower().startswith(word + ' '):
                middle = middle[0].lower() + middle[1:]
    if precut:
        for word in middle_precutoffs:
            word += ' '
            if word in middle.lower():
                middle = middle[middle.rfind(word)+len(word):]
    return middle.strip()

def __fix_answer(answer, cutoffs=True):
    answer = re.sub("[\(\[].*?[\)\]]", "", answer).strip()
    if cutoffs:
        for word in answer_cutoffs:
            if word in answer:
                answer = answer.split(word)[0]
    if answer[-1] == '.' or answer[-1] == ',':
        answer = answer[:len(answer)-1]
    return answer.strip()

def __fix_url(url):
    import urllib.parse
    url = urllib.parse.urlsplit(url)
    url = list(url)
    url[2] = urllib.parse.quote(url[2])
    url = urllib.parse.urlunsplit(url)
    return url

def __get_text_from_website(url):
    from bs4 import BeautifulSoup
    from bs4.element import Comment
    import urllib.request

    url = __fix_url(url)

    def tag_visible(element):
        if element.parent.name in ['style', 'script', 'head', 'title', 'meta', '[document]']:
            return False
        if isinstance(element, Comment):
            return False
        return True

    def text_from_html(body):
        soup = BeautifulSoup(body, 'html.parser')
        texts = soup.findAll(text=True)
        visible_texts = filter(tag_visible, texts)
        return u" ".join(t.strip() for t in visible_texts)

    req = urllib.request.Request(url, data=None, headers={
            'User-Agent': 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_9_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.47 Safari/537.36'})

    return text_from_html(urllib.request.urlopen(req).read())
