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

//1.2.1 Check if the input is to remove a product (existing product-number in the list) or to add a product
if(int.TryParse(inputProduct, out int number) && number > 0 && number <= indexCounter)
    {
        choice = "removeProduct";
        Console.WriteLine($"{inputProduct} has been removed from the list");
    }

    //1.2.2 Check if the input is to find the costliest product
    else if(inputProduct.ToLower() == "costliest")
    {
        choice = "costliest";
        Console.WriteLine($"{inputProduct} is the costliest product in the list");
    }

    //1.2.3 Else, if a valid string was provided, which are none of the above, then add the product to the list
    else
    {
        choice = "addProduct";
        Console.WriteLine($"{inputProduct} has been added to the list");
    }

//1.3 Execute user input choices - pass them as arguments to the menu function that contain Switch-case
menu(choice, inputProduct, inputPrice, names, prices, indexCounter);


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

void sortCoupledListsAB(List<string> A, List<int> B)
{
    List<string> sortedA = [];          //Products sorted according to Prices will be saved here

    List<int> _B = B;                   //Save a copy of unsorted pricelist
    B.Sort();                           //Sort pricelist ascending
    B.Reverse();                        //Reverse the order, highest price first

    foreach(int price in _B)            //Foreach sorted price
    {
        int index = B.IndexOf(price);   //Find the original index in the new order
        sortedA.Add(A[index]);          //Identify products with original index, and add them in the new order
    }
    Console.WriteLine($"The most expensive product is {sortedA[0]}"); //cannot handle several products with same highest price - chould be solved with i.e. by while()
}

bool menu(string choice, string inputProduct, int inputPrice, List<string> names, List<int> prices, int indexCounter)
{
    switch (choice)
    {
        case "costliest": 
            sortCoupledListsAB(names, prices);
            return true;                        //continue the program

        case "removeProduct":
            int numb = int.Parse(inputProduct);
            names.RemoveAt(numb+1);
            prices.RemoveAt(numb+1);
            Console.WriteLine($"{names[numb+1]} has been removed fromt the list");
            return true;                        //continue the program

        case "exit":
            Console.WriteLine("Bye Bye");
            return false;                       //exit the program

        default: 
                    //check the input (integer as price) that it is not null. If valid return integer, else continue asking for a valid input while not true
                    while(checkInputIsInteger(question2));
                    Console.WriteLine($"The prices was set to {inputPrice}");
                    return true;                //continue the program      
    }
}