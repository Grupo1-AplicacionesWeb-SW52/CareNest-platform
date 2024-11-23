namespace WebApplication3.ServiceDetail.Domain.Model.Queries
{
    public class GetServiceDetailByIdQuery
    {
        public int Id { get; set; }
        public GetServiceDetailByIdQuery(int id)
        {
            Id = id;
        }
    }
}
