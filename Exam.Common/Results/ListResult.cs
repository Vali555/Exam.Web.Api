using System.ComponentModel;

namespace Exam.Common.Results
{
    public class ListResult<T> where T:class
    {
        public IEnumerable<T>? List { get; set; }
        public int TotalCount { get; set; } = 0;
    }
}
