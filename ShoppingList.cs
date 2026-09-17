//Title:    Shopping List - Kunskapskontroll A
//Creator:  Arne Hagman
//Date:     17Sep2026 
//Course:   MAI26MA - Module II - Programmering och objektorinterad utveckling in C#

//external variables declaration
string question1 = "Enter product name: ";
string question2 = "Enter the Price (integer): ";
string? inputProduct = "Empty";
int inputPrice = 0;

//Function to check for valid user input (string). Parameter = question, return true or false.
bool checkInputIsString(string question) //OOP - could be a base class for checking input
{
    Console.Write(question);
    
    //Allow null value
    string? input = Console.ReadLine();

    //Check for invalid input characters (null/whitespace)
    //if(input != "")
    //Check for invalid input characters (null/whitespace)
    if(!string.IsNullOrWhiteSpace(input))
    {
        inputProduct=input;
        return false;
    }
    else
    {
        return true;
    }
}

//Function to check for valid user input (integer). Parameter = question, return true or false.
bool checkInputIsInteger(string question) //OOP - could inherit from the base class for checking input
{
    Console.Write($"{question}");

    //Allow null value
    //string? input = Console.ReadLine();

    //Check for invalid input characters (null/whitespace/non-numeric)
    if(int.TryParse(Console.ReadLine(), out int input))
    //if(int.TryParse(input))
    {
        inputPrice=input;
        return false;
    }
    else
    {
        return true;
    }
}