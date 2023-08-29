namespace OnesTechSecureAccessGuard.Core.LinkedList
{
    public class MyLinkedListNode<T>
    {
        public T Value { get; set; }
        public MyLinkedListNode<T>? Next { get; set; }

        public MyLinkedListNode(T value)
        {
            Value = value;
            Next = null;
        }
    }

    public class MyLinkedList<T>
    {
        private MyLinkedListNode<T>? head;
        private MyLinkedListNode<T>? tail;

        public void Add(T value)
        {
            var newNode = new MyLinkedListNode<T>(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail!.Next = newNode;
                tail = newNode;
            }
        }

        public List<T> ToList()
        {
            List<T> list = new();
            MyLinkedListNode<T>? currentNode = head;

            while (currentNode != null)
            {
                list.Add(currentNode.Value);
                currentNode = currentNode.Next;
            }

            return list;
        }
    }

}