using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers.Abstract
{
    public abstract class ReportServiceTransformerBase : IDataTransformer // Мост между трансформером и репорт сервисом
    {
        protected readonly IDataTransformer DataTransformer;

        protected ReportServiceTransformerBase(IDataTransformer dataTransformer)
        {
            DataTransformer = dataTransformer;
        }

        public abstract Report TransformData(DataRow[] data); // Фаборичный метод для создания репорта
    }
}
