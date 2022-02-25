namespace AssignmentOne
{
    public class ReturnModel<T> : IReturnModel<T>
    {
        // Making this Generic is overkill for this purpose, but generic can always be good for future..

        public ReturnModel(T value, bool discarded = false)
        {
            Value = value;
            Discarded = discarded;
        }
        // Value is generic
        public T Value { get; set; }
        // bool to say if we care about the value
        public bool Discarded { get; set; }


    }

}
