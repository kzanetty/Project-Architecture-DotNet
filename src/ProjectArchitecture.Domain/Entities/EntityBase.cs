namespace ProjectArchitecture.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; protected set; }
        //A classe está bem simples. Mas poderia ter muitas outras propriedades. Ex.:
        //DateTime CreatedDate { get; set; }
        //string CreateBy { get; set;}
        //DateTime? ModifiedDate { get; set; }
        //string? ModifiedBy { get; set;}
    }
}
