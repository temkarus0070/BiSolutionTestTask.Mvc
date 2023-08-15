namespace BiSolutionTestTask.WebAPI.models
{
    public class ListEntry<T> : IComparable<T> where T : IComparable<T>
    {
        public ListEntry<T> Previous { get; set; }
        public ListEntry<T> Next { get; set; }
        public T Value { get; set; }

        public int CompareTo(T? other)
        {
            if (this.Value != null)
                return this.Value.CompareTo(other);
            else if (other != null)
            {
                return 1;
            }
            return 0;
        }
    }
}
