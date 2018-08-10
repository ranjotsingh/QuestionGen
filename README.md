# QuestionGen

QuestionGen is a question generator that uses the essential information from a body of text in order to construct questions and their corresponding answers. Additionally, a provided GUI can be used to construct a quiz with multiple choice and fill in the blank questions automatically for users to answer.

## Command line
### Installation
Download `qgtools.py` and `questiongen.py` from this repository. Python3 must be installed for usage.

### Usage
To generate Q&A from a text file, use the following command:<br>
`python3 questiongen.py input.txt`<br>

To generate Q&A from a website link, use the following command:<br>
`python3 questiongen.py https://en.wikipedia.org/wiki/DNA`<br>

You may also use this as a package as follows:<br>
```
import questiongen

text = 'George Washington was born on February 22, 1732, in Westmoreland County, Virginia.'
question, answer = questiongen.text_to_question(text)
print('Q: {0}\nA: {1}'.format(question, answer))
```
Output:
```
Q: Where/when was George Washington born?
A: February 22, 1732, in Westmoreland County, Virginia
```

## GUI
Note: The GUI is no longer being updated.
### Installation

You can install QuestionGen by downloading the executable file [here](https://github.com/ranjotsingh/QuestionGen/releases/download/v1.0/questiongen.exe) (Windows).

### Usage

1. You can input text that you wish to be analyized (e.g. copying information from a Wikipedia article on DNA and pasting it into the program):
![alt text](https://raw.githubusercontent.com/ranjotsingh/QuestionGen/master/images/question_gen1.png)

2. Click submit and begin to answer the generated questions:
![alt text](https://raw.githubusercontent.com/ranjotsingh/QuestionGen/master/images/question_gen2.png)

3. You can view all of the questions and their corresponding answers by viewing the answer sheet:
![alt text](https://raw.githubusercontent.com/ranjotsingh/QuestionGen/master/images/question_gen3.png)
