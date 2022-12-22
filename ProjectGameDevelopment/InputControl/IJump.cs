using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.InputControl
{
    public interface IJump
    {
        float startY { get; set; }
        float FallVelocity { get; set; }
        float JumpSpeed { get; set; }
        bool IsJumping { get; set; }
        bool IsFalling { get; set; }
    }
}
