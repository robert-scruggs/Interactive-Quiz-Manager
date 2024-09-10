using System.Security.Cryptography.X509Certificates;

Quiz q = new Quiz();
int userInput = 0;
while (userInput != 5){
    Console.WriteLine("What would you like to do?\n1. Add a question to the quiz\n2. Remove a question from the quiz\n3. Modify a question in the quiz\n4. Take the quiz\n5. Quit");
    userInput = int.Parse(Console.ReadLine());
    switch(userInput){
        case 5:
            break;
        case 1:
            q.addQuestion();
            break;
        case 2:
            q.removeQuestion();
            break;
        case 3:
            q.modifyQuestion();
            break;
        case 4:
            q.giveQuiz();
            break;
        
    }
}



class Question{
    //attributes
    private string text = "";
    private string answer = "";
    private int difficulty;
    //constructor
    public Question(string text, string answer, int difficulty){
        this.text = text;
        this.answer = answer;
        this.difficulty = difficulty;
    }
    //methods
    public string getText(){
        return text;
    }
    public void setText(string text){
        this.text = text;
    }
    public string getAnswer(){
        return answer;
    }
    public void setAnswer(string answer){
        this.answer = answer;
    }
    public int getDifficulty(){
        return difficulty;
    }
    public void setDifficulty(int difficulty){
        this.difficulty = difficulty;
    }

}

class Quiz{
    //attributes
    List<Question> questions = new List<Question>();
    //constructor
    public Quiz(){

    }
    //methods
    public void addQuestion(){
        Console.WriteLine("What is the question text?");
        string questionText = Console.ReadLine();
        Console.WriteLine("What is the answer?");
        string answerText = Console.ReadLine();
        Console.WriteLine("How difficult (1-3)?");
        int howDifficult = int.Parse(Console.ReadLine());
        Question question = new Question(questionText, answerText, howDifficult);
        questions.Add(question);
    }
    public void removeQuestion(){
        Console.WriteLine("Choose the question to remove?");
        foreach(Question q in questions){
            Console.WriteLine(questions.IndexOf(q)+ ". " + q.getText());
        }
        int questionToRemove = int.Parse(Console.ReadLine());
        questions.RemoveAt(questionToRemove);
    }
    public void modifyQuestion(){
        Console.WriteLine("Choose the question to modify?");
        foreach(Question q in questions){
            Console.WriteLine(questions.IndexOf(q)+ ". " + q.getText());
        }
        int questionToModify = int.Parse(Console.ReadLine());
        Console.WriteLine("What is the question text?");
        string questionText = Console.ReadLine();
        Console.WriteLine("What is the answer?");
        string answerText = Console.ReadLine();
        Console.WriteLine("How difficult (1-3)?");
        int howDifficult = int.Parse(Console.ReadLine());
        questions[questionToModify].setText(questionText);
        questions[questionToModify].setAnswer(answerText);
        questions[questionToModify].setDifficulty(howDifficult);

    }
    public void giveQuiz(){
        int score = 0;
        int totalQuestions = questions.Count();
        foreach (Question q in questions){
            Console.WriteLine(questions.IndexOf(q)+ ". " + q.getText());
            string response = Console.ReadLine();
            if (q.getAnswer() == response){
                Console.WriteLine("Correct");
                score++;
            }else{
                Console.WriteLine("Incorrect");
            }
        }
        Console.WriteLine("You got " + score + " out of " + totalQuestions);
    }
}


