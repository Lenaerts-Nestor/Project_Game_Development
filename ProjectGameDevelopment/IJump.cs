using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment
{
    public interface IJump
    {
        float FallVelocity { get; set; }
        bool IsJumping { get; set; }
        bool IsFalling { get; set; }
    }
}
