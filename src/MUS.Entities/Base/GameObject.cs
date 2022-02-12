using MUS.Common.Interfaces;
using MUS.Common.Interfaces.EntityInterfaces;

namespace MUS.Entities.Base
{
    public abstract class GameObject : IGameObject
    {
        /// <summary>
        /// Name of the Game Object. This is the human-readable id of the game object in question.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the item in question. 
        /// </summary>
        public string Description { get; set; }

    }
}
