namespace trestleBridge.Interfaces
{
    public interface IFacility<T>
    {
        //List<T> animals { get; }
        void AddResource(T resource, Farm f);
    }
}