namespace AssignmentOne
{
    // i guess making a interface when we arent going include more sources is kinda redundant,
    // but atleast we can use the interface as return type for the method GetUserInputAsInt,
    // to make the code easier to tests if there would have been unit tests
    public interface IReturnModel<T>
    {
        bool Discarded { get; set; }
        T Value { get; set; }
    }
}