//Title:    Shopping List - Kunskapskontroll A
//Creator:  Arne Hagman
//Date:     17Sep2026 
//Course:   MAI26MA - Module II - Programmering och objektorinterad utveckling in C#

//external variables declaration
//A. questions
string question1 = "Enter product name: ";
string question2 = "Enter the Price (integer): ";

//B. validated user inputs
string? inputProduct = "Empty";
int inputPrice = 0;

//C. validated user inputs translated to choices
string choice = "";

//variables that store the validated product/prices in two lists, both coupled with an index-tracker
List<string> names = [];
List<int> prices = [];
int indexCounter = names.Count;     //index-tracker

//MAIN EXECUTION CODE

//1.1 Check that the input (string) is not null, if valid return string inputProduct, else repeat while not true
while(checkInputIsString(question1));
Console.WriteLine(inputProduct);

//1.2 Check if the input is to remove a product (existing product-number in the list) or to add a product
if(int.TryParse(inputProduct, out int number) && number > 0 && number <= indexCounter)
    {
        choice = "removeProduct";
    }
    else if(inputProduct.ToLower() == "costliest")
    {
        choice = "costliest";
        prices.Sort();
    }
    else
    {
        choice = "addProduct";
        names.Add(inputProduct);
        Console.WriteLine($"{inputPrice} has been added to the list");
    }

//check the input (integer as price) that it is not null. If valid return integer, else continue asking for a valid input while not true
while(checkInputIsInteger(question2));
Console.WriteLine(inputPrice);


//Function to check for valid user input (string). Parameter = question, return true or false.
bool checkInputIsString(string question)
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
bool checkInputIsInteger(string question)
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

(List<string> NamesList, List<int> PriceList) sortCoupledListsAB(List<string> A, List<int> B)
{
    return (A, B);
}

void menu(string choice, string inputProduct, int inputPrice, List<string> names, List<int> prices, int indexCounter);
{
    switch (choice)
    {
        case "costliest": break;
        case "removeProduct": 
            names.RemoveAt(number+1);
            prices.RemoveAt(number+1);
            indexCounter -= 1;
            Console.WriteLine($"{names[number+1]} has been removed fromt the list");
            break;
        default: break; //addProduct
    }
}