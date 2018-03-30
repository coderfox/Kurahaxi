using System.Threading.Tasks;

namespace Kurahaxi
{
    public interface IExporter
    {
        void Export();
        Task ExportAsync();
    }
}