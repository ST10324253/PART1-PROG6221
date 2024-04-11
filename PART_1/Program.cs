namespace PART_1
{
    internal class Program
    {
        class ingredients//this is the class for the ingredients//
        {
            public String Name { get; set; }//get and set for the name//
            public String Unit { get; set; }//get and set for the unit//
            public double Quantity { get; set; }//get and set forthe quantity// 
        }
        class recipestep//this is a class for the step of the recipe//
        {
            public String description { get; set; }//get and set for the step desciption//
        }
        class recipe//class for recipe//
        {
            private List<ingredients>ingredient;//creating a private arraylist for the ingredients//
            private List<recipestep>step;//creating a private arraylist for the recipesteps//
            private List<ingredients> original;//this is a private list to reset the recipe back to the original//

            public recipe()//object of the recipe//
            {
                ingredient = new List<ingredients>();//this is from the private arraylist for the ingredients//
                step = new List<recipestep>();//this is the step arraylist //
                original =new List<ingredients>();//this is the original arraylist//
            }

            public void addingredients(string name, double quantity, string unit)//constructors//
            {
                var ingredients = new ingredients//these are the get and set for the ingredients//
                {
                    Name = name,
                    Quantity = quantity,
                    Unit = unit,


                };
                //here is for the arraylist to add the ingredients//
                ingredient.Add(ingredients);
                original.Add(new ingredients
                {
                    Name = name,
                    Quantity = quantity,
                    Unit = unit


                });
            }

            public void addstep(string description)//object for the step//
            {
                //this will add the steps to the arraylist//
                step.Add(new recipestep
                {
                    description = description
                });
            }

            public void display()//object to display//
            {
                //here we display the recipe on the console//
                Console.WriteLine("***Ingredients***");
                Console.WriteLine();

                foreach(var i1 in ingredient)
                {
                    Console.WriteLine($"{i1.Quantity} {i1.Unit} of {i1.Name}");
                }
                Console.WriteLine("***\n Steps***");
                Console.WriteLine();

                for(int i = 1; i<step.Count; i++)
                {
                    Console.WriteLine($"{1 + 1}.{step[i].description}");
                }
            }

            public void scale(string unit1)//this object is for the quantity//
            {
                foreach(var ingredient in ingredient)
                {
                    if(ingredient.Name.Equals(unit1, StringComparison.OrdinalIgnoreCase))
                    {
                        switch (unit1.ToLower())
                        {
                            case "half":
                                ingredient.Quantity /=2;
                                break;
                            case "double":
                                ingredient.Quantity *=2;
                                break;
                            case "triple":
                                ingredient.Quantity *= 3;
                                break;
                            default:
                                Console.WriteLine("invalid input");
                                break;
                        }
                    }
                }
            }

            public void reset()//this object is to reset the recipe back to the original//
            {
                ingredient.Clear();

                foreach(var o1 in original)//this will display the original recipe//
                {
                    ingredient.Add(new ingredients { Name = o1.Name, Quantity = o1.Quantity, Unit = o1.Unit });
                }
            }

            public void clear()//the object will clear the whole recipe//
            {
                ingredient.Clear();
                step.Clear();
                Console.WriteLine("recipe is cleared");
            }

          
        }

        static void Main(string[] args)
        {

            recipe recipe = new();//calling out the recipe object//

            Console.WriteLine("Welcome User");
            Console.WriteLine();

            while (true)//this will loop until the statement is false//
            {
                Console.WriteLine("1. Enter Recipe");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Change measurement");
                Console.WriteLine("4. Resest ");
                Console.WriteLine("5.Clear data");
                Console.WriteLine("6. Exit");
                

                int choice = Convert.ToInt32(Console.ReadLine());//convert to an integer//
                   
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("enter details for recipe");
                        Console.WriteLine("***Ingredients***(type 'done' when you finish writing the recipe)\n");

                        while (true)
                        {
                            string input = Console.ReadLine();                          
                                if (input.ToLower() == "done")//user will type 'done'to save the recipe//                                                     
                                break;

                            string[] parts = input.Split(',');
                            if (parts.Length != 3)
                            {
                                Console.WriteLine("invalid input (seperate name, quantity and unit with a comma(,))");//the user needs to seperate the ingredients with a comma// 
                                continue;
                            }
                            string name = parts[0].Trim();
                            double quantity;

                            if (!double.TryParse(parts[1].Trim(), out quantity)){
                                Console.WriteLine("invlaid quantity. please enter a valid number");//quantity needs to be an integer valuse//
                                continue;
                            }


                            string unit = parts[2].Trim();//trim is used to remove the white-space in thne string//
                            recipe.addingredients(name , quantity, unit);

                        }
                        Console.WriteLine("***Steps***");

                        while (true)
                        {
                            string step = Console.ReadLine();

                            if(step.ToLower()=="done")//the user dhould type done to display the step//
                                break;

                            recipe.addstep(step);
                        }

                        Console.WriteLine("recipe is saved successfully");
                        Console.WriteLine();
                        break;

                    case 2:
                        Console.WriteLine("The recipe");//this will display the recipe//
                        recipe.display();
                        Console.WriteLine();
                        break;

                    case 3:

                        Console.WriteLine("change it to: \t" + "half\t" + "double\t" + "triple");
                        string unit1 = Console.ReadLine();

                        recipe.scale(unit1);
                        Console.WriteLine();
                        break;

                    case 4:
                        recipe.reset();
                        Console.WriteLine("recipe has been reseted");//this will reset the recipe back to the original state//
                        Console.WriteLine();
                        break;

                    case 5:
                        recipe.clear();
                        Console.WriteLine();
                        break;

                    case 6:
                        Console.WriteLine("GOOD-BYE");
                        Environment.Exit(0);//this will close the console//
                        break;
             
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
            Console.ReadKey();
        }

    }
}
