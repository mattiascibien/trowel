using System.Threading.Tasks;

namespace Trowel.Common.Shell.Hooks
{
    /// <summary>
    /// A hook that runs at startup
    /// </summary>
    public interface IStartupHook
    {
        /// <summary>
        /// Runs on startup
        /// </summary>
        /// <returns></returns>
        Task OnStartup();
    }
}
