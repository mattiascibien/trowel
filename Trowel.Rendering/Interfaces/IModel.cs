using Trowel.Rendering.Resources;
using System;
using System.Collections.Generic;

namespace Trowel.Rendering.Interfaces
{
    /// <summary>
    /// A model must render itself given the standard properties of the model pipeline.
    /// The transforms will be set before the model is rendered.
    /// </summary>
    public interface IModel : IDisposable, IResource
    {
        /// <summary>
        /// Get a list of sequences for this model.
        /// </summary>
        /// <returns>List of sequences</returns>
        List<string> GetSequences();
    }
}