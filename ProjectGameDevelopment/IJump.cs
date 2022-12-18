using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment
{
    public interface IJump
    {
        float JumpVelocity { get; set; }
        bool IsJumping { get; set; }
        bool CanJump { get; set; } 
    }
}
