namespace MiTubeAPI.Repos
{
    public interface IRepo<T>
    {
        void AddElement(T data);

        T UpdateElement(T data);

        void RemoveElement(T data);

        T GetElemById(int id);

        IEnumerable<T> GetAllElements();
    }
}
