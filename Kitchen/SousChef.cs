namespace Kitchen {
    public class SousChef : Cook {

        public void Cook(){
            TurnOnStove();
            Console.WriteLine("isStoveTurnedOn: " + isStoveTurnedOn);
        }
    }
}