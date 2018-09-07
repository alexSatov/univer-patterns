using Xrm.ReportUtility.Infrastructure.Transformers;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure
{
    public static class DataTransformerCreator // Скорее всего билдер, т.к. строим сложный объект трансформер из разных простых трансформеров
    {
        public static IDataTransformer CreateTransformer(ReportConfig config)
        {
            // Цепь обязанностей, можно избавиться от кучи if-ов, дав доступ к конфигурации (проверка будет внутри каждого трансформера)
            // Исправил
            IDataTransformer service = new DataTransformer(config);
            service = new WithDataReportTransformer(service);
            service = new VolumeSumReportTransformer(service);
            service = new WeightSumReportTransfomer(service);
            service = new CostSumReportTransformer(service);
            service = new CountSumReportTransformer(service);
            return service;
        }
    }
}