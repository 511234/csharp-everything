namespace Kitchen
{
    class Program
    {

        static void Main()
        {
            SousChef sc = new SousChef();
            // ...is inaccessible due to its protection level
            // sc.TurnOnStove(); 
            sc.Cook();
        }

    }
}