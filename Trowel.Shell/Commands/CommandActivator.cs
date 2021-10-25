using LogicAndTrick.Oy;
using Trowel.Common.Shell.Commands;
using System.Threading.Tasks;

namespace Trowel.Shell.Commands
{
    /// <summary>
    /// An activator that wraps a command
    /// </summary>
    internal class CommandActivator : IActivator
    {
        private readonly ICommand _command;
        public string Group => "Commands";
        public string Name => _command.Name;
        public string Description => _command.Details;

        public CommandActivator(ICommand command)
        {
            _command = command;
        }

        public async Task Activate()
        {
            await Oy.Publish("Command:Run", new CommandMessage(_command.GetID()));
        }
    }
}