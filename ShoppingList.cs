//Title:    Shopping List - Kunskapskontroll A
//Creator:  Arne Hagman
//Date:     17Sep2026 
//Course:   MAI26MA - Module II - Programmering och objektorinterad utveckling in C#


//*************** External variables declaration ******************
//A. questions

string question1 = "Type:\n1) A product name to add a new product to the list\n2) A number to remove an existing product\n3) 'Costliest' to get the most expensive product\n4) 'Exit' to exit\n";
string question2 = "Enter the Price (integer): ";

//B. validated user inputs
string? inputProduct = "Empty";
int inputPrice = 0;

//C. validated user inputs translated to choices
string choice = "";

//D. variables that store the validated product/prices in two lists, both coupled with an index-tracker
List<string> names = [];
List<int> prices = [];
int indexCounter = names.Count;     //index-tracker

//E. variable that exits the main while loop, and ends the program
bool status = true;
//************** MAIN EXECUTION CODE *******************

do
{
    //1.0 Print the list and menu
    Console.Clear();
    Console.WriteLine("\t\tSHOPPING LIST");
    Console.WriteLine("_________________________________________");
    Console.WriteLine("NUMBER\t\tPRODUCT\t\tPRICE");
    for(int i=0; i < names.Count; i++)
    {
        Console.Write($"{i+1})\t\t{names[i]}\t\t{prices[i]} sek\n");
    }
    Console.WriteLine("_________________________________________");
    //2.0 Check that the input (string) is not null, if valid return string inputProduct, else repeat while not true
    while(checkInputIsString(question1));

    //2.1 Check if the input is to remove a product (existing product-number in the list) or to add a product
    if(int.TryParse(inputProduct, out int number) && number > 0 && number <= names.Count)
        {
            choice = "removeProduct";
            Console.WriteLine("this will remove the product");
        }

    //2.2 Check if the input is to find the costliest product
    else if(inputProduct.ToLower() == "costliest")
        {
            choice = "costliest";
        }

    else if(inputProduct.ToLower() == "exit")
        {
            choice = "exit";
        }
    //2.3 Else, if a valid string was provided, which are none of the above, then add the product to the list, then ask for price
    else
        {
            choice = "addProduct";
            
            //check the input (integer as price) that it is not null. If valid return integer, else continue asking for a valid input while not true
            while(checkInputIsInteger(question2));
        }

    //3.0 Execute user input choices - pass them as arguments to the menu function that contain Switch-case
    //returns a boolean to print the menu and list again (true), or to quite (false)
    status = menu(choice, inputProduct, inputPrice, names, prices, indexCounter);   
} while (status);

//**************** FUNCTIONS **********************

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

    //Check for invalid input characters (null/whitespace/non-numeric/negatives or zeroes)
    if(int.TryParse(Console.ReadLine(), out inputPrice) && inputPrice > 0)
    {
        //Console.WriteLine(inputPrice);
        return false;
    }
    else
    {
        return true;
    }
}

static void sortCoupledListsAB(List<string> A, List<int> B)
{
    List<string> sortedA = [];          //Products sorted according to Prices will be saved here

    List<int> internalCopyB = new List<int>(B);     //Save an internal copy of unsorted pricelist
    internalCopyB.Sort();                           //Sort price-order ascending
    internalCopyB.Reverse();                        //Reverse the price-order, highest price first

    foreach(int price in internalCopyB)             //Foreach sorted price
    {
        int index = B.IndexOf(price);  //Find the original index order for the sorted prices
        sortedA.Add(A[index]);          //Identify the new product order with original index, and add them in the new order to a new (sorted) price-list
    }
    Console.WriteLine($"The most expensive product is {sortedA[0]}"); //Note: cannot handle several products with same highest price - b ut could be easily solved with i.e. by conditionally testing foreach price in sorted prices, if the highest price exist in several places in the list, then print all positive hits.
    Console.WriteLine("Press any key to continue..");   //pause before clearing the console
    Console.ReadKey(true);                              //true hides the typed character
}

bool menu(string choice, string inputProduct, int inputPrice, List<string> names, List<int> prices, int indexCounter)
{
    switch (choice)
    {
        case "costliest": 
            sortCoupledListsAB(names, prices);
            //Console.WriteLine($"{inputProduct} is the costliest product in the list");
            return true;                        //continue the program

        case "removeProduct":
            int numb = int.Parse(inputProduct);
            names.RemoveAt(numb-1);
            prices.RemoveAt(numb-1);
            //Console.WriteLine($"{inputProduct} has been removed from the list");
            return true;                        //continue the program

        case "exit":
            Console.Clear();
            Console.WriteLine("Bye Bye");
            return false;                       //exit the program

        default:
            //if none of the validated user input options above are true, this is a product that need to be added to the shopping list together with the validated price
            names.Add(inputProduct);
            //Console.WriteLine($"{inputProduct} has been added to the list");

            prices.Add(inputPrice);
            //Console.WriteLine($"The price was set to {inputPrice}");
            return true;                //continue the program      
    }
}