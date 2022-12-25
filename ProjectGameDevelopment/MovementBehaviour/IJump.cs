using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.MovementBehaviour
{
    public interface IJump
    {
        float StartY { get; set; }
        float JumpSpeed { get; set; }
        bool IsJumping { get; set; }
        bool IsFalling { get; set; }
    }
}
