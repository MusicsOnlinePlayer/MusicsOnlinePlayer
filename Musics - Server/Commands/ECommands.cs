namespace Musics___Server.Commands
{
    public enum ECommands
    {
        [CommandSyntax(command: "-quit")]
        Quit,
        [CommandSyntax(command: "-init")]
        InitializeRepository,
        [CommandSyntax(command: "-index")]
        Indexation,
        [CommandSyntax(command: "-save")]
        Save,
        [CommandSyntax(command: "-users")]
        Users,
        [CommandSyntax(command: "-users -a|-users -all")]
        AllUsers,
        [CommandSyntax(command: "-set")]
        Set,
        [CommandSyntax(command: "-set multithreading|-set mt")]
        SetMultithreading,
        [CommandSyntax(command: "-get")]
        Get,
        [CommandSyntax(command: "-get multithreading|-get mt")]
        GetMultithreading,
        [CommandSyntax(command: "-promote")]
        Promote,
        [CommandSyntax(command:"-connect")]
        ConnectServer
    }
}
