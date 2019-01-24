class Launcher
{
    public static void Main()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddFirst(1);

        list.AddLast(4);
        list.AddLast(5);
        list.AddLast(6);

        System.Console.WriteLine(list.RemoveLast());
        System.Console.WriteLine(list.RemoveLast());
        System.Console.WriteLine(list.RemoveLast());
    }
}
