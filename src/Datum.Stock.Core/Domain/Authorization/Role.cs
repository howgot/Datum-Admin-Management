namespace Datum.Stock.Core.Domain.Authorization
{
    public class Role : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Locked { get; set; }
    }
}
