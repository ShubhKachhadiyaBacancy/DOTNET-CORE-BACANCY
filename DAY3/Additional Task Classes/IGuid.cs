namespace DAY3.Additional_Task_Classes
{
    public interface IGuidSingleton
    {
        public Guid GetGuid();
    }

    public interface IGuidTransient
    {
        public Guid GetGuid();
    }

    public interface IGuidScoped
    {
        public Guid GetGuid();
    }
}
