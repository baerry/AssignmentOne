namespace AssignmentOne
{
    // since this class is never returned from a method and only instantiated once, there is no point to make a interface when there is no tests
    public class StepperClass
    {
        public int StepSize { get; set; }
        public int? Shoutout { get; set; }

        public List<string> Steps = new List<string>();

        // using count to find the number of shoutouts the range resulted in
        public int TotalShoutouts => Steps.Count(x => x == "Apendo");

        public StepperClass(int? shoutOut, int stepSize)
        {
            // we set the shoutout and stepsize in constructor
            // and handle the start and end values in the method that will iterate

            this.StepSize = stepSize;
            this.Shoutout = shoutOut;
        }

        // here we take start and end numbers
        public void Step(int startNum, int endNum)
        {

            // if start is less than end we increment
            // else we decrement
            if (startNum < endNum)
            {
                for (int i = startNum; i <= endNum; i += StepSize)
                {
                    if (Shoutout != null && i % Shoutout.Value == 0)
                    {
                        // if user has set shutout and the value is a multiple, we shoutout
                        Steps.Add("Apendo");
                    }
                    else
                    {
                        // else we just add the value
                        Steps.Add(i.ToString());
                    }
                }
            }
            else
            {
                for (int i = startNum; i >= endNum; i -= StepSize)
                {
                    if (Shoutout != null && i % Shoutout.Value == 0)
                    {
                        Steps.Add("Apendo");
                    }
                    else
                    {
                        Steps.Add(i.ToString());
                    }
                }
            }

            // to print it nicely we take all the values we have saved from the iteration and join them to a string using ", "
            Console.WriteLine(string.Join(", ", Steps));
        }

        public string GetContentAtIndex(int index)
        {
            // since index start at 0, but from a userfriendly point of view, it would be easier and more sense to expect a 1 to get first step, so we just decrement value by 1 to get correct value
            return Steps[index - 1].ToString();
        }
    }
}
