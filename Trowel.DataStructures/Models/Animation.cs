using System.Collections.Generic;

namespace Trowel.DataStructures.Models
{
    public class Animation
    {
        public List<AnimationFrame> Frames { get; private set; }

        public Animation()
        {
            Frames = new List<AnimationFrame>();
        }
    }
}