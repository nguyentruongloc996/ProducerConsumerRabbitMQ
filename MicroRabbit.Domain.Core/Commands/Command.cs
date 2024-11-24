using MicroRabbit.Domain.Core.Events;

namespace MicroRabbit.Domain.Core.Bus
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; set; }
        protected Command() 
        {
            Timestamp = DateTime.Now;
        }
    }
}