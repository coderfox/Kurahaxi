using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kurahaxi
{
    public interface IImporter
    {
        IEnumerable<Course> Import();
        Task<IEnumerable<Course>> ImportAsync();
    }
}