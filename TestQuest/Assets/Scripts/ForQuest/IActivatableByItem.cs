public interface IActivatableByItem<in T>
{
    bool Activate(T item);

}
