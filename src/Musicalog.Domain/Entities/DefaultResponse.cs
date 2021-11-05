namespace Musicalog.Domain.Entities
{
    public class DefaultResponse<TEntity>
    {
        public DefaultResponse(bool success, TEntity result)
        {
            Success = success;
            Menssage = string.Empty;
            Result = result;
        }

        public DefaultResponse(bool success, string menssage, TEntity result)
        {
            Success = success;
            Menssage = menssage;
            Result = result;
        }

        public bool Success { get; private set; }
        public string Menssage { get; private set; }
        public TEntity Result { get; private set; }
    }
}