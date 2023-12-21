using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LogicScript : MonoBehaviour
{
    public List<Question> questions;
    public Text QuestionText;
    public Text choice1;
    public Text choice2;
    public Text choice3;
    public Text choice4;
    private Question currentQuestion;
    private int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        questions = new List<Question>
        {
            new Question(
                "What is the capital of France?",
                new List<string> { "Paris", "Berlin", "London", "Madrid" },
                0), // Paris

            new Question(
                "Who wrote 'To Kill a Mockingbird'?",
                new List<string> { "Mark Twain", "Harper Lee", "J.K. Rowling", "Ernest Hemingway" },
                1), // Harper Lee

            new Question(
                "What is the chemical symbol for water?",
                new List<string> { "CO2", "H2O", "O2", "NaCl" },
                1), // H2O

            new Question(
                "Which planet is known as the Red Planet?",
                new List<string> { "Venus", "Saturn", "Mars", "Jupiter" },
                2), // Mars

            new Question(
                "What is the largest mammal?",
                new List<string> { "Elephant", "Blue Whale", "Giraffe", "Hippopotamus" },
                1)  // Blue Whale
        };

        currentIndex = 0;
        currentQuestion = questions[currentIndex];

        showCurrentQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void showCurrentQuestion()
    {
        QuestionText.text = currentQuestion.Text;
        choice1.text = currentQuestion.Choices[0];
        choice2.text = currentQuestion.Choices[1];
        choice3.text = currentQuestion.Choices[2];
        choice4.text = currentQuestion.Choices[3];

        choice1.color = Color.black;
        choice2.color = Color.black;
        choice3.color = Color.black;
        choice4.color = Color.black;
    }

    public void ChooseChoice1()
    {
        if(CheckAnswer(0))
        {
            makeBackgroundGreen(choice1);
        } else
        {
            makeBackgroundRed(choice1);
            showCorrectAnswer();
        }
    }

    public void ChooseChoice2()
    {
        if (CheckAnswer(1))
        {
            makeBackgroundGreen(choice2);
        }
        else
        {
            makeBackgroundRed(choice2);
            showCorrectAnswer();
        }
    }

    public void ChooseChoice3()
    {
        if (CheckAnswer(2))
        {
            makeBackgroundGreen(choice3);
        }
        else
        {
            makeBackgroundRed(choice3);
            showCorrectAnswer();
        }
    }

    public void ChooseChoice4()
    {
        if (CheckAnswer(3))
        {
            makeBackgroundGreen(choice4);
        }
        else
        {
            makeBackgroundRed(choice4);
            showCorrectAnswer();
        }
    }

    private bool CheckAnswer(int selectedChoice)
    {
        if (selectedChoice == currentQuestion.Key)
        {
            Debug.Log("Correct");
            return true;
        }else
        {
            Debug.Log("Sorry");
            return false;
        }
    }

    private void makeBackgroundGreen(Text textObj)
    {
        textObj.color = Color.green;
    }
    private void makeBackgroundRed(Text textObj)
    {
        textObj.color = Color.red;
    }

    private void showCorrectAnswer()
    {
        if (currentQuestion.Key == 0)
        {
            makeBackgroundGreen(choice1);
        } else if (currentQuestion.Key == 1)
        {
            makeBackgroundGreen(choice2);
        }
        else if (currentQuestion.Key == 2)
        {
            makeBackgroundGreen(choice3);
        }
        else if (currentQuestion.Key == 3)
        {
            makeBackgroundGreen(choice4);
        }
    }

    public void NextQuestion()
    {
        currentIndex++;
        currentQuestion = questions[currentIndex];
        showCurrentQuestion();
        
    }
}


public class Question
{
    public string Text;
    public List<string> Choices;
    public int Key;

    public Question(string text, List<string> choices, int key)
    {
        Text = text;
        Choices = choices;
        Key = key;
    }
}