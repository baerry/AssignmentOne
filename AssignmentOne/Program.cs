namespace AssignmentOne
{
    public class Program
    {

        private static int Start { get; set; }
        private static int End { get; set; }

        private static int MaxStep => Start < End ? End - Start : Start - End;

        private static  bool KeepMeAlive = true;

        static void Main(string[] args)
        {
            while (KeepMeAlive)
            {
                Console.WriteLine("Welcome to assignment 1");

                Start = GetUserInputAsInt("Please enter a number without decimals to start from", required: true).Value;

                End = GetUserInputAsInt("Please enter a number without decimals to end at", required: true).Value;

                // trying to be userfriendly and give hints about what will work and not by calculating the maximum value that will yield more steps
                var stepsize = GetUserInputAsInt($"Please enter a number without decimals to set stepsize" +
                    $"\n(1 is minimum and default, {MaxStep} is maximum for it to print anything else then start number)", required: false);

                // giving the user an option to discard having set a value
                var shoutout = GetUserInputAsInt($"Please enter a number without decimals to give shoutout" +
                    $" at said numbers multiples,\njust press enter to discard this option", required: false);

                // setting up a StepperClass that will handle all the interations based on the value it will have sent in.
                // public properties inside it, makes it handle both parameters from constructor or to be set at any time
                // it checks so that default values will be set if values are discarded or to not compatible
                var stepper = new StepperClass(shoutout.Discarded ? null : shoutout.Value, (stepsize.Discarded || stepsize.Value < 1) ? 1 : stepsize.Value);

                // since we now have gathered both a start and end number, we set the paramters for the Step function and let stepping begin
                stepper.Step(Start, End);

                // making a variable make the code less cluttered
                var maxIndex = stepper.Steps.Count;

                var gettingValue = true;

                while (gettingValue)
                {
                    // staying in the whileloop until we get what we want

                    var numberAt = GetUserInputAsInt($"Please enter a number without decimals to get the number hiding at that index," +
                    $"\n(1 is minimum and {maxIndex} is maximum)", required: true);

                    if (numberAt.Value >= 1 && numberAt.Value <= maxIndex)
                    {
                        // if the number is 1 or higher and inside the range we print 
                        Console.WriteLine($"\n\nAt index {numberAt.Value} you find {stepper.GetContentAtIndex(numberAt.Value)}");
                        Console.WriteLine($"\n\nThis resulted in a total of {stepper.TotalShoutouts} Apendo shoutouts");
                        gettingValue = false;
                    }
                    else
                    {
                        // else we tell them what went wrong and try again
                        Console.WriteLine($"{numberAt.Value} is not inside the range of 1 and {maxIndex}");
                    }
                }

                gettingValue = true;

                // giving the user a choice to try again or quit
                Console.WriteLine("\n\nDo you want to go again? (Y)yes / (N)no");
                while (gettingValue)
                {
                    // staying in the whileloop until we get what we want

                    var key = Console.ReadKey().Key;

                    if (key == ConsoleKey.Y)
                    {
                        //since user want another go, we break from loop and clear the console.
                        gettingValue = false;
                        Console.Clear();

                    }
                    else if (key == ConsoleKey.N)
                    {
                        // since the user has had enugh of fun for today we stop both loops and let the program end
                        gettingValue = false;
                        KeepMeAlive = false;
                    }
                }
            }
        }


        public static IReturnModel<int> GetUserInputAsInt(string phrase, bool required = false)
        {
            // method to gather user inputs, instead of just doing parsing all over the place, i use this method to gather and parse input from user, makes for cleaner code and eaiser to refactor/maintain
            // i chose to make a ReturnModel to make this function easy to grow as more types of input could want to be gathered in future.
            
            Console.WriteLine($"\n\n{phrase}");
            bool readingInPut = true;
            // could have just assined true in the while since its always going to use return to escape the loop, but for easier readability i choose to assign it a variable with a name. ex. while (true)

            while (readingInPut)
            {
                var numInput = Console.ReadLine();

                // checking if its required and if its empty
                if (!required && string.IsNullOrWhiteSpace(numInput))
                {
                    // since we didnt require this value and user entered no value, we return it as discarded
                    return new ReturnModel<int>(0, discarded: true);
                }

                if (!string.IsNullOrWhiteSpace(numInput))
                {
                    // since the value is not null empty or only whitespaces we parse
                    int number;
                    if (int.TryParse(numInput, out number))
                    {
                        // if parsing was successful we return our generic model as int
                        return new ReturnModel<int>(number);
                    }
                    else
                    {
                        // if parsing was not successful we give an error message
                        Console.WriteLine($"Error: {numInput} is not a valid entry");
                    }
                }
                else
                {
                    // since this is required step and its empty or whitespaces, we tell user it is a required step
                    Console.WriteLine("This is a required step");
                }
            }
            //point of no return, we should not get here since we escape this loop with returns only
            return new ReturnModel<int>(0);
        }
       
    }
}
