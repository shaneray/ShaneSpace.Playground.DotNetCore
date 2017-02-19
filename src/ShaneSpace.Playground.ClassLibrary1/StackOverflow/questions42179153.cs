using System;
using System.Collections.Generic;
using System.Linq;

namespace ShaneSpace.Playground.ClassLibrary1.StackOverflow
{
    /// <summary>
    /// https://stackoverflow.com/questions/42179153/nested-lists-or-any-other-structure-c-sharp
    /// 
    /// I am doing a quiz type game and I am trying to decide the best structure to handle it.
    /// 10 or more questions, each one will have multiple answers, all wrong but one.
    /// The user will choose the right one from 4 visible answers(radio buttons) randomly picked up from the list.It will be assured that the right answer is always picked up.
    /// The list will have multiple sub-lists inside (each one a question and multiple answers)
    /// In those sub-lists the first position[0] will be the question, all the rest[1...] will be the answers.
    /// My question is, nested lists are proper way of doing this? Am I thinking this right?
    /// </summary>
    class questions42179153
    {
        // core class
        public static class Quiz
        {
            private static Random rnd = new Random();
            public static Question[] Questions = new[]
            {
                new Question
                {
                    QuestionText = "Sample uestion 1?",
                    CorrectAnswer = "Answer to question 1",
                    WrongAnswers = new [] {
                        "Wrong answer 1",
                        "Wrong answer 2",
                        "Wrong answer 3",
                        "Wrong answer 4",
                        "Wrong answer 5",
                    }
                },
                new Question
                {
                    QuestionText = "Sample uestion 2?",
                    CorrectAnswer = "Answer to question 2",
                    WrongAnswers = new [] {
                        "Wrong answer 1",
                        "Wrong answer 2",
                        "Wrong answer 3",
                        "Wrong answer 4",
                        "Wrong answer 5",
                    }
                }
            };

            public class Question
            {
                public string QuestionText { get; set; }
                public string CorrectAnswer { get; set; }
                public string[] WrongAnswers { get; set; }

                public string[] GetMultipleChoice(int numberOfChoices)
                {
                    var list = new List<string>() { CorrectAnswer };
                    list.AddRange(WrongAnswers.Take(numberOfChoices - 1));

                    // shuffle
                    int n = list.Count;
                    while (n > 1)
                    {
                        n--;
                        int k = rnd.Next(n + 1);
                        var value = list[k];
                        list[k] = list[n];
                        list[n] = value;
                    }

                    return list.ToArray();
                }
            }
        }

        // console application
        static void Main(string[] args)
        {
            foreach (var question in Quiz.Questions)
            {
                // write question
                Console.WriteLine(question.QuestionText);
                Console.WriteLine(string.Join(Environment.NewLine, question.GetMultipleChoice(4)));

                var response = Console.ReadLine();

                if (response.Equals(question.CorrectAnswer, StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine("Wrong");
                }
            }
        }
    }
}
