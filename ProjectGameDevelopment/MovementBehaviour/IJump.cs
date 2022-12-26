using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.MovementBehaviour
{
    public interface IJump
    {
        /// <summary>
        /// Deze Interface zal de basis geven voor Entiteiten die kunnen/zullen springen
        /// </summary>
        float StartY { get; set; }
        float JumpSpeed { get; set; }
        bool IsJumping { get; set; }
        bool IsFalling { get; set; }
    }
}
