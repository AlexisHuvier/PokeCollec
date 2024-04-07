var collec = new PokeCollec.PokeCollec();

collec.LoadData();

while (true)
{
    Console.Write("\n> ");
    var input = Console.ReadLine();
    if (input == "exit")
        break;

    collec.ProcessCommand(input);
}