namespace DAY3.Additional_Task_Classes
{
    public class GuidClass:IGuidSingleton,IGuidTransient,IGuidScoped
    {
        private Guid token;
        public GuidClass()
        {
            this.token = Guid.NewGuid();
        }
        public Guid GetGuid()
        {
            return this.token;
        }
    }
}
