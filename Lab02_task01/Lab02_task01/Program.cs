Wintellect.PowerCollections.Stack<string> stack = new();

stack.Push("Hello");
stack.Push("World");

Console.WriteLine(stack.Capacity);
Console.WriteLine(stack.Pop() + $" ({stack.Count})");
Console.WriteLine(stack.Pop() + $" ({stack.Count})");