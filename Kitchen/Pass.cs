namespace Kitchen
{

    public class Pass<T>
    {
        private Queue<T> _items = new Queue<T>();
        public void Send(T item)
        {
            Console.WriteLine("Sending " + item);
            _items.Enqueue(item);
        }
        public void Expedite() {
            Console.WriteLine("Expediting " + _items.Peek());
            _items.Dequeue(); }

    }
}